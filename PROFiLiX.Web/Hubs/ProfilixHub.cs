// <copyright file="ProfilixHub.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using PROFiLiX.Web.Client.Services;
    using PROFiLiX.Web.Shared.Models.Enum;
    using PROFiLiX.Web.Shared.ProfilixTaskRepositories;

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

        /// <summary>
		/// Sends a message to a specific client.
		/// </summary>
        /// <param name="clientAction">The client action to take.</param>
        /// <param name="adminUserName">The user sending the message.</param>
        /// <param name="connectionId">The connection id.</param>
        /// <param name="taskId">The task id.</param>
        /// <param name="customTaskName">The custom task name.</param>
        /// <param name="actionType">The action type.</param>
        /// <param name="customTaskContent">The custom task content.</param>
		/// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public Task SendMessageToClient(string clientAction, string adminUserName, string connectionId, int taskId, string customTaskName, ActionType actionType, string customTaskContent)
        {
            return this.Clients.Client(connectionId).SendAsync(method: "ReceiveMessage", clientAction, adminUserName, connectionId, taskId, customTaskName, actionType, customTaskContent);
        }

        /// <summary>
		/// Gets a message from a specific client.
		/// </summary>
        /// <param name="clientMessage">The client message.</param>
        /// <param name="taskId">The task id.</param>
		/// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task ReceiveMessageFromClient(string clientMessage, int taskId)
        {
            HttpClient http = new ()
            {
                BaseAddress = new Uri("http://localhost:5120"),
            };
            IProfilixTaskRepository taskService = new ProfilixTaskService(http);
            var runningTask = await taskService.GetProfilixTaskByIdAsync(taskId);
            if (runningTask is not null)
            {
                runningTask.TaskState = ProfilixTaskState.Completed;
                await taskService.UpdateProfilixTaskAsync(runningTask);
            }
        }
    }
}
