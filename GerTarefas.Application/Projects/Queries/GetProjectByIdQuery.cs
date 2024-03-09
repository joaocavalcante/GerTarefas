using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using MediatR;

namespace GerTarefas.Application.Projects.Queries;

public class GetTaskByIdQuery : IRequest<Project>
{
    public int Id { get; set; }

    public class GetProjectByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Project>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Project> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var Project = await _projectRepository.GetProjectById(request.Id);
            return Project;
        }
    }
}
