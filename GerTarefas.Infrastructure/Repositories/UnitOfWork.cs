using GerTarefas.Domain.Abstractions;
using GerTarefas.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerTarefas.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IUserAccountRepository? _userRepo;
    private IProjectRepository? _projectRepo;
    private ITaskProjectRepository? _taskRepo;
    private ILogTaskRepository? _logRepo;

    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IUserAccountRepository UserAccountRepository
    {
        get
        {
            return _userRepo = _userRepo ?? new UserAccountRepository(_context);
        }
    }

    public IProjectRepository ProjectRepository
    {
        get
        {
            return _projectRepo = _projectRepo ?? new ProjectRepository(_context);
        }
    }

    public ITaskProjectRepository TaskProjectRepository
    {
        get
        {
            return _taskRepo = _taskRepo ?? new TaskProjectRepository(_context);
        }
    }

    public ILogTaskRepository LogTaskRepository
    {
        get
        {
            return _logRepo = _logRepo ?? new LogTaskRepository(_context);
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
