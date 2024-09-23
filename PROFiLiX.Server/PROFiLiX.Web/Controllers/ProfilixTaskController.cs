// <copyright file="ProfilixTaskController.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace PROFiLiX.Web.Controllers
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using PROFiLiX.Web.Shared.Models;
    using PROFiLiX.Web.Shared.ProfilixTaskRepositories;

    /// <summary>
    /// Class to represent the Api for the Profilix Task Controller.
    /// </summary>
    [Route("api/[controller]")]
	[ApiController]
	public class ProfilixTaskController : ControllerBase
	{
		private readonly IProfilixTaskRepository profilixTaskRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilixTaskController"/> class.
        /// </summary>
        /// <param name="profilixTaskRepository">The Datasource.</param>
        public ProfilixTaskController(IProfilixTaskRepository profilixTaskRepository)
		{
			this.profilixTaskRepository = profilixTaskRepository;
		}

        /// <summary>
        /// Gets all the Profilix Task records.
        /// </summary>
        /// <returns>A <see cref="Task{ProfilixTask}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/ProfilixTask/All-Tasks
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the Task records.</response>
        /// <response code="404">Returns if the no Task Summary Records are found.</response>
		[HttpGet("All-Tasks")]
		public async Task<ActionResult<List<ProfilixTask>>> GetAllProfilixTasksAsync()
		{
			var tasks = await this.profilixTaskRepository.GetAllProfilixTasksAsync();
			return this.Ok(tasks);
		}

        /// <summary>
        /// Gets a single Profilix Task record.
        /// </summary>
        /// <param name="id">The task id.</param>
        /// <returns>A <see cref="Task{ProfilixTask}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/ProfilixTask/Single-Task/{id}
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the Task record.</response>
        /// <response code="404">Returns if the no Task Summary Records are found.</response>
		[HttpGet("Single-Task/{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(ProfilixTask))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(string))]
        public async Task<ActionResult> GetSingleProfilixTaskAsync(int id)
		{
			var task = await this.profilixTaskRepository.GetProfilixTaskByIdAsync(id);
			if (task == null)
			{
				return this.NotFound("Task not found");
			}
			else
			{
				return this.Ok(task);
			}
		}

        /// <summary>
        /// Adds a task record.
        /// </summary>
        /// <param name="model"> the request for the operation.</param>
        /// <returns>A <see cref="Task{ProfilixTask}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/ProfilixTask/Add-Task
        ///     {
        ///         TaskName: "Task1"
        ///         TaskExecuted: 240278
        ///         TaskStatus: Running
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the Task record.</response>
        /// <response code="404">Returns if the no Task Summary Records are found.</response>
        [HttpPost("Add-Task")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(ProfilixTask))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<ActionResult> AddProfilixTaskAsync([FromBody] ProfilixTask model)
		{
			var task = await this.profilixTaskRepository.AddProfilixTaskAsync(model);
			return this.Ok(task);
		}

        /// <summary>
        /// Updates a Task record.
        /// </summary>
        /// <param name="model">The request body for the operation.</param>
        /// <returns>A <see cref="Task{ProfilixTask}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/ProfilixTask/Update-Task
        ///     {
        ///         TaskStatus: Complete
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the Task record.</response>
        /// <response code="404">Returns if the no Task Summary Records are found.</response>
		[HttpPut("Update-Task")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(ProfilixTask))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<ActionResult<List<ProfilixTask>>> UpdateProfilixTaskAsync(ProfilixTask model)
		{
			var task = await this.profilixTaskRepository.UpdateProfilixTaskAsync(model);
			if (task == null)
			{
				return this.BadRequest("Task not found");
			}
			else
			{
				return this.Ok(task);
			}
		}

        /// <summary>
        /// Deletes a Task record.
        /// </summary>
        /// <param name="id">The id for the task to delete.</param>
        /// <returns>A <see cref="Task{ProfilixTask}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/ProfilixTask/Delete-Task
        ///     {
        ///         Id: 7
        ///     }
        ///
        /// </remarks>
		[HttpDelete("Delete-Task/{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(ProfilixTask))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<ActionResult<List<ProfilixTask>>> DeleteProfilixTaskAsync(int id)
		{
			var task = await this.profilixTaskRepository.DeleteProfilixTaskAsync(id);
			return this.Ok(task);
		}
	}
}
