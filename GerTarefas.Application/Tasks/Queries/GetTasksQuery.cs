using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using MediatR;

namespace GerTarefas.Application.Tasks.Queries;

public class GetTasksQuery : IRequest<IEnumerable<TaskProject>>
{
    public class GetTaskQueryHandler : IRequestHandler<GetTasksQuery, IEnumerable<TaskProject>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTaskQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<TaskProject>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _unitOfWork.TaskProjectRepository.GetTasks();
            return tasks;
        }
    }
}
