using GerTarefas.Domain.Entities;

namespace GerTarefas.Domain.Abstractions;

public interface ITaskProjectRepository
{
    Task<TaskProject> AddTask(TaskProject task);
    void UpdateTask(TaskProject task);
    Task<TaskProject> DeleteTask(int taskId);
    Task<TaskProject> GetTaskById(int taskId);
    Task<IEnumerable<TaskProject>> GetTasks();
    Task<IEnumerable<TaskProject>> GetTasksByProjectId(int projectID);
}
