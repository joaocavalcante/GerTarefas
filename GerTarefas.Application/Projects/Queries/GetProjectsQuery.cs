using GerTarefas.Domain.Abstractions;
using GerTarefas.Domain.Entities;
using MediatR;

namespace GerTarefas.Application.Projects.Queries;

public class GetTasksQuery : IRequest<IEnumerable<Project>>
{
    public string? UserName { get; set; }
    public class GetProjectsQueryHandler : IRequestHandler<GetTasksQuery, IEnumerable<Project>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProjectsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Project>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var projects = await _unitOfWork.ProjectRepository.GetProjects(request.UserName);
            return projects;
        }
    }
}
