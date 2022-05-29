using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Notion.Integration.API.Controllers
{
    public abstract class MainController : ControllerBase
    {
        protected ICollection<string> ErrorList = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]> {
                {"Mensagens", ErrorList.ToArray() }
            }));
        }

        protected bool ValidOperation()
        {
            return !ErrorList.Any();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AddErrorProcessing(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected void AddErrorProcessing(string erro)
        {
            ErrorList.Add(erro);
        }
    }
}
