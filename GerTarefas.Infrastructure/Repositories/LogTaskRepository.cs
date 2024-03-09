using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using GerTarefas.Infrastructure.Context;

namespace GerTarefas.Infrastructure.Repositories;

public class LogTaskRepository : ILogTaskRepository
{
    protected readonly AppDbContext db;

    public LogTaskRepository(AppDbContext _db)
    {
        this.db = _db;
    }
    public async Task<LogTask> AddTask(LogTask logtask)
    {
        if (logtask is null)
        {
            throw new ArgumentNullException(nameof(logtask));
        }
        await db.LogTasks.AddAsync(logtask);
        return logtask;
    }
}
