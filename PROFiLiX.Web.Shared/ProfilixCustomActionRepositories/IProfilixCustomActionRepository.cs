// <copyright file="IProfilixCustomActionRepository.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Shared.ProfilixCustomActionRepositories
{
    using PROFiLiX.Web.Shared.Models;

	/// <summary>
	/// Interface for Profilix Custom Actions actions.
	/// </summary>
	public interface IProfilixCustomActionRepository
	{
		/// <summary>
		/// Adds a custom action to the database.
		/// </summary>
		/// <param name="model">The action data model.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<ProfilixCustomAction?> AddProfilixCustomActionAsync(ProfilixCustomAction model);

		/// <summary>
		/// Updates an action in the database.
		/// </summary>
		/// <param name="model">The task data model.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<ProfilixCustomAction?> UpdateProfilixCustomActionAsync(ProfilixCustomAction model);

		/// <summary>
		/// Deleted an action from the database.
		/// </summary>
		/// <param name="actionId">The action Id.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<ProfilixCustomAction?> DeleteProfilixCustomActionAsync(int actionId);

		/// <summary>
		/// Gets all the actions from the database.
		/// </summary>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<List<ProfilixCustomAction>> GetAllProfilixCustomActionsAsync();

		/// <summary>
		/// Gets a specific action from the database.
		/// </summary>
		/// <param name="actionId">The action ID.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<ProfilixCustomAction?> GetProfilixCustomActionByIdAsync(int actionId);
    }
}
