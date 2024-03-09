namespace GerTarefas.Domain.Abstractions;

public interface IUnitOfWork
{
    IUserAccountRepository UserAccountRepository { get; }
    IProjectRepository ProjectRepository { get; }
    ITaskProjectRepository TaskProjectRepository { get; }
    ILogTaskRepository LogTaskRepository { get; }
    Task CommitAsync();
}