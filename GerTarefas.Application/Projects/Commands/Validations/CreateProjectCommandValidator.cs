using FluentValidation;

namespace GerTarefas.Application.Projects.Commands.Validations;

public class CreateTaskCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(c => c.Name)
          .NotEmpty().WithMessage("[Name] deve ser informado");

        RuleFor(c => c.Date)
           .NotNull().WithMessage("[Date] deve ser informada");
    }
}
