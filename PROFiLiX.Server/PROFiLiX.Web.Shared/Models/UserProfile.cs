// <copyright file="UserProfile.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Shared.Models
{
    using System.ComponentModel.DataAnnotations;
    using PROFiLiX.Web.Shared.Models.Enum;

	/// <summary>
	/// Class for the user profile model.
	/// </summary>
	public class UserProfile
    {
		/// <summary>
		/// Gets or sets the users id.
		/// </summary>
		[Key]
        public int Id { get; set; }

		/// <summary>
		/// Gets or sets the users name.
		/// </summary>
		[Required(ErrorMessage = "You must specify a UserName")]
		public string UserName { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the profile directory.
		/// </summary>
		[Required(ErrorMessage = "You must specify a valid ProfileDirectory")]
		public string ProfileDirectory { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the size of the profile.
		/// </summary>
		public long ProfileSize { get; set; } = 0;

		/// <summary>
		/// Gets or sets the temp data size of the profile.
		/// </summary>
		public long TempSize { get; set; } = 0;

		/// <summary>
		/// Gets or sets the profile type.
		/// </summary>
		public ProfileType ProfileType { get; set; } = ProfileType.Local;

		/// <summary>
		/// Gets or sets the last updated time of this entity.
		/// </summary>
		public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

		/// <summary>
		/// Gets or sets the date created time of this entity.
		/// </summary>
		public DateTime DateCreated { get; set; } = DateTime.UtcNow;

		/// <summary>
		/// Gets or sets the profile age of this entity.
		/// </summary>
		public TimeSpan ProfileAge { get; set; } = TimeSpan.Zero;

		/// <summary>
		/// Gets or sets a value indicating whether gets or sets the profile ActiveStatus.
		/// </summary>
		public bool ActiveStatus { get; set; } = false;

		/// <summary>
		/// Gets or sets a value indicating whether gets or sets the profile ActiveStatus.
		/// </summary>
		public string HubConnectionId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether Operating System.
        /// </summary>
        public string OperatingSystem { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether Operating System Version.
        /// </summary>
        public string OperatingSystemVersion { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether Number of CPUs.
        /// </summary>
        public int NumberOfCPUs { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether Memory MB.
        /// </summary>
        public int MemoryInMB { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether Memory GB.
        /// </summary>
        public int MemoryInGB { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether User Domain.
        /// </summary>
        public string UserDomain { get; set; } = string.Empty;
    }
}
