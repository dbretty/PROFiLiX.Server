// <copyright file="ProfilixCustomActionRepository.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Implementations
{
	using Microsoft.EntityFrameworkCore;
	using PROFiLiX.Web.Data;
	using PROFiLiX.Web.Shared.Models;
	using PROFiLiX.Web.Shared.ProfilixCustomActionRepositories;

	/// <summary>
	/// Class for Profilix Action Service.
	/// </summary>
	public class ProfilixCustomActionRepository : IProfilixCustomActionRepository
	{
		private readonly ProfileDataRepository profileDataRepository;

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfilixCustomActionRepository"/> class.
		/// </summary>
		/// <param name="profileDataRepository">The Profile Data Reposiroty.</param>
		public ProfilixCustomActionRepository(ProfileDataRepository profileDataRepository)
		{
			this.profileDataRepository = profileDataRepository;
		}

		/// <inheritdoc/>
		public async Task<ProfilixCustomAction?> AddProfilixCustomActionAsync(ProfilixCustomAction model)
		{
			if (model is null)
			{
				return null;
			}
			else
			{
				var newAction = this.profileDataRepository.ProfilixCustomAction.Add(model).Entity;
				await this.profileDataRepository.SaveChangesAsync();
				return newAction;
			}
		}

		/// <inheritdoc/>
		public async Task<ProfilixCustomAction?> DeleteProfilixCustomActionAsync(int actionId)
		{
			var action = await this.profileDataRepository.ProfilixCustomAction.FirstOrDefaultAsync(_ => _.Id == actionId);
			if (action is null)
			{
				return null;
			}
			else
			{
				this.profileDataRepository.ProfilixCustomAction.Remove(action);
				await this.profileDataRepository.SaveChangesAsync();
				return action;
			}
		}

		/// <inheritdoc/>
		public async Task<List<ProfilixCustomAction>> GetAllProfilixCustomActionsAsync() => await this.profileDataRepository.ProfilixCustomAction.ToListAsync();

		/// <inheritdoc/>
		public async Task<ProfilixCustomAction?> GetProfilixCustomActionByIdAsync(int actionId)
		{
			var action = await this.profileDataRepository.ProfilixCustomAction.FirstOrDefaultAsync(_ => _.Id == actionId);
			if (action is null)
			{
				return null;
			}
			else
			{
				return action;
			}
		}

		/// <inheritdoc/>
		public async Task<ProfilixCustomAction?> UpdateProfilixCustomActionAsync(ProfilixCustomAction model)
		{
			var action = await this.profileDataRepository.ProfilixCustomAction.FirstOrDefaultAsync(_ => _.Id == model.Id);
			if (action is null)
			{
				return null;
			}
			else
			{
				action.ActionType = model.ActionType;
				action.ActionName = model.ActionName;
				action.ActionContent = model.ActionContent;
				action.ActionDescription = model.ActionDescription;
				await this.profileDataRepository.SaveChangesAsync();
				return await this.profileDataRepository.ProfilixCustomAction.FirstOrDefaultAsync(_ => _.Id == model.Id)!;
			}
		}
	}
}
