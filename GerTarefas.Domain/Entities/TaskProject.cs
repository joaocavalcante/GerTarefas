using GerTarefas.Domain.Enum;
using GerTarefas.Domain.Validation;
using System.Text.Json.Serialization;

namespace GerTarefas.Domain.Entities;

public sealed class TaskProject
{
    public int TaskID { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public StatusEnum? Status { get; set; }
    public PrioriryEnum? Priority { get; set; }
    public string? Comment { get; set; }

    public int ProjectID { get; set; }
    public Project? Project { get; set; }

    public ICollection<LogTask>? LogTasks { get; set; }

    public TaskProject() { }

    [JsonConstructor]
    public TaskProject(string title, string description, DateTime dueDate, StatusEnum status, PrioriryEnum priority, string comment, int projectID)
    {
        ValidateDomain(title, description, dueDate, status, priority, comment, projectID);
    }

    public void Update(string description, StatusEnum status, string comment)
    {
        ValidateForUpdateDomain(description, status, comment);
    }

    private void ValidateDomain(string title, string description, DateTime dueDate, StatusEnum status, PrioriryEnum priority, string comment, int projectID)
    {
        DomainValidation.When(string.IsNullOrEmpty(title),
            "[title] invalido");

        DomainValidation.When(string.IsNullOrEmpty(description),
            "[description] invalido");

        DomainValidation.When(dueDate.Equals(null),
            "[dueDate] invalido");

        DomainValidation.When(status.Equals(null),
            "[status] invalido");

        DomainValidation.When(priority.Equals(null),
            "[priority] invalido");

        DomainValidation.When(string.IsNullOrEmpty(comment),
            "[comment] invalido");

        DomainValidation.When(projectID <= 0, "[projectID] invalido.");

        Title = title;
        Description = description;
        DueDate = dueDate;
        Status = status;
        Priority = priority;
        Comment = comment;
        ProjectID = projectID;
    }

    private void ValidateForUpdateDomain(string description, StatusEnum status, string comment)
    {
        DomainValidation.When(string.IsNullOrEmpty(description),
            "[description] invalido");

        DomainValidation.When(status.Equals(null),
            "[status] invalido");

        DomainValidation.When(string.IsNullOrEmpty(comment),
            "[comment] invalido");

        Description = description;
        Status = status;
        Comment = comment;
    }

}
