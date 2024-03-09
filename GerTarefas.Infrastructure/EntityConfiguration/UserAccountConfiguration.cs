using GerTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerTarefas.Infrastructure.EntityConfiguration;

public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.HasKey(x => x.UserId);
        builder.Property(m => m.UserName).HasMaxLength(20).IsRequired();
        builder.Property(m => m.Function).HasMaxLength(20).IsRequired();
        builder.Property(m => m.Email).HasMaxLength(50).IsRequired();
        builder.Property(m => m.IsActive).IsRequired();

        builder.HasData(
            new UserAccount(1, "JoaoCavalcante", "Gerente", "jj@email.com", true),
            new UserAccount(2, "MariaLuiza", "Analista",  "ml@email.com", true)
            );
    }
}
