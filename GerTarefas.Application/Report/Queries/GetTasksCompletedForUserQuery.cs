using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GerTarefas.Application.Report.Queries;

public class GetTasksCompletedForUserQuery : IRequest<List<string>>
{
    public string? UserName { get; set; }

    public class GetTasksCompletedForUserQueryHandler : IRequestHandler<GetTasksCompletedForUserQuery, List<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTasksCompletedForUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<string>> Handle(GetTasksCompletedForUserQuery request, CancellationToken cancellationToken)
        {
            var userAccount = await _unitOfWork.UserAccountRepository.GetUserByName(request.UserName);
            if (userAccount.Function.ToLower()  != "gerente")
            {
                throw new InvalidOperationException("Regra:Usuário não tem permissões para visualisar dados.");
            }

            var taskUsers = await _unitOfWork.LogTaskRepository.GetTasksCompleted();

            var userTasks =
                from user in taskUsers
                group user by user.UserName into userGroup
                select new
                {
                    Name = userGroup.Key,
                    CountTask = userGroup.Count(),
                };

            List<string> report = new List<string>();
            foreach ( var user in userTasks)
            {
                report.Add($"{user.Name} - {user.CountTask}");
            }
            return report;
            
        }
    }
}
