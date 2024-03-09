using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using MediatR;

namespace GerTarefas.Application.Tasks.Queries;

public class GetTasksQuery : IRequest<IEnumerable<TaskProject>>
{
    public class GetTaskQueryHandler : IRequestHandler<GetTasksQuery, IEnumerable<TaskProject>>
    {
        private readonly ITaskProjectRepository _taskProjectRepository;

        public GetTaskQueryHandler(ITaskProjectRepository taskProjectRepository)
        {
            _taskProjectRepository = taskProjectRepository;
        }
        public async Task<IEnumerable<TaskProject>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskProjectRepository.GetTasks();
            return tasks;
        }
    }
}
