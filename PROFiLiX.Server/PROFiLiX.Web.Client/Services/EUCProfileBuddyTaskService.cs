// <copyright file="EUCProfileBuddyTaskService.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Client.Services
{
    using System.Net.Http.Json;
    using PROFiLiX.Web.Shared.EUCProfileBuddyTaskRepositories;
    using PROFiLiX.Web.Shared.Models;

	/// <summary>
	/// Class for EUC Profile Buddy Task Service.
	/// </summary>
	public class EUCProfileBuddyTaskService : IEUCProfileBuddyTaskRepository
	{
		private readonly HttpClient httpClient;

		/// <summary>
		/// Initializes a new instance of the <see cref="EUCProfileBuddyTaskService"/> class.
		/// </summary>
		/// <param name="httpClient">The HTTP Client.</param>
		public EUCProfileBuddyTaskService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		/// <inheritdoc/>
		public async Task<EUCProfileBuddyTask> AddEUCProfileBuddyTaskAsync(EUCProfileBuddyTask model)
		{
			var task = await this.httpClient.PostAsJsonAsync("api/EUCProfileBuddyTask/Add-Task/", model);
			var response = await task.Content.ReadFromJsonAsync<EUCProfileBuddyTask>();
			return response!;
		}

		/// <inheritdoc/>
		public async Task<EUCProfileBuddyTask> DeleteEUCProfileBuddyTaskAsync(int taskId)
		{
			var task = await this.httpClient.DeleteAsync($"api/EUCProfileBuddyTask/Delete-Task/{taskId}");
			var response = await task.Content.ReadFromJsonAsync<EUCProfileBuddyTask>();
			return response!;
		}

		/// <inheritdoc/>
		public async Task<List<EUCProfileBuddyTask>> GetAllEUCProfileBuddyTasksAsync()
		{
			var tasks = await this.httpClient.GetAsync("api/EUCProfileBuddyTask/All-Tasks");
			var response = await tasks.Content.ReadFromJsonAsync<List<EUCProfileBuddyTask>>();
			return response!;
		}

		/// <inheritdoc/>
		public async Task<EUCProfileBuddyTask> GetEUCProfileBuddyTaskByIdAsync(int taskId)
		{
			var task = await this.httpClient.GetAsync($"api/EUCProfileBuddyTask/Single-Task/{taskId}");
			var response = await task.Content.ReadFromJsonAsync<EUCProfileBuddyTask>();
			return response!;
		}

		/// <inheritdoc/>
		public async Task<EUCProfileBuddyTask> UpdateEUCProfileBuddyTaskAsync(EUCProfileBuddyTask model)
		{
			var task = await this.httpClient.PutAsJsonAsync("api/EUCProfileBuddyTask/Update-Task/", model);
			var response = await task.Content.ReadFromJsonAsync<EUCProfileBuddyTask>();
			return response!;
		}
	}
}
