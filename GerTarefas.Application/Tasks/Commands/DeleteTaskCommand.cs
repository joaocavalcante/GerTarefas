using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using MediatR;

namespace GerTarefas.Application.Tasks.Commands;

public class DeleteTaskCommand : IRequest<TaskProject>
{
    public int Id { get; set; }

    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, TaskProject>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TaskProject> Handle(DeleteTaskCommand request,
                     CancellationToken cancellationToken)
        {
            var deletedTask = await _unitOfWork.TaskProjectRepository.DeleteTask(request.Id);

            if (deletedTask is null)
                throw new InvalidOperationException("Tarefa náo encontrada");

            await _unitOfWork.CommitAsync();
            return deletedTask;
        }
    }
}

