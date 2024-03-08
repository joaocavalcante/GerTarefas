using GerTarefas.Domain.Validation;
using System.Text.Json.Serialization;

namespace GerTarefas.Domain.Entities;

public sealed class Project
{
    public int ProjectID { get; set; }
    public string? Name { get; set; }
    public DateTime? Date { get; set; }
    public ICollection<Task>? Tasks { get; set; }


    [JsonConstructor]
    public Project(int projectid, string name, DateTime date)
    {
        ValidateDomain(projectid, name, date);
    }

    private void ValidateDomain(int projectID, string name, DateTime date)
    {
        DomainValidation.When(projectID <= 0,
            "Invalid Id value.");

        DomainValidation.When(string.IsNullOrEmpty(name),
            "Invalid name value");

        DomainValidation.When(date.Equals(null),
            "Invalid date value");

        ProjectID = projectID;
        Name = name;
        Date = date;
    }
}
