using EB.Application.Features.Accounts.Events;
using EB.Application.Services.Externals;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Commands;

public class ForgotPasswordResult
{
    public string Email { get; init; } = null!;
    public string TempPassword { get; init; } = null!;
    public string ClearTempPassword { get; init; } = null!;
    public string? EmailConfirmationToken { get; init; }
    public string Host { get; init; } = null!;
}

public class ForgotPasswordRequest : IRequest<ForgotPasswordResult>
{
    public required string Email { get; init; }
    public required string Host { get; init; }
}

public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordRequest>
{
    public ForgotPasswordValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Host)
            .NotEmpty();
    }
}


public class ForgotPasswordHandler(
    IMediator mediator,
    IIdentityService identityService
        ) : IRequestHandler<ForgotPasswordRequest, ForgotPasswordResult>
{
    private readonly IMediator _mediator = mediator;
    private readonly IIdentityService _identityService = identityService;

    public async Task<ForgotPasswordResult> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.ForgotPasswordAsync(
            request.Email,
            cancellationToken
            );

        var forgotPasswordEvent = new ForgotPasswordEvent
        (
            result.Email,
            result.TempPassword,
            result.EmailConfirmationToken,
            request.Host,
            result.ClearTempPassword
        );

        await _mediator.Publish(forgotPasswordEvent);

        return result!;
    }
}
