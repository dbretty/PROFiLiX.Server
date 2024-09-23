// <copyright file="ProfilixTask.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Shared.Models
{
    using System.ComponentModel.DataAnnotations;
    using PROFiLiX.Web.Shared.Models.Enum;

	/// <summary>
	/// Class for the EUC Profile Buddy Task model.
	/// </summary>
	public class ProfilixTask
	{
		/// <summary>
		/// Gets or sets the Id.
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the users name.
		/// </summary>
		public string UserName { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the Task Name.
		/// </summary>
		public string TaskName { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the task executed date and time.
		/// </summary>
		public DateTime TaskExecuted { get; set; }

		/// <summary>
		/// Gets or sets the task state.
		/// </summary>
		public ProfilixTaskState TaskState { get; set; }

		/// <summary>
		/// Gets or sets the task run time.
		/// </summary>
		public TimeSpan TaskRunTime { get; set; }
	}
}
