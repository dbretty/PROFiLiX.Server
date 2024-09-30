// <copyright file="ProfilixCustomActionController.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Controllers
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using PROFiLiX.Web.Shared.Models;
    using PROFiLiX.Web.Shared.ProfilixCustomActionRepositories;

	/// <summary>
	/// Class to represent the Api for the Profilix Custom Action Controller.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ProfilixCustomActionController : ControllerBase
	{
		private readonly IProfilixCustomActionRepository profilixCustomActionRepository;

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfilixCustomActionController"/> class.
		/// </summary>
		/// <param name="profilixCustomActionRepository">The Datasource.</param>
		public ProfilixCustomActionController(IProfilixCustomActionRepository profilixCustomActionRepository)
		{
			this.profilixCustomActionRepository = profilixCustomActionRepository;
		}

		/// <summary>
		/// Gets all the Profilix Custom Action records.
		/// </summary>
		/// <returns>A <see cref="Task{ProfilixCustomAction}"/> representing the result of the asynchronous operation.</returns>
		/// <remarks>
		/// Sample request:
		///
		///     GET /api/ProfilixCustomAction/All-Actions
		///     {
		///     }
		///
		/// </remarks>
		/// <response code="200">Returns the Custom Action records.</response>
		/// <response code="404">Returns if the no Custom Action Records are found.</response>
		[HttpGet("All-Actions")]
		public async Task<ActionResult<List<ProfilixCustomAction>>> GetAllProfilixCustomActionsAsync()
		{
			var actions = await this.profilixCustomActionRepository.GetAllProfilixCustomActionsAsync();
			return this.Ok(actions);
		}

		/// <summary>
		/// Gets a single Profilix Custom Action record.
		/// </summary>
		/// <param name="id">The action id.</param>
		/// <returns>A <see cref="Task{ProfilixCustomAction}"/> representing the result of the asynchronous operation.</returns>
		/// <remarks>
		/// Sample request:
		///
		///     GET /api/ProfilixCustomAction/Single-Action/{id}
		///     {
		///     }
		///
		/// </remarks>
		/// <response code="200">Returns the Custom Action record.</response>
		/// <response code="404">Returns if the no Custom Action Records are found.</response>
		[HttpGet("Single-Action/{id}")]
		[ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(ProfilixCustomAction))]
		[ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(string))]
		public async Task<ActionResult> GetSingleProfilixCustomActionAsync(int id)
		{
			var action = await this.profilixCustomActionRepository.GetProfilixCustomActionByIdAsync(id);
			if (action == null)
			{
				return this.NotFound("Action not found");
			}
			else
			{
				return this.Ok(action);
			}
		}

		/// <summary>
		/// Adds a custom action record.
		/// </summary>
		/// <param name="model"> the request for the operation.</param>
		/// <returns>A <see cref="Task{ProfilixCustomAction}"/> representing the result of the asynchronous operation.</returns>
		/// <remarks>
		/// Sample request:
		///
		///     POST /api/ProfilixCustomAction/Add-Action
		///     {
		///         ActionName: "Clear D Drive"
		///         ActionType: PowerShell
		///         ActionContent: "RD D:\ *"
		///     }
		///
		/// </remarks>
		/// <response code="200">Returns the Custom Action record.</response>
		/// <response code="404">Returns if the no Custom Action Records are found.</response>
		[HttpPost("Add-Action")]
		[ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(ProfilixCustomAction))]
		[ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
		public async Task<ActionResult> AddProfilixCustomActionAsync([FromBody] ProfilixCustomAction model)
		{
			var action = await this.profilixCustomActionRepository.AddProfilixCustomActionAsync(model);
			return this.Ok(action);
		}

		/// <summary>
		/// Updates a Custom Action record.
		/// </summary>
		/// <param name="model">The request body for the operation.</param>
		/// <returns>A <see cref="Task{ProfilixCustomAction}"/> representing the result of the asynchronous operation.</returns>
		/// <remarks>
		/// Sample request:
		///
		///     POST /api/ProfilixCustomAction/Update-Action
		///     {
		///         ActionType: CommandLine
		///     }
		///
		/// </remarks>
		/// <response code="200">Returns the Custom Action record.</response>
		/// <response code="404">Returns if the no Custom Action Records are found.</response>
		[HttpPut("Update-Action")]
		[ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(ProfilixCustomAction))]
		[ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
		public async Task<ActionResult<List<ProfilixCustomAction>>> UpdateProfilixCustomActionAsync(ProfilixCustomAction model)
		{
			var action = await this.profilixCustomActionRepository.UpdateProfilixCustomActionAsync(model);
			if (action == null)
			{
				return this.BadRequest("Custom Action not found");
			}
			else
			{
				return this.Ok(action);
			}
		}

		/// <summary>
		/// Deletes a Custom Action record.
		/// </summary>
		/// <param name="id">The id for the custom action to delete.</param>
		/// <returns>A <see cref="Task{ProfilixCustomAction}"/> representing the result of the asynchronous operation.</returns>
		/// <remarks>
		/// Sample request:
		///
		///     POST /api/ProfilixCustomAction/Delete-Action
		///     {
		///         Id: 7
		///     }
		///
		/// </remarks>
		[HttpDelete("Delete-Action/{id}")]
		[ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(ProfilixCustomAction))]
		[ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
		public async Task<ActionResult<List<ProfilixCustomAction>>> DeleteProfilixCustomActionAsync(int id)
		{
			var action = await this.profilixCustomActionRepository.DeleteProfilixCustomActionAsync(id);
			return this.Ok(action);
		}
	}
}
