using PROFiLiX.Web.Data;
using PROFiLiX.Web.Shared.Models;
using PROFiLiX.Web.Shared.UserProfileRepositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace PROFiLiX.Web.Implementations
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ProfileDataRepository profileDataRepository;

        public UserProfileRepository(ProfileDataRepository profileDataRepository)
        {
            this.profileDataRepository = profileDataRepository;
        }
        public async Task<UserProfile> AddUserProfileAsync(UserProfile model)
        {
            if (model is null) return null;
            model.DateCreated = DateTime.UtcNow;
            model.LastUpdated = DateTime.UtcNow;
            model.ProfileAge = DateTime.UtcNow - model.DateCreated;
            var newUserProfile = profileDataRepository.UserProfile.Add(model).Entity;
            await profileDataRepository.SaveChangesAsync();
            return newUserProfile;
        }

        public async Task<UserProfile> DeleteUserProfileAsync(int userId)
        {
            var userProfile = await profileDataRepository.UserProfile.FirstOrDefaultAsync(_ => _.Id == userId);
            if (userProfile is null) return null;
            profileDataRepository.UserProfile.Remove(userProfile);
            await profileDataRepository.SaveChangesAsync();
            return userProfile;
        }

        public async Task<List<UserProfile>> GetAllUserProfilesAsync() => await profileDataRepository.UserProfile.ToListAsync();


        public async Task<UserProfile> GetUserProfileByIdAsync(int userId)
        {
            var userProfile = await profileDataRepository.UserProfile.FirstOrDefaultAsync(_ => _.Id == userId);
            if (userProfile is null) return null;
            return userProfile;
        }

        public async Task<UserProfile> UpdateUserProfileAsync(UserProfile model)
        {
            var userProfile = await profileDataRepository.UserProfile.FirstOrDefaultAsync(_ => _.Id == model.Id);
            if (userProfile is null) return null;
            userProfile.UserName = model.UserName;
            userProfile.ProfileDirectory = model.ProfileDirectory;
			userProfile.ProfileSize = model.ProfileSize;
			userProfile.TempSize = model.TempSize;
			userProfile.ProfileType = model.ProfileType;
			userProfile.LastUpdated = DateTime.UtcNow;
			userProfile.DateCreated = userProfile.DateCreated;
            userProfile.ProfileAge = userProfile.LastUpdated - userProfile.DateCreated;
			userProfile.ActiveStatus = model.ActiveStatus;
            userProfile.HubConnectionId = (string)model.HubConnectionId;
            userProfile.OperatingSystem = model.OperatingSystem;
            userProfile.OperatingSystemVersion = model.OperatingSystemVersion;
            userProfile.NumberOfCPUs = model.NumberOfCPUs;
            userProfile.MemoryInMB = model.MemoryInMB;
            userProfile.MemoryInGB = model.MemoryInGB;
            userProfile.UserDomain = model.UserDomain;
			await profileDataRepository.SaveChangesAsync();
            return await profileDataRepository.UserProfile.FirstOrDefaultAsync(_ => _.Id == model.Id)!;
        }
    }
}
