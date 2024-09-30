// <copyright file="ProfilixCustomActionService.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Client.Services
{
    using System.Net.Http.Json;
    using PROFiLiX.Web.Shared.Models;
    using PROFiLiX.Web.Shared.ProfilixCustomActionRepositories;

	/// <summary>
	/// Class for Profilix Custom Action Service.
	/// </summary>
	public class ProfilixCustomActionService : IProfilixCustomActionRepository
	{
		private readonly HttpClient httpClient;

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfilixCustomActionService"/> class.
		/// </summary>
		/// <param name="httpClient">The HTTP Client.</param>
		public ProfilixCustomActionService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		/// <inheritdoc/>
		public async Task<ProfilixCustomAction?> AddProfilixCustomActionAsync(ProfilixCustomAction model)
		{
			var action = await this.httpClient.PostAsJsonAsync("api/ProfilixCustomAction/Add-Action/", model);
			var response = await action.Content.ReadFromJsonAsync<ProfilixCustomAction>();
			return response!;
		}

		/// <inheritdoc/>
		public async Task<ProfilixCustomAction?> DeleteProfilixCustomActionAsync(int actionId)
		{
			var action = await this.httpClient.DeleteAsync($"api/ProfilixCustomAction/Delete-Action/{actionId}");
			var response = await action.Content.ReadFromJsonAsync<ProfilixCustomAction>();
			return response!;
		}

		/// <inheritdoc/>
		public async Task<List<ProfilixCustomAction>> GetAllProfilixCustomActionsAsync()
		{
			var actions = await this.httpClient.GetAsync("api/ProfilixCustomAction/All-Actions");
			var response = await actions.Content.ReadFromJsonAsync<List<ProfilixCustomAction>>();
			return response!;
		}

		/// <inheritdoc/>
		public async Task<ProfilixCustomAction?> GetProfilixCustomActionByIdAsync(int actionId)
		{
			var action = await this.httpClient.GetAsync($"api/ProfilixCustomAction/Single-Action/{actionId}");
			var response = await action.Content.ReadFromJsonAsync<ProfilixCustomAction>();
			return response!;
		}

		/// <inheritdoc/>
		public async Task<ProfilixCustomAction?> UpdateProfilixCustomActionAsync(ProfilixCustomAction model)
		{
			var action = await this.httpClient.PutAsJsonAsync("api/ProfilixCustomAction/Update-Action/", model);
			var response = await action.Content.ReadFromJsonAsync<ProfilixCustomAction>();
			return response!;
		}
	}
}
