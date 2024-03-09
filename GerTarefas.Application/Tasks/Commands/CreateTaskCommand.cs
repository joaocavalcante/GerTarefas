using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using GerTarefas.Domain.Enum;
using MediatR;

namespace GerTarefas.Application.Tasks.Commands;

public class CreateTaskCommand : IRequest<TaskProject>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public StatusEnum? Status { get; set; }
    public PrioriryEnum? Priority { get; set; }
    public string? Comment { get; set; }
    public int ProjectID { get; set; }

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskProject>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        public async Task<TaskProject> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var newTask = new TaskProject(request.Title,
                                        request.Description,
                                        Convert.ToDateTime(request.DueDate),
                                        (StatusEnum)request.Status,
                                        (PrioriryEnum)request.Priority,
                                        request.Comment,
                                        request.ProjectID);
            await _unitOfWork.TaskProjectRepository.AddTask(newTask);
            await _unitOfWork.CommitAsync();

            return newTask;
        }
    }
}
