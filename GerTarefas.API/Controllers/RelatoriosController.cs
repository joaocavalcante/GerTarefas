using GerTarefas.Application.Report.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GerTarefas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RelatoriosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("User/{username}")]
        [SwaggerOperation(Summary = "Relatório de Desempenho", Description = "Retorna a quantidade de tarefas concluidas por usuário nos ultimos 30 dias.")]
        public async Task<IActionResult> GetTasks(string username)
        {
            var query = new GetTasksCompletedForUserQuery { UserName = username };
            var userTasks = await _mediator.Send(query);
            return Ok(userTasks);
        }
    }
}
