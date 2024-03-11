using GerTarefas.Domain.Entities;

namespace GerTarefas.Domain.Abstractions;

public interface IUserAccountRepository
{
    Task<UserAccount> GetUserById(int userId);
    Task<UserAccount> GetUserByName(string username);
}
