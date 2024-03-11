using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using GerTarefas.Domain.Enum;
using MediatR;

namespace GerTarefas.Application.Tasks.Commands;

public class CreateTaskCommand : IRequest<TaskProject>
{
    public string? UserName { get; set; }
    public int ProjectID { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public StatusEnum? Status { get; set; }
    public PrioriryEnum? Priority { get; set; }
    public string? Comment { get; set; }
    
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
            var userAccount = await _unitOfWork.UserAccountRepository.GetUserByName(request.UserName); // Apenas para verificar existencia de usuário

            var tasks = await _unitOfWork.TaskProjectRepository.GetTasksByProjectId(request.ProjectID);
            if (tasks.Count() == 20) 
            {
                throw new InvalidOperationException("Regra:O Projeto atingiu o número máximo de tarefas, não é possivel adicionar mais.");
            }

            var newTask = new TaskProject(request.Title,
                                        request.Description,
                                        Convert.ToDateTime(request.DueDate),
                                        (StatusEnum)request.Status,
                                        (PrioriryEnum)request.Priority,
                                        request.Comment,
                                        request.ProjectID,
                                        request.UserName);
            await _unitOfWork.TaskProjectRepository.AddTask(newTask);
            await _unitOfWork.CommitAsync();

            return newTask;
        }
    }
}
