// <copyright file="EUCProfileBuddyHub.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Hubs
{
    using PROFiLiX.Web.Client.Services;
    using PROFiLiX.Web.Shared.ProfilixTaskRepositories;
    using PROFiLiX.Web.Shared.Models;
    using PROFiLiX.Web.Shared.Models.Enum;
    using Microsoft.AspNetCore.SignalR;
    using MudBlazor;

    /// <summary>
    /// Class to Initialize the SignalR Hub.
    /// </summary>
    public class ProfilixHub : Hub
    {

        /// <summary>
        /// Function to send a message to all clients.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="user">The user sending the message.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        public Task SendMessage(string message, string user)
		{
			return this.Clients.All.SendAsync(method: "ReceiveMessage", message, user);
		}

        public Task SendMessageToClient(string clientAction, string adminUserName, string connectionId, int taskId)
        {
            return this.Clients.Client(connectionId).SendAsync(method: "ReceiveMessage", clientAction, adminUserName, connectionId, taskId);
        }

        public async Task ReceiveMessageFromClient(string clientMessage, int taskId)
        {
            HttpClient http = new()
            {
                BaseAddress = new Uri("http://localhost:5120"),
            };
            IProfilixTaskRepository taskService = new ProfilixTaskService(http);
           
            var runningTask = await taskService.GetProfilixTaskByIdAsync(taskId);
            runningTask.TaskState = ProfilixTaskState.Completed;

            taskService.UpdateProfilixTaskAsync(runningTask);
        }
    }
}
