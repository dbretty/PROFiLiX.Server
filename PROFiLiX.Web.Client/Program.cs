// <auto-generated/>

using PROFiLiX.Web.Client;
using PROFiLiX.Web.Client.Services;
using PROFiLiX.Web.Shared.ProfilixTaskRepositories;
using PROFiLiX.Web.Shared.UserProfileRepositories;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PROFiLiX.Web.Shared.ProfilixCustomActionRepositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddScoped<IUserProfileRepository, UserProfileService>();
builder.Services.AddScoped<IProfilixTaskRepository, ProfilixTaskService>();
builder.Services.AddScoped<IProfilixCustomActionRepository, ProfilixCustomActionService>();

await builder.Build().RunAsync();
