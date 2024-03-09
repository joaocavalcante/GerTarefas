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
            var existingProject = await _unitOfWork.ProjectRepository.GetProjectById(request.Id);

            if (existingProject is null)
                throw new InvalidOperationException("Project not found");

            existingProject.Update(request.Name, Convert.ToDateTime(request.Date));
            _unitOfWork.ProjectRepository.UpdateProject(existingProject);
            await _unitOfWork.CommitAsync();

            return existingProject;
        }
    }
}
