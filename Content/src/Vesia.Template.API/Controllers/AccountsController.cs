using Vesia.Template.Application.Features.Accounts.Commands;
using Vesia.Template.Application.Features.Accounts.Queries;
using Microsoft.AspNetCore.Mvc;
using Vesia.Dispatch.Interfaces;
using Vesia.Template.API.Requests.Accounts;


namespace Vesia.Template.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AccountsController(IDispatcher dispatcher) : BaseController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAccountsAsync(CancellationToken cancellationToken)
    {
        var query = new GetAllAccountsQuery();

        var result = await dispatcher.DispatchAsync(query, cancellationToken);

        return HandleResult(result);
    }
    
    [HttpGet("{accountGuid:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAccountByUidAsync([FromRoute] Guid accountGuid, CancellationToken cancellationToken)
    {
        var query = new GetAccountByUidQuery(accountGuid);

        var result = await dispatcher.DispatchAsync(query, cancellationToken);

        return HandleResult(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAccountAsync([FromBody] CreateAccountRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateAccountCommand(request.AccountName, request.Email, request.FirstName, request.LastName);

        var result = await dispatcher.DispatchAsync(command, cancellationToken);

        return HandleCreatedResult(result, nameof(GetAccountByUidAsync), new { accountGuid = result.Value });
    }
}