using GerTarefas.Domain.Entities;

namespace GerTarefas.Domain.Abstractions;

public interface ILogTaskRepository
{
    Task<LogTask> AddLog(LogTask logtask);
    Task<IEnumerable<LogTask>> GetTasksCompleted();
}
