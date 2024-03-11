using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using GerTarefas.Domain.Enum;
using MediatR;

namespace GerTarefas.Application.Tasks.Commands;

public class DeleteTaskCommand : IRequest<TaskProject>
{
    public string? UserName { get; set; }
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
            var userAccount = await _unitOfWork.UserAccountRepository.GetUserByName(request.UserName); // Apenas para verificar existencia de usuário

            var deletedTask = await _unitOfWork.TaskProjectRepository.DeleteTask(request.Id);

            if (deletedTask is null)
                throw new InvalidOperationException("Regra:Tarefa náo encontrada");

            // insere histórico
            var dellog = new LogTask(DateTime.Now, "Tarefa excluída", deletedTask.Comment, (StatusEnum)deletedTask.Status, request.UserName, request.Id);
            await _unitOfWork.LogTaskRepository.AddLog(dellog);

            await _unitOfWork.CommitAsync();
            return deletedTask;
        }
    }
}

