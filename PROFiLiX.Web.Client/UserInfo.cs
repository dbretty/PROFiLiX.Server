// <copyright file="UserInfo.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Client
{
	/// <summary>
	/// Class for the UserInfo model.
	/// </summary>
	public class UserInfo
    {
		/// <summary>
		/// Gets or sets the UserId.
		/// </summary>
		required public string UserId { get; set; }

		/// <summary>
		/// Gets or sets the Email.
		/// </summary>
		required public string Email { get; set; }

		/// <summary>
		/// Gets or sets the Role.
		/// </summary>
		required public string Role { get; set; }
    }
}
