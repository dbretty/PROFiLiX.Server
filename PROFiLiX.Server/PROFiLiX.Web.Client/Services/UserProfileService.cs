// <copyright file="UserProfileService.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Client.Services
{
    using System.Net.Http.Json;
    using PROFiLiX.Web.Shared.Models;
    using PROFiLiX.Web.Shared.UserProfileRepositories;

	/// <summary>
	/// Class for User Profile Service.
	/// </summary>
	public class UserProfileService : IUserProfileRepository
    {
        private readonly HttpClient httpClient;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserProfileService"/> class.
		/// </summary>
		/// <param name="httpClient">The HTTP Client.</param>
		public UserProfileService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

		/// <inheritdoc/>
		public async Task<UserProfile> AddUserProfileAsync(UserProfile model)
        {
            var userProfile = await this.httpClient.PostAsJsonAsync("api/UserProfile/Add-User-Profile/", model);
            var response = await userProfile.Content.ReadFromJsonAsync<UserProfile>();
            return response!;
        }

		/// <inheritdoc/>
		public async Task<UserProfile> DeleteUserProfileAsync(int userId)
        {
            var userProfile = await this.httpClient.DeleteAsync($"api/UserProfile/Delete-User-Profile/{userId}");
            var response = await userProfile.Content.ReadFromJsonAsync<UserProfile>();
            return response!;
        }

		/// <inheritdoc/>
		public async Task<List<UserProfile>> GetAllUserProfilesAsync()
        {
            var userProfiles = await this.httpClient.GetAsync("api/UserProfile/All-User-Profiles");
            var response = await userProfiles.Content.ReadFromJsonAsync<List<UserProfile>>();
            return response!;
        }

		/// <inheritdoc/>
		public async Task<UserProfile> GetUserProfileByIdAsync(int userId)
        {
			var userProfile = await this.httpClient.GetAsync($"api/UserProfile/Single-User-Profile/{userId}");
            var response = await userProfile.Content.ReadFromJsonAsync<UserProfile>();
            return response!;
        }

		/// <inheritdoc/>
		public async Task<UserProfile> UpdateUserProfileAsync(UserProfile model)
        {
            var userProfile = await this.httpClient.PutAsJsonAsync("api/UserProfile/Update-User-Profile/", model);
            var response = await userProfile.Content.ReadFromJsonAsync<UserProfile>();
            return response!;
        }
    }
}
