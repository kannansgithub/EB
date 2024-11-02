﻿using AutoMapper;
using EB.Application.Extensions;
using EB.Application.Services.CQS.Queries;
using EB.Application.Shared.Contracts;
using EB.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EB.Application.Features.Currencies.Queries;



public record GetPagedCurrencyDto
{
    public string Id { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string Symbol { get; init; } = null!;
    public string? Description { get; init; }
}


public class GetPagedCurrencyProfile : Profile
{
    public GetPagedCurrencyProfile()
    {
        CreateMap<Currency, GetPagedCurrencyDto>();
    }
}

public class GetPagedCurrencyResult
{
    public PagedList<GetPagedCurrencyDto>? Data { get; init; }
    public string Message { get; init; } = null!;
}

public class GetPagedCurrencyRequest : IRequest<GetPagedCurrencyResult>
{
    public IODataQueryOptions<Currency> QueryOptions { get; init; } = null!;
    public bool IsDeleted { get; init; } = false;
}

public class GetPagedCurrencyValidator : AbstractValidator<GetPagedCurrencyRequest>
{
    public GetPagedCurrencyValidator()
    {

        RuleFor(x => x.QueryOptions)
            .NotNull().WithMessage("Query options are required.");
    }
}


public class GetPagedCurrencyHandler(IMapper mapper, IQueryContext context) : IRequestHandler<GetPagedCurrencyRequest, GetPagedCurrencyResult>
{
    private readonly IMapper _mapper = mapper;
    private readonly IQueryContext _context = context;

    public async Task<GetPagedCurrencyResult> Handle(GetPagedCurrencyRequest request, CancellationToken cancellationToken)
    {
        var query = _context
            .Currency
            .AsNoTracking()
            .ApplyIsDeletedFilter(request.IsDeleted)
            .AsQueryable();

        query = query
            .ApplyODataFilterWithPaging(request.QueryOptions, out int totalRecords, out int skip, out int top);

        var entities = await query.ToListAsync(cancellationToken);

        var dtos = _mapper.Map<List<GetPagedCurrencyDto>>(entities);

        return new GetPagedCurrencyResult
        {
            Data = new PagedList<GetPagedCurrencyDto>(dtos, totalRecords, skip / top + 1, top),
            Message = "Success"
        };
    }


}



