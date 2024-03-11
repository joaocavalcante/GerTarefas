using GerTarefas.Application.Tasks.Commands;
using GerTarefas.Application.Tasks.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GerTarefas.API.Controllers;

[Route("[controller]")]
[ApiController]
public class TarefasController : ControllerBase
{
    private readonly IMediator _mediator;

    public TarefasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Listar Tarefas", Description = "Lista todas as Tarefas.")]
    public async Task<IActionResult> GetTasks()
    {
        var query = new GetTasksQuery();
        var tasks = await _mediator.Send(query);
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Retornar Tarefa", Description = "Retorna um determinada tarefa.")]
    public async Task<IActionResult> GetTask(int id)
    {
        var query = new GetTaskByIdQuery { Id = id };
        var member = await _mediator.Send(query);

        return member != null ? Ok(member) : NotFound("Tarefa não encontrada.");
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Criar Tarefa", Description = "Adiciona uma nova tarefa a um projeto.")]
    public async Task<IActionResult> CreateTask(CreateTaskCommand command)
    {
        var createdtask = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetTask), new { id = createdtask.TaskID }, createdtask);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualizar Tarefa", Description = "Atualiza o status ou detalhes de uma tarefa.")]
    public async Task<IActionResult> UpdateTask(int id, UpdateTaskCommand command)
    {
        command.Id = id;
        var updatedtask = await _mediator.Send(command);

        return updatedtask != null ? Ok(updatedtask) : NotFound("Tarefa não encontrada.");
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Remover Tarefa", Description = "Remove um tarefa de um projeto.")]
    public async Task<IActionResult> DeleteTask(int id, string username)
    {
        var command = new DeleteTaskCommand { Id = id, UserName = username };
        var deletedtask = await _mediator.Send(command);

        return deletedtask != null ? Ok(deletedtask) : NotFound("Tarefa não encontrada.");
    }
}
