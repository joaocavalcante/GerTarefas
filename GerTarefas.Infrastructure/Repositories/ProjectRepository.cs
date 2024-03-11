using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using GerTarefas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GerTarefas.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    protected readonly AppDbContext db;

    public ProjectRepository(AppDbContext _db)
    {
        this.db = _db;
    }

    public async Task<Project> AddProject(Project project)
    {
        if (project is null)
        {
            throw new ArgumentNullException(nameof(project));
        }
        await db.Projects.AddAsync(project);
        return project;
    }

    public async Task<Project> DeleteProject(int projectId)
    {
        var project = await GetProjectById(projectId);
        if (project is null)
        {
            throw new KeyNotFoundException("Projeto não encontrado");
        }

        db.Projects.Remove(project);
        return project;
    }

    public async Task<Project> GetProjectById(int projectId)
    {
        var project = await db.Projects.FindAsync(projectId);
        if (project is null)
        {
            throw new KeyNotFoundException("Projeto não encontrado");
        }
        return project;
    }

    public async Task<IEnumerable<Project>> GetProjects(string username)
    {
        var projectist = await db.Projects.Where(c=>c.UserName == username).ToListAsync();
        return projectist ?? Enumerable.Empty<Project>();
    }

    public void UpdateProject(Project project)
    {
        if (project is null)
        {
            throw new ArgumentNullException(nameof(project));
        }
        db.Projects.Update(project);
    }
}
