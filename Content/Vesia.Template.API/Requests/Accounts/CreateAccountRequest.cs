namespace Vesia.Template.API.Requests.Accounts;

public record CreateAccountRequest(string AccountName, string Email, string FirstName, string LastName);