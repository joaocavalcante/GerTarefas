using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using GerTarefas.Domain.Enum;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GerTarefas.Application.Tasks.Commands;

public class UpdateTaskCommand : IRequest<TaskProject>
{
    public string? UserName { get; set; }
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
            var userAccount = await _unitOfWork.UserAccountRepository.GetUserByName(request.UserName); // Apenas para verificar existencia de usuário

            var existingTask = await _unitOfWork.TaskProjectRepository.GetTaskById(request.Id);

            if (existingTask is null)
                throw new InvalidOperationException("Regra:Tarefa não encontrada");

            // registrar de alterações
            var history = "";
            if (request.Description != existingTask.Description)
                history += $"Campo [Description] foi alterado de [{existingTask.Description}] para [{request.Description}]\n";
            if (request.Status != existingTask.Status)
                history += $"Campo [Status] foi alterado de [{existingTask.Status}] para [{request.Status}]\n";

            // Atualiza task
            existingTask.Update(request.Description, (StatusEnum) request.Status, request.Comment, request.UserName);
            _unitOfWork.TaskProjectRepository.UpdateTask(existingTask);

            // insere histórico
            var newlog = new LogTask(DateTime.Now, history, request.Comment, (StatusEnum)request.Status, request.UserName, request.Id);
            await _unitOfWork.LogTaskRepository.AddLog(newlog);

            await _unitOfWork.CommitAsync();

            return existingTask;
        }
    }
}
