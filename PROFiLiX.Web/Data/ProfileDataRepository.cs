﻿// <copyright file="ProfileDataRepository.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PROFiLiX.Web.Shared.Models;

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
        public DbSet<ProfilixTask> ProfilixTask { get; set; }

		/// <summary>
		/// Gets or sets the User Profile Table.
		/// </summary>
		public DbSet<UserProfile> UserProfile { get; set; }

		/// <summary>
		/// Gets or sets the Custom Action Table.
		/// </summary>
		public DbSet<ProfilixCustomAction> ProfilixCustomAction { get; set; }
	}
}
