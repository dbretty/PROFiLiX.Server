// <copyright file="UserProfileController.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Controllers
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using PROFiLiX.Web.Shared.Models;
    using PROFiLiX.Web.Shared.UserProfileRepositories;

    /// <summary>
	/// Class to represent the Api for the User Profile Controller.
	/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository userProfileRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileController"/> class.
        /// </summary>
        /// <param name="userProfileRepository">The Datasource.</param>
        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            this.userProfileRepository = userProfileRepository;
        }

        /// <summary>
        /// Gets all the User Profile records.
        /// </summary>
        /// <returns>A <see cref="Task{UserProfile}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/UserProfile/All-User-Profiles
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the User Profile records.</response>
        /// <response code="404">Returns if the no User Profile Summary Records are found.</response>
        [HttpGet("All-User-Profiles")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(UserProfile))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(string))]
        public async Task<ActionResult<List<UserProfile>>> GetAllUserProfilesAsync()
        {
            var userProfiles = await this.userProfileRepository.GetAllUserProfilesAsync();
            if (userProfiles == null)
            {
                return this.NotFound("No user profiles found");
            }
            else
            {
                return this.Ok(userProfiles);
            }
        }

        /// <summary>
        /// Gets a single User Profile record.
        /// </summary>
        /// <param name="id">The user profile id.</param>
        /// <returns>A <see cref="Task{UserProfile}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/UserProfile/Single-User-Profile/{id}
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the User Profile records.</response>
        /// <response code="404">Returns if the no User Profile Summary Records are found.</response>
        [HttpGet("Single-User-Profile/{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(UserProfile))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(string))]
        public async Task<ActionResult> GetSingleUserProfileAsync(int id)
        {
            var userProfile = await this.userProfileRepository.GetUserProfileByIdAsync(id);
            if (userProfile == null)
            {
                return this.NotFound("User Profile not found");
            }
            else
            {
                return this.Ok(userProfile);
            }
        }

        /// <summary>
        /// Adds a User Profile record.
        /// </summary>
        /// <param name="model"> the request for the operation.</param>
        /// <returns>A <see cref="Task{UserProfile}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/UserProfile/Add-User-Profile
        ///     {
        ///         UserName: "Dave Brett"
        ///         ProfileSize: 1000324
        ///         TempSize: 321773
        ///         ProfileType: 0
        ///         ProfileDirectory: "C:\users\dave"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the newly created item.</response>
        /// <response code="400">If the item already exists.</response>
        [HttpPost("Add-User-Profile")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(UserProfile))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<IActionResult> AddUserProfileAsync([FromBody] UserProfile model)
        {
            var userProfile = await this.userProfileRepository.AddUserProfileAsync(model);
            return this.Ok(userProfile);
        }

        /// <summary>
        /// Updates a User Profile record.
        /// </summary>
        /// <param name="model">The request body for the operation.</param>
        /// <returns>A <see cref="Task{UserProfile}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/UserProfile/Update-User-Profile
        ///     {
        ///         UserName: "DaveBrettUpdated"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the updated User Profile record.</response>
        /// <response code="404">Returns if the User Profile does not exist.</response>
        /// <response code="400">Returns the HTTP exception.</response>
        [HttpPut("Update-User-Profile")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(UserProfile))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<IActionResult> UpdateUserProfileAsync(UserProfile model)
        {
            var userProfile = await this.userProfileRepository.UpdateUserProfileAsync(model);
            if (userProfile == null)
            {
                return this.BadRequest("User Profile not found");
            }
            else
            {
                return this.Ok(userProfile);
            }
        }

        /// <summary>
        /// Deletes a User Profile record.
        /// </summary>
        /// <param name="id">The id for the user profile to delete.</param>
        /// <returns>A <see cref="Task{UserProfile}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/UserProfile/Delete-User-Profile
        ///     {
        ///         Id: 7
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the updated User Profile record.</response>
        /// <response code="404">Returns if the User Profile does not exist.</response>
        [HttpDelete("Delete-User-Profile/{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(UserProfile))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<ActionResult<List<UserProfile>>> DeleteUserProfileAsync(int id)
        {
            var userProfile = await this.userProfileRepository.DeleteUserProfileAsync(id);
            if (userProfile == null)
            {
                return this.BadRequest("User Profile not found");
            }
            else
            {
                return this.Ok(userProfile);
            }
        }
    }
}
