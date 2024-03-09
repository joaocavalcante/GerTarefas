using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using MediatR;

namespace GerTarefas.Application.Projects.Queries;

public class GetTasksQuery : IRequest<IEnumerable<Project>>
{
    public class GetProjectsQueryHandler : IRequestHandler<GetTasksQuery, IEnumerable<Project>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<IEnumerable<Project>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetProjects();
            return projects;
        }
    }
}
