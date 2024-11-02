using AutoMapper;
using EB.Application.Extensions;
using EB.Application.Services.CQS.Queries;
using EB.Application.Shared.Contracts;
using EB.Domain.Constants;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EB.Application.Features.Currencies.Queries;



public class GetCurrencyLookupProfile : Profile
{
    public GetCurrencyLookupProfile()
    {
    }
}

public class GetCurrencyLookupResult
{
    public List<LookupDto> Data { get; init; } = null!;
    public string Message { get; init; } = null!;
}

public class GetCurrencyLookupRequest : IRequest<GetCurrencyLookupResult>
{
}

public class GetCurrencyLookupValidator : AbstractValidator<GetCurrencyLookupRequest>
{
    public GetCurrencyLookupValidator()
    {
    }
}


public class GetCurrencyLookupHandler(
    IQueryContext context,
    IMapper mapper
        ) : IRequestHandler<GetCurrencyLookupRequest, GetCurrencyLookupResult>
{
    private readonly IQueryContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<GetCurrencyLookupResult> Handle(GetCurrencyLookupRequest request, CancellationToken cancellationToken)
    {
        var query = _context
            .Currency
            .AsNoTracking()
            .ApplyIsDeletedFilter()
            .AsQueryable();

        var entities = await query
            .Select(x => new LookupDto
            {
                Value = x.Id,
                Text = $"{x.Symbol} / {x.Name}"
            })
            .ToListAsync(cancellationToken) ?? throw new ApplicationException($"{ExceptionConsts.EntitiyNotFound}");
        var dto = entities;

        return new GetCurrencyLookupResult
        {
            Data = dto,
            Message = "Success"
        };
    }
}



