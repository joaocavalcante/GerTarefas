using GerTarefas.Domain.Enum;
using GerTarefas.Domain.Validation;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GerTarefas.Domain.Entities;

public sealed class LogTask
{
    public int LogID { get; set; }
    public DateTime? Date { get; set; }
    public string? Description { get; set; }
    public string? Comment { get; set; }
    public StatusEnum? StatusTask { get; set; }


    public int UserID { get; set; }
    public UserAccount? User { get; set; }

    public int TaskID { get; set; }
    public TaskProject? TaskProject { get; set; }

    public LogTask() { }

    [JsonConstructor]
    public LogTask(int logID, DateTime date, string description, string comment, StatusEnum statusTask, int userID, int taskID)
    {
        ValidateDomain(logID, date, description, comment, statusTask, userID, taskID);
    }

    private void ValidateDomain(int logID, DateTime date, string description, string comment, StatusEnum statusTask, int userID, int taskID)
    {
        DomainValidation.When(logID <= 0,
            "Invalid Id value.");

        DomainValidation.When(date.Equals(null),
            "Invalid dueDate value");

        DomainValidation.When(string.IsNullOrEmpty(description),
            "Invalid description value");

        DomainValidation.When(string.IsNullOrEmpty(comment),
            "Invalid comment value");

        DomainValidation.When(statusTask.Equals(null),
            "Invalid status value");

        DomainValidation.When(userID <= 0,
            "Invalid userID value.");

        DomainValidation.When(taskID <= 0,
            "Invalid taskID value.");

        LogID = logID;
        Date = date;
        Description = description;
        Comment = comment;
        StatusTask = statusTask;
        UserID = userID;
        TaskID = taskID;

    }
}
