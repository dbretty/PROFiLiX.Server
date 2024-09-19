// <copyright file="IEUCProfileBuddyTaskRepository.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Shared.EUCProfileBuddyTaskRepositories
{
    using PROFiLiX.Web.Shared.Models;

	/// <summary>
	/// Interface for EUC Profile Buddy Task actions.
	/// </summary>
	public interface IEUCProfileBuddyTaskRepository
    {
		/// <summary>
		/// Adds a task to the database.
		/// </summary>
		/// <param name="model">The task data model.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<EUCProfileBuddyTask> AddEUCProfileBuddyTaskAsync(EUCProfileBuddyTask model);

		/// <summary>
		/// Updates a task in the database.
		/// </summary>
		/// <param name="model">The task data model.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<EUCProfileBuddyTask> UpdateEUCProfileBuddyTaskAsync(EUCProfileBuddyTask model);

		/// <summary>
		/// Deleted a task from the database.
		/// </summary>
		/// <param name="taskId">The task Id.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<EUCProfileBuddyTask> DeleteEUCProfileBuddyTaskAsync(int taskId);

		/// <summary>
		/// Gets all the tasks from the database.
		/// </summary>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<List<EUCProfileBuddyTask>> GetAllEUCProfileBuddyTasksAsync();

		/// <summary>
		/// Gets a specific task from the database.
		/// </summary>
		/// <param name="taskId">The task ID.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<EUCProfileBuddyTask> GetEUCProfileBuddyTaskByIdAsync(int taskId);
    }
}
