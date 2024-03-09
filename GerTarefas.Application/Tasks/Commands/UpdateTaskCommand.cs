using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using GerTarefas.Domain.Enum;
using MediatR;

namespace GerTarefas.Application.Tasks.Commands;

public class UpdateTaskCommand : IRequest<TaskProject>
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public StatusEnum? Status { get; set; }
    public string? Comment { get; set; }

    public class UpdateProjectCommandHandler : IRequestHandler<UpdateTaskCommand, TaskProject>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TaskProject> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var existingTask = await _unitOfWork.TaskProjectRepository.GetTaskById(request.Id);

            if (existingTask is null)
                throw new InvalidOperationException("Tarefa não encontrada");

            existingTask.Update(request.Description, (StatusEnum) request.Status, request.Comment);
            _unitOfWork.TaskProjectRepository.UpdateTask(existingTask);
            await _unitOfWork.CommitAsync();

            return existingTask;
        }
    }
}
