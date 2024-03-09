using GerTarefas.Domain.Abstractions;
using GerTarefas.Infrastructure.Context;
using GerTarefas.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Reflection;
using GerTarefas.Application.Common;

namespace GerTarefas.CrossCutting.AppDependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraStruture(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlConnection = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlConnection));

        // Registrar IDbConnection como uma instância única
        services.AddSingleton<IDbConnection>(provider =>
        {
            var connection = new SqlConnection(sqlConnection);
            connection.Open();
            return connection;
        });

        services.AddScoped<IUserAccountRepository, UserAccountRepository>(); 
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITaskProjectRepository, TaskProjectRepository>();
        services.AddScoped<ILogTaskRepository, LogTaskRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        var myhandlers = AppDomain.CurrentDomain.Load("GerTarefas.Application");
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(myhandlers);
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.Load("GerTarefas.Application"));

        return services;
    }
}