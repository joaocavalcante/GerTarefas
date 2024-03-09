using GerTarefas.Domain.Entities;
using GerTarefas.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace GerTarefas.Infrastructure.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<UserAccount> UsersAccount { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskProject> TasksProject { get; set; }
    public DbSet<LogTask> LogTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new TaskProjectConfiguration());
        modelBuilder.ApplyConfiguration(new LogTaskConfiguration());
    }

}
