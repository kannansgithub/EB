using MediatR;

namespace EB.Application.Features.Accounts.Events;

public class ForgotPasswordEvent(
    string email,
    string tempPassword,
    string? emailConfirmationToken,
    string host,
    string clearTempPassword) : INotification
{
    public string Email { get; } = email;
    public string TempPassword { get; } = tempPassword;
    public string ClearTempPassword { get; } = clearTempPassword;
    public string? EmailConfirmationToken { get; } = emailConfirmationToken;
    public string Host { get; } = host;
}
