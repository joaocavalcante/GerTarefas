using GerTarefas.Domain.Validation;
using System.Text.Json.Serialization;

namespace GerTarefas.Domain.Entities;

public sealed class UserAccount
{
    public int UserId { get; set; }
    public string? UserName { get; private set; }
    public string? Function { get; private set; }
    public string? Email { get; private set; }
    public bool? IsActive { get; private set; }

    public ICollection<LogTask>? LogsTasks { get; set; }

    public UserAccount() { }

    [JsonConstructor]
    public UserAccount(int userID, string username, string function, string email, bool? active)
    {
        ValidateDomain(userID, username, function, email, active);
    }

    private void ValidateDomain(int userID, string username, string function, string email, bool? active)
    {
        DomainValidation.When(userID <= 0,
            "Invalid Id value.");
        DomainValidation.When(string.IsNullOrEmpty(username),
            "Invalid name. UserName is required");

        DomainValidation.When(string.IsNullOrEmpty(function),
            "Invalid Function, Function is required");

        DomainValidation.When(string.IsNullOrEmpty(email),
            "Invalid email, E-Mail is required");

        DomainValidation.When(!active.HasValue,
            "Must define activity");

        UserId = userID;
        UserName = username;
        Function = function;
        Email = email;
        IsActive = active;
    }
}
