// <copyright file="ProfileDataRepository.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Data
{
    using PROFiLiX.Web.Shared.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// EUC Profile Buddy Data Repository Class.
    /// </summary>
    public class ProfileDataRepository : IdentityDbContext<ApplicationUser>
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileDataRepository"/> class.
        /// </summary>
        /// <param name="options">The DBContext Options.</param>
        public ProfileDataRepository(DbContextOptions<ProfileDataRepository> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Task Information.
        /// </summary>
        public DbSet<EUCProfileBuddyTask> EUCProfileBuddyTask { get; set; }

		/// <summary>
		/// Gets or sets the User Profile Table.
		/// </summary>
		public DbSet<UserProfile> UserProfile { get; set; }
    }
}
