using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using GerTarefas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GerTarefas.Infrastructure.Repositories;

public class TaskProjectRepository : ITaskProjectRepository
{
    protected readonly AppDbContext db;

    public TaskProjectRepository(AppDbContext _db)
    {
        this.db = _db;
    }

    public async Task<TaskProject> AddTask(TaskProject task)
    {
        if (task is null)
        {
            throw new ArgumentNullException(nameof(task));
        }
        await db.TasksProject.AddAsync(task);
        return task;
    }

    public async Task<TaskProject> DeleteTask(int taskId)
    {
        var task = await GetTaskById(taskId);
        if (task is null)
        {
            throw new InvalidOperationException("Task not found");
        }
        db.TasksProject.Remove(task);
        return task;
    }

    public async Task<TaskProject> GetTaskById(int taskId)
    {
        var task = await db.TasksProject.FindAsync(taskId);
        if (task is null)
        {
            throw new InvalidOperationException("Task not found");
        }
        return task;
    }

    public async Task<IEnumerable<TaskProject>> GetTasks()
    {
        var taskList = await db.TasksProject.ToListAsync();
        return taskList ?? Enumerable.Empty<TaskProject>();
    }

    public void UpdateTask(TaskProject task)
    {
        if (task is null)
        {
            throw new ArgumentNullException(nameof(task));
        }
        db.TasksProject.Update(task);
    }
}
