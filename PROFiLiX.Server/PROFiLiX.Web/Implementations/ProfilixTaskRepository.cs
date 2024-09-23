using PROFiLiX.Web.Data;
using PROFiLiX.Web.Shared.ProfilixTaskRepositories;
using PROFiLiX.Web.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace PROFiLiX.Web.Implementations
{
    public class ProfilixTaskRepository : IProfilixTaskRepository
	{
		private readonly ProfileDataRepository profileDataRepository;

		public ProfilixTaskRepository(ProfileDataRepository profileDataRepository)
		{
			this.profileDataRepository = profileDataRepository;
		}

		public async Task<ProfilixTask> AddProfilixTaskAsync(ProfilixTask model)
		{
			if (model is null) return null;

			var newTask= profileDataRepository.ProfilixTask.Add(model).Entity;
			newTask.TaskExecuted = DateTime.UtcNow;
			await profileDataRepository.SaveChangesAsync();
			return newTask;
		}

		public async Task<ProfilixTask> DeleteProfilixTaskAsync(int taskId)
		{
			var task = await profileDataRepository.ProfilixTask.FirstOrDefaultAsync(_ => _.Id == taskId);
			if (task is null) return null;
			profileDataRepository.ProfilixTask.Remove(task);
			await profileDataRepository.SaveChangesAsync();
			return task;
		}

		public async Task<List<ProfilixTask>> GetAllProfilixTasksAsync() => await profileDataRepository.ProfilixTask.ToListAsync();

		public async Task<ProfilixTask> GetProfilixTaskByIdAsync(int taskId)
		{
			var task = await profileDataRepository.ProfilixTask.FirstOrDefaultAsync(_ => _.Id == taskId);
			if (task is null) return null;
			return task;
		}

		public async Task<ProfilixTask> UpdateProfilixTaskAsync(ProfilixTask model)
		{
			var task = await profileDataRepository.ProfilixTask.FirstOrDefaultAsync(_ => _.Id == model.Id);
			if (task is null) return null;
			task.UserName = model.UserName;
			task.TaskName = model.TaskName;
			task.TaskExecuted = model.TaskExecuted;
			task.TaskState = model.TaskState;
			task.TaskRunTime = DateTime.UtcNow - model.TaskExecuted;
			await profileDataRepository.SaveChangesAsync();
			return await profileDataRepository.ProfilixTask.FirstOrDefaultAsync(_ => _.Id == model.Id)!;
		}
	}
}
