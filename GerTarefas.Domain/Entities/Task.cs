using GerTarefas.Domain.Enum;
using GerTarefas.Domain.Validation;
using System.Text.Json.Serialization;

namespace GerTarefas.Domain.Entities;

public sealed class Task
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


    [JsonConstructor]
    public Task(int taskID, string title, string description, DateTime dueDate, StatusEnum status, PrioriryEnum priority, string comment)
    {
        ValidateDomain(taskID, title, description, dueDate, status, priority, comment);
    }

    private void ValidateDomain(int taskID, string title, string description, DateTime dueDate, StatusEnum status, PrioriryEnum priority, string comment)
    {
        DomainValidation.When(taskID <= 0,
            "Invalid Id value.");

        DomainValidation.When(string.IsNullOrEmpty(title),
            "Invalid title value");

        DomainValidation.When(string.IsNullOrEmpty(description),
            "Invalid description value");

        DomainValidation.When(dueDate.Equals(null),
            "Invalid dueDate value");

        DomainValidation.When(status.Equals(null),
            "Invalid status value");

        DomainValidation.When(priority.Equals(null),
            "Invalid priority value");

        TaskID = taskID;
        Title = title;
        Description = description;
        DueDate = dueDate;
        Status = status;
        Priority = priority;
        Comment = comment;

    }

}
