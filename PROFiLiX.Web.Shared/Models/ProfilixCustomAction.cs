// <copyright file="ProfilixCustomAction.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Shared.Models
{
    using System.ComponentModel.DataAnnotations;
    using PROFiLiX.Web.Shared.Models.Enum;

	/// <summary>
	/// Class for the custom actions model.
	/// </summary>
	public class ProfilixCustomAction
	{
		/// <summary>
		/// Gets or sets the action id.
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the custom action name.
		/// </summary>
		[Required(ErrorMessage = "You must specify a Action Name")]
		public string ActionName { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the custom action description.
		/// </summary>
		[Required(ErrorMessage = "You must specify a Action Name")]
		public string ActionDescription { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the custom action type.
		/// </summary>
		[Required(ErrorMessage = "You must specify a Action Type")]
		public ActionType ActionType { get; set; }

		/// <summary>
		/// Gets or sets the custom action content.
		/// </summary>
		[Required(ErrorMessage = "You must specify some Action Content")]
		public string ActionContent { get; set; } = string.Empty;
	}
}
