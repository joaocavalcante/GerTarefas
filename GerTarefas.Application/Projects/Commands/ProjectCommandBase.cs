﻿using GerTarefas.Domain.Entities;
using MediatR;

namespace GerTarefas.Application.Projects.Commands;

public class ProjectCommandBase : IRequest<Project>
{
    public string? UserName { get; set; }
    public string? Name { get; set; }
    public DateTime? Date { get; set; }
}
