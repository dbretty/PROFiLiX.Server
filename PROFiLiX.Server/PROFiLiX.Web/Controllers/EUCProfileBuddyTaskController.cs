using PROFiLiX.Web.Shared.EUCProfileBuddyTaskRepositories;
using PROFiLiX.Web.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PROFiLiX.Web.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class EUCProfileBuddyTaskController : ControllerBase
	{
		private readonly IEUCProfileBuddyTaskRepository eUCProfileBuddyTaskRepository;

		public EUCProfileBuddyTaskController(IEUCProfileBuddyTaskRepository eUCProfileBuddyTaskRepository)
		{
			this.eUCProfileBuddyTaskRepository = eUCProfileBuddyTaskRepository;
		}

		[HttpGet("All-Tasks")]
		public async Task<ActionResult<List<EUCProfileBuddyTask>>> GetAllEUCProfileBuddyTasksAsync()
		{
			var tasks = await eUCProfileBuddyTaskRepository.GetAllEUCProfileBuddyTasksAsync();
			return Ok(tasks);
		}

		[HttpGet("Single-Task/{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(EUCProfileBuddyTask))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(string))]
        public async Task<ActionResult> GetSingleEUCProfileBuddyTaskAsync(int id)
		{
			var task = await eUCProfileBuddyTaskRepository.GetEUCProfileBuddyTaskByIdAsync(id);
			if (task == null)
			{
				return this.NotFound("Task not found");
			}
			else
			{
				return Ok(task);
			}
		}

		[HttpPost("Add-Task")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(EUCProfileBuddyTask))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<ActionResult> AddEUCProfileBuddyTaskAsync([FromBody] EUCProfileBuddyTask model)
		{
			var task = await eUCProfileBuddyTaskRepository.AddEUCProfileBuddyTaskAsync(model);
			return this.Ok(task);
		}

		[HttpPut("Update-Task")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(EUCProfileBuddyTask))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<ActionResult<List<EUCProfileBuddyTask>>> UpdateEUCProfileBuddyTaskAsync(EUCProfileBuddyTask model)
		{
			var task = await eUCProfileBuddyTaskRepository.UpdateEUCProfileBuddyTaskAsync(model);
			if (task == null)
			{
				return this.BadRequest("Task not found");
			}
			else
			{
				return Ok(task);
			}
		}

		[HttpDelete("Delete-Task/{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(EUCProfileBuddyTask))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<ActionResult<List<EUCProfileBuddyTask>>> DeleteEUCProfileBuddyTaskAsync(int id)
		{
			var task = await eUCProfileBuddyTaskRepository.DeleteEUCProfileBuddyTaskAsync(id);
			return Ok(task);
		}
	}
}
