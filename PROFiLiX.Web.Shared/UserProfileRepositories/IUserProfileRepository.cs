// <copyright file="IUserProfileRepository.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Shared.UserProfileRepositories
{
    using PROFiLiX.Web.Shared.Models;

	/// <summary>
	/// Interface for user profile actions.
	/// </summary>
	public interface IUserProfileRepository
    {
		/// <summary>
		/// Adds a user profile to the database.
		/// </summary>
		/// <param name="model">The User Profile model.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<UserProfile?> AddUserProfileAsync(UserProfile model);

		/// <summary>
		/// Updates a user profile in the database.
		/// </summary>
		/// <param name="model">The User Profile model.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<UserProfile?> UpdateUserProfileAsync(UserProfile model);

		/// <summary>
		/// Deletes a user profile from the database.
		/// </summary>
		/// <param name="userId">The User ID</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<UserProfile?> DeleteUserProfileAsync(int userId);

		/// <summary>
		/// Gets all the user profiles from the database.
		/// </summary>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<List<UserProfile>> GetAllUserProfilesAsync();

		/// <summary>
		/// Gets a user profile from the database.
		/// </summary>
		/// <param name="userId">The User ID</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		Task<UserProfile?> GetUserProfileByIdAsync(int userId);
    }
}
