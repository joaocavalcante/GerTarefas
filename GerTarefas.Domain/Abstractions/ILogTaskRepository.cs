using GerTarefas.Domain.Entities;

namespace GerTarefas.Domain.Abstractions;

public interface ILogTaskRepository
{
    Task<LogTask> AddTask(LogTask logtask);
}
