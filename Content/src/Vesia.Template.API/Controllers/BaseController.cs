using Vesia.Result;
using Microsoft.AspNetCore.Mvc;

namespace Vesia.Template.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected IActionResult HandleResult<T>(Result<T> result) => result.IsSuccess
        ? Ok(result.Value)
        : result.Error!.ErrorType switch
        {
            ErrorType.NotFound => NotFound(result.Error.Message),
            ErrorType.Validation => BadRequest(result.Error.Message),
            ErrorType.Conflict => Conflict(result.Error.Message),
            ErrorType.Unauthorized => Unauthorized(result.Error.Message),
            ErrorType.Forbidden => Forbid(),
            _ => Problem(result.Error.Message)
        };
    
    protected IActionResult HandleCreatedResult<T>(Result<T> result, string actionName, object? routeValues = null) => result.IsSuccess
        ? CreatedAtAction(actionName, routeValues, result.Value)
        : result.Error!.ErrorType switch
        {
            ErrorType.NotFound => NotFound(result.Error.Message),
            ErrorType.Validation => BadRequest(result.Error.Message),
            ErrorType.Conflict => Conflict(result.Error.Message),
            ErrorType.Unauthorized => Unauthorized(result.Error.Message),
            ErrorType.Forbidden => Forbid(),
            _ => Problem(result.Error.Message)
        };
}