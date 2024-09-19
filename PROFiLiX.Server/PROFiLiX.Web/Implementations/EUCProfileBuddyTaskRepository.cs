using PROFiLiX.Web.Data;
using PROFiLiX.Web.Shared.EUCProfileBuddyTaskRepositories;
using PROFiLiX.Web.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace PROFiLiX.Web.Implementations
{
    public class EUCProfileBuddyTaskRepository : IEUCProfileBuddyTaskRepository
	{
		private readonly ProfileDataRepository profileDataRepository;

		public EUCProfileBuddyTaskRepository(ProfileDataRepository profileDataRepository)
		{
			this.profileDataRepository = profileDataRepository;
		}

		public async Task<EUCProfileBuddyTask> AddEUCProfileBuddyTaskAsync(EUCProfileBuddyTask model)
		{
			if (model is null) return null;

			var newTask= profileDataRepository.EUCProfileBuddyTask.Add(model).Entity;
			newTask.TaskExecuted = DateTime.UtcNow;
			await profileDataRepository.SaveChangesAsync();
			return newTask;
		}

		public async Task<EUCProfileBuddyTask> DeleteEUCProfileBuddyTaskAsync(int taskId)
		{
			var task = await profileDataRepository.EUCProfileBuddyTask.FirstOrDefaultAsync(_ => _.Id == taskId);
			if (task is null) return null;
			profileDataRepository.EUCProfileBuddyTask.Remove(task);
			await profileDataRepository.SaveChangesAsync();
			return task;
		}

		public async Task<List<EUCProfileBuddyTask>> GetAllEUCProfileBuddyTasksAsync() => await profileDataRepository.EUCProfileBuddyTask.ToListAsync();

		public async Task<EUCProfileBuddyTask> GetEUCProfileBuddyTaskByIdAsync(int taskId)
		{
			var task = await profileDataRepository.EUCProfileBuddyTask.FirstOrDefaultAsync(_ => _.Id == taskId);
			if (task is null) return null;
			return task;
		}

		public async Task<EUCProfileBuddyTask> UpdateEUCProfileBuddyTaskAsync(EUCProfileBuddyTask model)
		{
			var task = await profileDataRepository.EUCProfileBuddyTask.FirstOrDefaultAsync(_ => _.Id == model.Id);
			if (task is null) return null;
			task.UserName = model.UserName;
			task.TaskName = model.TaskName;
			task.TaskExecuted = model.TaskExecuted;
			task.TaskState = model.TaskState;
			task.TaskRunTime = DateTime.UtcNow - model.TaskExecuted;
			await profileDataRepository.SaveChangesAsync();
			return await profileDataRepository.EUCProfileBuddyTask.FirstOrDefaultAsync(_ => _.Id == model.Id)!;
		}
	}
}
