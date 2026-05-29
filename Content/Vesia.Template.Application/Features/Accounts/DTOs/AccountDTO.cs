namespace Vesia.Template.Application.Features.Accounts.DTOs;

public record AccountDTO(
    Guid Uid,
    string Username,
    string Email,
    string FirstName,
    string LastName,
    DateTime? ValidTo
);