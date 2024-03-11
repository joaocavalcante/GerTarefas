using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using GerTarefas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GerTarefas.Infrastructure.Repositories;

public class UserAccountRepository : IUserAccountRepository
{
    protected readonly AppDbContext db;

    public UserAccountRepository(AppDbContext _db)
    {
        this.db = _db;
    }

    public async Task<UserAccount> GetUserById(int userId)
    {
        var user = await db.UsersAccount.FindAsync(userId);
        if (user is null)
        {
            throw new InvalidOperationException("Regra:Usuário não encontrado");
        }
        return user;
    }

    public async Task<UserAccount> GetUserByName(string username)
    {
        var user = await db.UsersAccount.FirstOrDefaultAsync(c => c.UserName == username);
        if (user is null)
        {
            throw new InvalidOperationException("Regra:Usuário não encontrado");
        }
        return user;
    }
}
