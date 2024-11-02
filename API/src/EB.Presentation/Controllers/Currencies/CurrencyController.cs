using EB.Application.Features.Currencies.Commands;
using EB.Application.Features.Currencies.Queries;
using EB.Domain.Entities;
using EB.Persistence.DataAccessManagers.EFCores.ODatas;
using EB.Presentation.Shared.Filters;
using EB.Presentation.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace EB.Presentation.Controllers.Currencies;

[Route("api/[controller]")]
public class CurrencyController(ISender sender) : BaseApiController(sender)
{
    [ClaimBasedAuthorization("Create")]
    [HttpPost("CreateCurrency")]
    public async Task<ActionResult<ApiSuccessResult<CreateCurrencyResult>>> CreateCurrencyAsync(CreateCurrencyRequest request, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);

        return Ok(new ApiSuccessResult<CreateCurrencyResult>
        {
            Code = StatusCodes.Status200OK,
            Message = $"Success executing {nameof(CreateCurrencyAsync)}",
            Content = response
        });
    }

    [ClaimBasedAuthorization("Update")]
    [HttpPost("UpdateCurrency")]
    public async Task<ActionResult<ApiSuccessResult<UpdateCurrencyResult>>> UpdateCurrencyAsync(UpdateCurrencyRequest request, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);

        return Ok(new ApiSuccessResult<UpdateCurrencyResult>
        {
            Code = StatusCodes.Status200OK,
            Message = $"Success executing {nameof(UpdateCurrencyAsync)}",
            Content = response
        });
    }

    [ClaimBasedAuthorization("Delete")]
    [HttpDelete("DeleteCurrency")]
    public async Task<ActionResult<ApiSuccessResult<DeleteCurrencyResult>>> DeleteCurrencyAsync(DeleteCurrencyRequest request, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);

        return Ok(new ApiSuccessResult<DeleteCurrencyResult>
        {
            Code = StatusCodes.Status200OK,
            Message = $"Success executing {nameof(DeleteCurrencyAsync)}",
            Content = response
        });
    }

    [ClaimBasedAuthorization("Read")]
    [HttpGet("GetPagedCurrency")]
    public async Task<ActionResult<ApiSuccessResult<GetPagedCurrencyResult>>> GetPagedCurrencyAsync(
        ODataQueryOptions<Currency> options,
        CancellationToken cancellationToken,
        [FromQuery] bool isDeleted = false)
    {
        var queryOptionsAdapter = new ODataQueryOptionsAdapter<Currency>(options);
        var request = new GetPagedCurrencyRequest { QueryOptions = queryOptionsAdapter, IsDeleted = isDeleted };
        var response = await _sender.Send(request, cancellationToken);

        return Ok(new ApiSuccessResult<GetPagedCurrencyResult>
        {
            Code = StatusCodes.Status200OK,
            Message = $"Success executing {nameof(GetPagedCurrencyAsync)}",
            Content = response
        });
    }

    [ClaimBasedAuthorization("Read")]
    [HttpGet("GetCurrency")]
    public async Task<ActionResult<ApiSuccessResult<GetCurrencyResult>>> GetCurrencyAsync(
        [FromQuery] string id,
        CancellationToken cancellationToken)
    {
        var request = new GetCurrencyRequest { Id = id };
        var response = await _sender.Send(request, cancellationToken);

        return Ok(new ApiSuccessResult<GetCurrencyResult>
        {
            Code = StatusCodes.Status200OK,
            Message = $"Success executing {nameof(GetCurrencyAsync)}",
            Content = response
        });
    }

    [Authorize]
    [HttpGet("GetCurrencyLookup")]
    public async Task<ActionResult<ApiSuccessResult<GetCurrencyLookupResult>>> GetCurrencyLookupAsync(
        CancellationToken cancellationToken)
    {
        var request = new GetCurrencyLookupRequest();
        var response = await _sender.Send(request, cancellationToken);

        return Ok(new ApiSuccessResult<GetCurrencyLookupResult>
        {
            Code = StatusCodes.Status200OK,
            Message = $"Success executing {nameof(GetCurrencyLookupAsync)}",
            Content = response
        });
    }


}

