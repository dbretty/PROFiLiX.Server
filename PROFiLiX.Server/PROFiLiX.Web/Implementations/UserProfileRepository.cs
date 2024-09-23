// <copyright file="UserProfileRepository.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using PROFiLiX.Web.Data;
    using PROFiLiX.Web.Shared.Models;
    using PROFiLiX.Web.Shared.UserProfileRepositories;

    /// <summary>
	/// Class for User Profile Repository.
	/// </summary>
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ProfileDataRepository profileDataRepository;

        /// <summary>
		/// Initializes a new instance of the <see cref="UserProfileRepository"/> class.
		/// </summary>
		/// <param name="profileDataRepository">The Profile Data Repository.</param>
        public UserProfileRepository(ProfileDataRepository profileDataRepository)
        {
            this.profileDataRepository = profileDataRepository;
        }

        /// <inheritdoc/>
        public async Task<UserProfile?> AddUserProfileAsync(UserProfile model)
        {
            if (model is null)
            {
                return null;
            }
            else
            {
                model.DateCreated = DateTime.UtcNow;
                model.LastUpdated = DateTime.UtcNow;
                model.ProfileAge = DateTime.UtcNow - model.DateCreated;
                var newUserProfile = this.profileDataRepository.UserProfile.Add(model).Entity;
                await this.profileDataRepository.SaveChangesAsync();
                return newUserProfile;
            }
        }

        /// <inheritdoc/>
        public async Task<UserProfile?> DeleteUserProfileAsync(int userId)
        {
            var userProfile = await this.profileDataRepository.UserProfile.FirstOrDefaultAsync(_ => _.Id == userId);
            if (userProfile is null)
            {
                return null;
            }
            else
            {
                this.profileDataRepository.UserProfile.Remove(userProfile);
                await this.profileDataRepository.SaveChangesAsync();
                return userProfile;
            }
        }

        /// <inheritdoc/>
        public async Task<List<UserProfile>> GetAllUserProfilesAsync() => await this.profileDataRepository.UserProfile.ToListAsync();

        /// <inheritdoc/>
        public async Task<UserProfile?> GetUserProfileByIdAsync(int userId)
        {
            var userProfile = await this.profileDataRepository.UserProfile.FirstOrDefaultAsync(_ => _.Id == userId);
            if (userProfile is null)
            {
                return null;
            }
            else
            {
                return userProfile;
            }
        }

        /// <inheritdoc/>
        public async Task<UserProfile?> UpdateUserProfileAsync(UserProfile model)
        {
            var userProfile = await this.profileDataRepository.UserProfile.FirstOrDefaultAsync(_ => _.Id == model.Id);
            if (userProfile is null)
            {
                return null;
            }
            else
            {
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
                await this.profileDataRepository.SaveChangesAsync();
                return await this.profileDataRepository.UserProfile.FirstOrDefaultAsync(_ => _.Id == model.Id)!;
            }
        }
    }
}
