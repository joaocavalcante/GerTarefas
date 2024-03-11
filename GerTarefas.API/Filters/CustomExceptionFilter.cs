using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GerTarefas.API.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is FluentValidation.ValidationException validationException)
        {
            var errors = validationException.Errors
                .Select(error => $"{error.PropertyName}: {error.ErrorMessage}")
                .ToList();

            var result = new ObjectResult(new { Errors = errors })
            {
                StatusCode = StatusCodes.Status400BadRequest,
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
        else if (context.Exception is ArgumentNullException || context.Exception is KeyNotFoundException)
        {
            // Tratar erro 404 (Não Encontrado)
            context.Result = new NotFoundObjectResult(new { Error = $"{context.Exception.Message}" });
            context.ExceptionHandled = true;
        }
        else if (context.Exception is HttpRequestException ||
                 context.Exception is InvalidOperationException)
        {
            if (context.Exception.Message.IndexOf("Regra:") >= 0)
            {
                var result = new ObjectResult(new { Errors = context.Exception.Message.Replace("Regra:","") })
                {
                    StatusCode = StatusCodes.Status400BadRequest, 
                };

                context.Result = result;
                context.ExceptionHandled = true;
            }
            else
            {
                // Tratar erro 500 (Erro Interno do Servidor)
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                context.ExceptionHandled = true;
            }
        }
    }
}