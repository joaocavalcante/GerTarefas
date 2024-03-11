using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using MediatR;

namespace GerTarefas.Application.Projects.Queries;

public class GetTaskByIdQuery : IRequest<Project>
{
    public int Id { get; set; }

    public class GetProjectByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Project>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProjectByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Project> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var Project = await _unitOfWork.ProjectRepository.GetProjectById(request.Id);
            return Project;
        }
    }
}
