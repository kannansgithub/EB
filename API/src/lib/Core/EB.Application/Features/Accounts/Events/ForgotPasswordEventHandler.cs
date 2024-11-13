using EB.Application.Services.Externals;
using MediatR;
using System.Text.Encodings.Web;

namespace EB.Application.Features.Accounts.Events;

public class ForgotPasswordEventHandler(IEmailService emailService) : INotificationHandler<ForgotPasswordEvent>
{
    private readonly IEmailService _emailService = emailService;

    public async Task Handle(ForgotPasswordEvent notification, CancellationToken cancellationToken)
    {

        Console.WriteLine($"Handling event for: {notification.Email}. Sending email confirmation");

        var callbackUrl = $"{notification.Host}/Accounts/ForgotPasswordConfirmation?email={notification.Email}&code={notification.EmailConfirmationToken}&tempPassword={notification.TempPassword}";
        var encodeCallbackUrl = $"{HtmlEncoder.Default.Encode(callbackUrl)}";

        var emailSubject = $"Forgot password confirmation";
        var emailMessage = $"Your temporary password is: <strong>{notification.ClearTempPassword}</strong>. Please confirm reset your password by <a name='{encodeCallbackUrl}'>clicking here</a>.";

        await _emailService.SendEmailAsync(notification.Email, emailSubject, emailMessage);
    }
}
