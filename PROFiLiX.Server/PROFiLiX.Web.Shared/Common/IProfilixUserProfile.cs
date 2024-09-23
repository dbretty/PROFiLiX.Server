// <copyright file="IProfilixUserProfile.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Shared.Common
{
    using PROFiLiX.Web.Shared.Models;

    /// <summary>
	/// Interface to manage common code for EUC Ewb Tier.
	/// </summary>
    public interface IProfilixUserProfile
    {
        /// <summary>
        /// Formats the size passed in.
        /// </summary>
        /// <param name="bytes">The total size to format.</param>
        /// <returns>A <see cref="string"/>.</returns>
        string FormatFileSize(long bytes);

        /// <summary>
        /// Gets the total number of profiles.
        /// </summary>
        /// <param name="profiles">The profiles array.</param>
        /// <returns>A <see cref="UserProfileSummary"/>.</returns>
        int TotalProfiles(List<UserProfile> profiles);

        /// <summary>
        /// Gets the total profile size.
        /// </summary>
        /// <param name="profiles">The profiles array.</param>
        /// <returns>A <see cref="UserProfileSummary"/>.</returns>
        long TotalProfileSize(List<UserProfile> profiles);

        /// <summary>
        /// Gets the total temp size.
        /// </summary>
        /// <param name="profiles">The profiles array.</param>
        /// <returns>A <see cref="UserProfileSummary"/>.</returns>
        long TotalTempSize(List<UserProfile> profiles);
    }
}