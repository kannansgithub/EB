﻿using EB.Application.Services.Repositories;
using EB.Domain.Entities;
using FluentValidation;
using MediatR;

namespace EB.Application.Features.Currencies.Commands;



public class CreateCurrencyResult
{
    public string Id { get; init; } = null!;
    public string Message { get; init; } = null!;
}

public class CreateCurrencyRequest : IRequest<CreateCurrencyResult>
{
    public string? UserId { get; init; }
    public string Name { get; init; } = null!;
    public string Code { get; init; } = null!;
    public string Symbol { get; init; } = null!;
    public string? Description { get; init; }
}

public class CreateCurrencyValidator : AbstractValidator<CreateCurrencyRequest>
{
    public CreateCurrencyValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.Symbol)
            .NotEmpty();
    }
}


public class CreateCurrencyHandler(
    IBaseCommandRepository<Currency> repository,
    IUnitOfWork unitOfWork
        ) : IRequestHandler<CreateCurrencyRequest, CreateCurrencyResult>
{
    private readonly IBaseCommandRepository<Currency> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CreateCurrencyResult> Handle(CreateCurrencyRequest request, CancellationToken cancellationToken = default)
    {
        var entity = new Currency(
                request.UserId,
                request.Code,
                request.Name,
                request.Symbol,
                request.Description
                );

        await _repository.CreateAsync(entity, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return new CreateCurrencyResult
        {
            Id = entity.Id,
            Message = "Success"
        };
    }
}


