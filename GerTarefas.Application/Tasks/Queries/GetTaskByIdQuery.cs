using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using MediatR;

namespace GerTarefas.Application.Tasks.Queries;

public class GetTaskByIdQuery : IRequest<TaskProject>
{
    public int Id { get; set; }

    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskProject>
    {
        private readonly ITaskProjectRepository _taskProjectRepository;

        public GetTaskByIdQueryHandler(ITaskProjectRepository taskProjectRepository)
        {
            _taskProjectRepository = taskProjectRepository;
        }
        public async Task<TaskProject> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskProjectRepository.GetTaskById(request.Id);
            return task;
        }
    }
}
