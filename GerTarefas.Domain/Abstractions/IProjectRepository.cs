using GerTarefas.Domain.Entities;

namespace GerTarefas.Domain.Abstractions;

public interface IProjectRepository
{
    Task<Project> AddProject(Project project);
    void UpdateProject(Project project);
    Task<Project> DeleteProject(int projectId);
    Task<Project> GetProjectById(int projectId);
    Task<IEnumerable<Project>> GetProjects(string username);
}
