using EB.Application.Services.Externals;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Commands;

public record CreateUserResult(
    string? Id,
    string? Email,
    string? FirstName,
    string? LastName
);
public class CreateUserRequest : IRequest<CreateUserResult>
{
    public required string Email { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string CreatedById { get; init; }
    public required string Password { get; init; }
    public required string ConfirmPassword { get; init; }
}

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.FirstName)
            .NotEmpty();

        RuleFor(x => x.LastName)
            .NotEmpty();

        RuleFor(x => x.CreatedById)
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty();

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .Equal(x => x.Password).WithMessage("Password and Confirm Password should equal.");
    }
}

public class CreateUserHandler(IIdentityService identityService) 
    : IRequestHandler<CreateUserRequest, CreateUserResult>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<CreateUserResult> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.CreateUserAsync(
            request.Email,
            request.Password,
            request.FirstName,
            request.LastName,
            request.CreatedById,
            cancellationToken
            );

        return result!;
    }
}
