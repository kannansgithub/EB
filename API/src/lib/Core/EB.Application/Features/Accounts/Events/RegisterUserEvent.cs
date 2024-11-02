using MediatR;

namespace EB.Application.Features.Accounts.Events;

public class RegisterUserEvent(
    string email,
    string? firstName,
    string? lastName,
    string? emailConfirmationToken,
    bool sendEmailConfirmation,
    string host) : INotification
{
    public string Email { get; } = email;
    public string? FirstName { get; } = firstName;
    public string? LastName { get; } = lastName;
    public string? EmailConfirmationToken { get; } = emailConfirmationToken;
    public bool SendEmailConfirmation { get; } = sendEmailConfirmation;
    public string Host { get; } = host;
}

