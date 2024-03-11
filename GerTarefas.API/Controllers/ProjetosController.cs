using GerTarefas.Application.Projects.Commands;
using GerTarefas.Application.Projects.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GerTarefas.API.Controllers;

[Route("[controller]")]
[ApiController]
public class ProjetosController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjetosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("User/{username}")]
    [SwaggerOperation(Summary = "Listar Projetos", Description = "Lista todos os projetos do usuário.")]
    public async Task<IActionResult> GetProjects(string username)
    {
        var query = new GetTasksQuery { UserName = username };
        var projects = await _mediator.Send(query);
        return Ok(projects);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Retornar Projeto", Description = "Retorna um determinado Projeto.")]
    public async Task<IActionResult> GetProject(int id)
    {
        var query = new GetTaskByIdQuery { Id = id };
        var member = await _mediator.Send(query);

        return member != null ? Ok(member) : NotFound("Projeto não encontrado.");
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Criar Projeto", Description = "Cria um novo projeto")]
    public async Task<IActionResult> CreateProject(CreateProjectCommand command)
    {
        var createdProject = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetProject), new { id = createdProject.ProjectID }, createdProject);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Remover Projeto", Description = "Remove um determinado projeto")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var command = new DeleteTaskCommand { Id = id };
        var deletedProject = await _mediator.Send(command);

        return deletedProject != null ? Ok(deletedProject) : NotFound("Projeto não encontrado.");
    }
}
