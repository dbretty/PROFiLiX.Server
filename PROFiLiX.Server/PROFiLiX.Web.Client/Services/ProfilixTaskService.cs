// <copyright file="ProfilixTaskService.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Client.Services
{
    using System.Net.Http.Json;
    using PROFiLiX.Web.Shared.Models;
    using PROFiLiX.Web.Shared.ProfilixTaskRepositories;

	/// <summary>
	/// Class for EUC Profile Buddy Task Service.
	/// </summary>
	public class ProfilixTaskService : IProfilixTaskRepository
	{
		private readonly HttpClient httpClient;

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfilixTaskService"/> class.
		/// </summary>
		/// <param name="httpClient">The HTTP Client.</param>
		public ProfilixTaskService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		/// <inheritdoc/>
		public async Task<ProfilixTask?> AddProfilixTaskAsync(ProfilixTask model)
		{
			var task = await this.httpClient.PostAsJsonAsync("api/ProfilixTask/Add-Task/", model);
			var response = await task.Content.ReadFromJsonAsync<ProfilixTask>();
			return response!;
		}

		/// <inheritdoc/>
		public async Task<ProfilixTask?> DeleteProfilixTaskAsync(int taskId)
		{
			var task = await this.httpClient.DeleteAsync($"api/ProfilixTask/Delete-Task/{taskId}");
			var response = await task.Content.ReadFromJsonAsync<ProfilixTask>();
			return response!;
		}

		/// <inheritdoc/>
		public async Task<List<ProfilixTask>> GetAllProfilixTasksAsync()
		{
			var tasks = await this.httpClient.GetAsync("api/ProfilixTask/All-Tasks");
			var response = await tasks.Content.ReadFromJsonAsync<List<ProfilixTask>>();
			return response!;
		}

		/// <inheritdoc/>
		public async Task<ProfilixTask?> GetProfilixTaskByIdAsync(int taskId)
		{
			var task = await this.httpClient.GetAsync($"api/ProfilixTask/Single-Task/{taskId}");
			var response = await task.Content.ReadFromJsonAsync<ProfilixTask>();
			return response!;
		}

		/// <inheritdoc/>
		public async Task<ProfilixTask?> UpdateProfilixTaskAsync(ProfilixTask model)
		{
			var task = await this.httpClient.PutAsJsonAsync("api/ProfilixTask/Update-Task/", model);
			var response = await task.Content.ReadFromJsonAsync<ProfilixTask>();
			return response!;
		}
	}
}
