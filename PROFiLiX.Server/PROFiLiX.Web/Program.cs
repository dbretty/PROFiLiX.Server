using PROFiLiX.Web.Client.Pages;
using PROFiLiX.Web.Components;
using PROFiLiX.Web.Components.Account;
using PROFiLiX.Web.Data;
using PROFiLiX.Web.Data.Initialize;
using PROFiLiX.Web.Hubs;
using PROFiLiX.Web.Implementations;
using PROFiLiX.Web.Shared.ProfilixTaskRepositories;
using PROFiLiX.Web.Shared.Models;
using PROFiLiX.Web.Shared.UserProfileRepositories;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.WindowsServices;
using MudBlazor.Services;
using NSwag;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    ContentRootPath = WindowsServiceHelpers.IsWindowsService() ? AppContext.BaseDirectory : default,
    Args = args
});

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(options =>
	options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
		new[] { "application/octet-stream" })
	);

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddDbContext<ProfileDataRepository>(options =>
{ 
    options.UseSqlite("Data Source=Profile.Data.Repository.db");
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IProfilixTaskRepository, ProfilixTaskRepository>();
builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseAddress").Value!)
});

builder.Services.AddIdentityCore<ApplicationUser>(options => 
    options.SignIn.RequireConfirmedAccount = false
    )
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ProfileDataRepository>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddMudServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAntiforgery();


builder.Services.AddOpenApiDocument(options =>
{
    options.PostProcess = document =>
    {
        document.Info = new OpenApiInfo
        {
            Version = "v1",
            Title = "PROFiLiX Server API",
            Description = "API documentation for PROFiLiX Server services.",
            TermsOfService = "https://bretty.me.uk/terms",
            Contact = new OpenApiContact
            {
                Name = "bretty.me.uk Support",
                Email = "dave@bretty.me.uk",
                Url = new Uri($"https://bretty.me.uk/").ToString(),
            },
        };
    };
});

builder.Host.UseWindowsService();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<ProfileDataRepository>();
var pendingMigrations = dbContext.Database.GetPendingMigrations();
if (pendingMigrations.Any())
{
    var logger = app.Services.GetService<ILogger<Program>>();
    logger.LogWarning("Performing migrations: {0}", string.Concat(pendingMigrations, ","));
    dbContext.Database.Migrate();
    logger.LogInformation("Migrations complete!");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();

app.MapHub<ProfilixHub>("/ProfilixHub");

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUi();

app.UseReDoc(options =>
{
    options.Path = "/redoc";
});

using (var localScope = app.Services.CreateScope())
{
    var profileDataRepository = scope.ServiceProvider;
    try
    {
        UserRoleInitializer.InitializeAsync(profileDataRepository).Wait();
    }
    catch (Exception ex)
    {
        var logger = profileDataRepository.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occured while attempting to seed the database");
    }
}

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(PROFiLiX.Web.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
