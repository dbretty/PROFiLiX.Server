using PROFiLiX.Web.Shared.ProfilixTaskRepositories;
using PROFiLiX.Web.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PROFiLiX.Web.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ProfilixTaskController : ControllerBase
	{
		private readonly IProfilixTaskRepository ProfilixTaskRepository;

		public ProfilixTaskController(IProfilixTaskRepository profilixTaskRepository)
		{
			this.ProfilixTaskRepository = profilixTaskRepository;
		}

		[HttpGet("All-Tasks")]
		public async Task<ActionResult<List<ProfilixTask>>> GetAllProfilixTasksAsync()
		{
			var tasks = await ProfilixTaskRepository.GetAllProfilixTasksAsync();
			return Ok(tasks);
		}

		[HttpGet("Single-Task/{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(ProfilixTask))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(string))]
        public async Task<ActionResult> GetSingleProfilixTaskAsync(int id)
		{
			var task = await ProfilixTaskRepository.GetProfilixTaskByIdAsync(id);
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
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(ProfilixTask))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<ActionResult> AddProfilixTaskAsync([FromBody] ProfilixTask model)
		{
			var task = await ProfilixTaskRepository.AddProfilixTaskAsync(model);
			return this.Ok(task);
		}

		[HttpPut("Update-Task")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(ProfilixTask))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<ActionResult<List<ProfilixTask>>> UpdateProfilixTaskAsync(ProfilixTask model)
		{
			var task = await ProfilixTaskRepository.UpdateProfilixTaskAsync(model);
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
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(ProfilixTask))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<ActionResult<List<ProfilixTask>>> DeleteProfilixTaskAsync(int id)
		{
			var task = await ProfilixTaskRepository.DeleteProfilixTaskAsync(id);
			return Ok(task);
		}
	}
}
