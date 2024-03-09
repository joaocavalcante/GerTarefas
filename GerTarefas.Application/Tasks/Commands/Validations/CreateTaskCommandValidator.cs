using FluentValidation;
using GerTarefas.Domain.Enum;

namespace GerTarefas.Application.Tasks.Commands.Validations;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(c => c.Title)
           .NotEmpty().WithMessage("[Title] deve ser informado");

        RuleFor(c => c.Description)
           .NotEmpty().WithMessage("[Description] deve ser informado");

        RuleFor(c => c.DueDate)
           .NotNull().WithMessage("[NotEmpty] deve ser informado");

        RuleFor(c => c.Priority)
           .NotNull().WithMessage("[Priority] deve ser informado");

        RuleFor(c => c.Comment)
           .NotEmpty().WithMessage("[Comment] deve ser informado");

        RuleFor(c => c.ProjectID)
           .NotNull().WithMessage("[ProjectID] deve ser informado");
    }
}
