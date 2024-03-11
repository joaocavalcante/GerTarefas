using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using MediatR;

namespace GerTarefas.Application.Tasks.Queries;

public class GetTaskByIdQuery : IRequest<TaskProject>
{
    public int Id { get; set; }

    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskProject>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTaskByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TaskProject> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.TaskProjectRepository.GetTaskById(request.Id);
            return task;
        }
    }
}
