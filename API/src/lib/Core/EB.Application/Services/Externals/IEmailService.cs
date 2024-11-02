namespace EB.Application.Services.Externals;

public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string htmlMessage);
}
