using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using MediatR;

namespace GerTarefas.Application.Projects.Commands;

public class UpdateProjectCommand : ProjectCommandBase
{
    public int Id { get; set; }

    public class UpdateProjectCommandHandler :
                  IRequestHandler<UpdateProjectCommand, Project>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Project> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var userAccount = await _unitOfWork.UserAccountRepository.GetUserByName(request.UserName); // Apenas para verificar existencia de usuário

            var existingProject = await _unitOfWork.ProjectRepository.GetProjectById(request.Id);

            if (existingProject is null)
                throw new InvalidOperationException("Regra:Projeto não encontrado");

            existingProject.Update(request.Name, Convert.ToDateTime(request.Date), request.UserName);
            _unitOfWork.ProjectRepository.UpdateProject(existingProject);
            await _unitOfWork.CommitAsync();

            return existingProject;
        }
    }
}
