using Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected IActionResult HandleResult<T>(Result<T> result) => result.IsSuccess
        ? Ok(result.Value)
        : result.ErrorType switch
        {
            ErrorType.NotFound => NotFound(result.Error),
            ErrorType.Validation => BadRequest(result.Error),
            ErrorType.Conflict => Conflict(result.Error),
            ErrorType.Unauthorized => Unauthorized(result.Error),
            _ => Problem(result.Error)
        };
    
    protected IActionResult HandleCreatedResult<T>(Result<T> result, string actionName, object? routeValues = null) => result.IsSuccess
        ? CreatedAtAction(actionName, routeValues, result.Value)
        : result.ErrorType switch
        {
            ErrorType.NotFound => NotFound(result.Error),
            ErrorType.Validation => BadRequest(result.Error),
            ErrorType.Conflict => Conflict(result.Error),
            ErrorType.Unauthorized => Unauthorized(result.Error),
            _ => Problem(result.Error)
        };
}