using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using MediatR;

namespace GerTarefas.Application.Projects.Commands;

public class DeleteTaskCommand : IRequest<Project>
{
    public int Id { get; set; }

    public class DeleteProjectCommandHandler : IRequestHandler<DeleteTaskCommand, Project>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Project> Handle(DeleteTaskCommand request,
                     CancellationToken cancellationToken)
        {
            var deletedProject = await _unitOfWork.ProjectRepository.DeleteProject(request.Id);

            if (deletedProject is null)
                throw new InvalidOperationException("Project not found");

            await _unitOfWork.CommitAsync();
            return deletedProject;
        }
    }
}

