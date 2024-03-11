using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using GerTarefas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GerTarefas.Infrastructure.Repositories;

public class LogTaskRepository : ILogTaskRepository
{
    protected readonly AppDbContext db;

    public LogTaskRepository(AppDbContext _db)
    {
        this.db = _db;
    }
    public async Task<LogTask> AddLog(LogTask logtask)
    {
        if (logtask is null)
        {
            throw new ArgumentNullException(nameof(logtask));
        }
        await db.LogTasks.AddAsync(logtask);
        return logtask;
    }

    public async Task<IEnumerable<LogTask>> GetTasksCompleted()
    {
        var taskList = await db.LogTasks.Where(c => c.StatusTask == Domain.Enum.StatusEnum.CONCLUIDA && c.Date >= DateTime.Now.AddDays(-30) ).ToListAsync();
        return taskList ?? Enumerable.Empty<LogTask>();
    }

}
