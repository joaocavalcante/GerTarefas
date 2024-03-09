using GerTarefas.Domain.Entities;
using GerTarefas.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerTarefas.Infrastructure.EntityConfiguration;

public class TaskProjectConfiguration : IEntityTypeConfiguration<TaskProject>
{
    public void Configure(EntityTypeBuilder<TaskProject> builder)
    {
        builder.HasKey(x => x.TaskID);
        builder.Property(m => m.Title).HasMaxLength(50).IsRequired();
        builder.Property(m => m.Description).HasMaxLength(100).IsRequired();
        builder.Property(m => m.DueDate).IsRequired();
        builder.Property(m => m.Status).IsRequired();
        builder.Property(m => m.Priority).IsRequired();
        builder.Property(m => m.Comment).HasMaxLength(500).IsRequired();
        builder.Property(m => m.ProjectID).IsRequired();
    }
}
