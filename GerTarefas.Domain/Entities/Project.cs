using GerTarefas.Domain.Validation;
using System.Text.Json.Serialization;

namespace GerTarefas.Domain.Entities;

public sealed class Project
{
    public int ProjectID { get; set; }
    public string? Name { get; set; }
    public DateTime? Date { get; set; }
    public ICollection<TaskProject>? TaskProjects { get; set; }

    public Project() { }

    [JsonConstructor]
    public Project(string name, DateTime date)
    {
        ValidateDomain(name, date);
    }

    public void Update(string name, DateTime date)
    {
        ValidateDomain(name, date);
    }

    private void ValidateDomain(string name, DateTime date)
    {

        DomainValidation.When(string.IsNullOrEmpty(name),
            "[name] invalido");

        DomainValidation.When(date.Equals(null),
            "[date] invalido");

        //ProjectID = projectID;
        Name = name;
        Date = date;
    }
}
