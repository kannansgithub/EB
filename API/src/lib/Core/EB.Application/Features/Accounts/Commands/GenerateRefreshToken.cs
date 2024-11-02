﻿using EB.Application.Services.Externals;
using EB.Application.Shared.Contracts;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Accounts.Commands;


public class GenerateRefreshTokenResult
{
    public string? AccessToken { get; init; }
    public string? RefreshToken { get; init; }
    public string? UserId { get; init; }
    public string? Email { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public List<string>? UserClaims { get; init; }
    public List<MainNavDto>? MainNavigations { get; init; }
}

public class GenerateRefreshTokenRequest : IRequest<GenerateRefreshTokenResult>
{
    public required string RefreshToken { get; set; }
}

public class GenerateRefreshTokenValidator : AbstractValidator<GenerateRefreshTokenRequest>
{
    public GenerateRefreshTokenValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty();
    }
}

public class GenerateRefreshTokenHandler(IIdentityService identityService) : IRequestHandler<GenerateRefreshTokenRequest, GenerateRefreshTokenResult>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<GenerateRefreshTokenResult> Handle(GenerateRefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var result = await _identityService.RefreshTokenAsync(
            request.RefreshToken,
            cancellationToken
            );

        return result!;
    }
}