using GerTarefas.Domain.Validation;
using System.Text.Json.Serialization;

namespace GerTarefas.Domain.Entities;

public sealed class Project
{
    public int ProjectID { get; set; }
    public string? Name { get; set; }
    public DateTime? Date { get; set; }
    public string? UserName { get; set; }

    public Project() { }

    [JsonConstructor]
    public Project(string name, DateTime date, string userName)
    {
        ValidateDomain(name, date, userName);
    }

    public void Update(string name, DateTime date, string userName)
    {
        ValidateDomain(name, date, userName );
    }

    private void ValidateDomain(string name, DateTime date, string userName)
    {

        DomainValidation.When(string.IsNullOrEmpty(name),
            "[name] invalido");

        DomainValidation.When(date.Equals(null),
            "[date] invalido");

        DomainValidation.When(string.IsNullOrEmpty(userName),
            "[userName] invalido");

        //ProjectID = projectID;
        Name = name;
        Date = date;
        UserName = userName;    
    }
}
