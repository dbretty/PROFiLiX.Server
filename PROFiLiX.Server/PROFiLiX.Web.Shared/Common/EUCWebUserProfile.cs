// <copyright file="EUCWebUserProfile.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Shared.Common
{
    using PROFiLiX.Web.Shared.Models;

    /// <summary>
	/// Class to manage common code for EUC Ewb Tier.
	/// </summary>
    public class EUCWebUserProfile : IEUCWebUserProfile
    {
        /// <inheritdoc/>
        public int TotalProfiles(List<UserProfile> profiles)
        {
            var i = 0;
            foreach (var profile in profiles)
            {
                i++;
            }

            return i;
        }

        /// <inheritdoc/>
        public long TotalProfileSize(List<UserProfile> profiles)
        {
            var size = 0L;
            foreach (var profile in profiles)
            {
                size = size + profile.ProfileSize;
            }

            return size;
        }

        /// <inheritdoc/>
        public long TotalTempSize(List<UserProfile> profiles)
        {
            var size = 0L;
            foreach (var profile in profiles)
            {
                size = size + profile.TempSize;
            }

            return size;
        }

        /// <inheritdoc/>
        public string FormatFileSize(long bytes)
        {
            ArgumentNullException.ThrowIfNull(bytes, nameof(bytes));

            var unit = 1024;
            if (bytes < unit)
            {
                return $"{bytes} B";
            }

            var exp = (int)(Math.Log(bytes) / Math.Log(unit));

            return $"{bytes / Math.Pow(unit, exp):F2} {"KMGTPE"[exp - 1]}B";
        }
    }
}