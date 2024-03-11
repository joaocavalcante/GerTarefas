using GerTarefas.Domain.Enum;
using GerTarefas.Domain.Validation;
using System.Text.Json.Serialization;

namespace GerTarefas.Domain.Entities;

public sealed class LogTask
{
    public int LogID { get; set; }
    public DateTime? Date { get; set; }
    public string? History { get; set; }
    public string? Comment { get; set; }
    public StatusEnum? StatusTask { get; set; }
    public string UserName { get; set; }
    public int TaskID { get; set; }

    public LogTask() { }

    [JsonConstructor]
    public LogTask(DateTime date, string history, string comment, StatusEnum statusTask, string userName, int taskID)
    {
        ValidateDomain(date, history, comment, statusTask, userName, taskID);
    }

    private void ValidateDomain(DateTime date, string history, string comment, StatusEnum statusTask, string userName, int taskID)
    {
         DomainValidation.When(date.Equals(null),
            "[date] invalido");

        DomainValidation.When(string.IsNullOrEmpty(history),
            "[history] invalido");

        DomainValidation.When(string.IsNullOrEmpty(comment),
            "[comment] invalido");

        DomainValidation.When(statusTask.Equals(null),
            "[statusTask] value");

        DomainValidation.When(string.IsNullOrEmpty(userName),
            "[userName] invalido");

        DomainValidation.When(taskID <= 0,
            "[taskID] invalido");

        Date = date;
        History = history;
        Comment = comment;
        StatusTask = statusTask;
        UserName = userName;
        TaskID = taskID;
    }
}
