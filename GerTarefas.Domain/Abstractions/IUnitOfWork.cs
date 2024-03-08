namespace GerTarefas.Domain.Abstractions;

public interface IUnitOfWork
{
    IUserAccountRepository UserAccountRepository { get; }
    Task CommitAsync();
}