using GerTarefas.Domain.Entities;
using GerTarefas.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerTarefas.Infrastructure.EntityConfiguration;

public class LogTaskConfiguration : IEntityTypeConfiguration<LogTask>
{
    public void Configure(EntityTypeBuilder<LogTask> builder)
    {
        builder.HasKey(x => x.LogID);
        builder.Property(m => m.Date).IsRequired();
        builder.Property(m => m.History).HasMaxLength(500).IsRequired();
        builder.Property(m => m.Comment).HasMaxLength(500).IsRequired();
        builder.Property(m => m.StatusTask).IsRequired();
        builder.Property(m => m.UserName).IsRequired();
        builder.Property(m => m.TaskID).IsRequired();
    }
}
