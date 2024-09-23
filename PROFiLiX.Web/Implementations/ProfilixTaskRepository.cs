// <copyright file="ProfilixTaskRepository.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using PROFiLiX.Web.Data;
    using PROFiLiX.Web.Shared.Models;
    using PROFiLiX.Web.Shared.ProfilixTaskRepositories;

    /// <summary>
    /// Class for Profilix Task Service.
    /// </summary>
    public class ProfilixTaskRepository : IProfilixTaskRepository
	{
		private readonly ProfileDataRepository profileDataRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilixTaskRepository"/> class.
        /// </summary>
        /// <param name="profileDataRepository">The Profile Data Reposiroty.</param>
        public ProfilixTaskRepository(ProfileDataRepository profileDataRepository)
		{
			this.profileDataRepository = profileDataRepository;
		}

        /// <inheritdoc/>
        public async Task<ProfilixTask?> AddProfilixTaskAsync(ProfilixTask model)
		{
			if (model is null)
			{
				return null;
			}
			else
			{
                var newTask = this.profileDataRepository.ProfilixTask.Add(model).Entity;
                newTask.TaskExecuted = DateTime.UtcNow;
                await this.profileDataRepository.SaveChangesAsync();
                return newTask;
            }
		}

        /// <inheritdoc/>
        public async Task<ProfilixTask?> DeleteProfilixTaskAsync(int taskId)
		{
			var task = await this.profileDataRepository.ProfilixTask.FirstOrDefaultAsync(_ => _.Id == taskId);
			if (task is null)
			{
				return null;
			}
			else
			{
                this.profileDataRepository.ProfilixTask.Remove(task);
                await this.profileDataRepository.SaveChangesAsync();
                return task;
            }
		}

        /// <inheritdoc/>
        public async Task<List<ProfilixTask>> GetAllProfilixTasksAsync() => await this.profileDataRepository.ProfilixTask.ToListAsync();

        /// <inheritdoc/>
        public async Task<ProfilixTask?> GetProfilixTaskByIdAsync(int taskId)
		{
			var task = await this.profileDataRepository.ProfilixTask.FirstOrDefaultAsync(_ => _.Id == taskId);
			if (task is null)
			{
				return null;
			}
			else
			{
                return task;
            }
		}

        /// <inheritdoc/>
        public async Task<ProfilixTask?> UpdateProfilixTaskAsync(ProfilixTask model)
		{
			var task = await this.profileDataRepository.ProfilixTask.FirstOrDefaultAsync(_ => _.Id == model.Id);
			if (task is null)
			{
				return null;
			}
			else
			{
                task.UserName = model.UserName;
                task.TaskName = model.TaskName;
                task.TaskExecuted = model.TaskExecuted;
                task.TaskState = model.TaskState;
                task.TaskRunTime = DateTime.UtcNow - model.TaskExecuted;
                await this.profileDataRepository.SaveChangesAsync();
                return await this.profileDataRepository.ProfilixTask.FirstOrDefaultAsync(_ => _.Id == model.Id)!;
            }
		}
	}
}
