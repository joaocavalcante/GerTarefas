using GerTarefas.Domain.Entities;
using GerTarefas.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerTarefas.Infrastructure.EntityConfiguration;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(x => x.ProjectID);
        builder.Property(m => m.Name).HasMaxLength(50).IsRequired();
        builder.Property(m => m.Date).IsRequired();
    }
}
