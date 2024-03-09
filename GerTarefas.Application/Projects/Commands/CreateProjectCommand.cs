using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using MediatR;

namespace GerTarefas.Application.Projects.Commands;

public class CreateProjectCommand : ProjectCommandBase
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Project>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        
        public CreateProjectCommandHandler(IUnitOfWork unitOfWork, IMediator mediator) 
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        public async Task<Project> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var newProject = new Project(request.Name, Convert.ToDateTime(request.Date));

            await _unitOfWork.ProjectRepository.AddProject(newProject);
            await _unitOfWork.CommitAsync();

            return newProject;
        }
    }
}
