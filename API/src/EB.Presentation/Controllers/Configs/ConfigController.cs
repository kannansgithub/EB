using EB.Application.Features.Configs.Commands;
using EB.Application.Features.Configs.Queries;
using EB.Domain.Entities;
using EB.Persistence.DataAccessManagers.EFCores.ODatas;
using EB.Presentation.Shared.Filters;
using EB.Presentation.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace EB.Presentation.Controllers.Configs;

[Route("api/[controller]")]
public class ConfigController(ISender sender) : BaseApiController(sender)
{
    [ClaimBasedAuthorization("Create")]
    [HttpPost("CreateConfig")]
    public async Task<ActionResult<ApiSuccessResult<CreateConfigResult>>> CreateConfigAsync(CreateConfigRequest request, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);

        return Ok(new ApiSuccessResult<CreateConfigResult>
        {
            Code = StatusCodes.Status200OK,
            Message = $"Success executing {nameof(CreateConfigAsync)}",
            Content = response
        });
    }

    [ClaimBasedAuthorization("Update")]
    [HttpPost("UpdateConfig")]
    public async Task<ActionResult<ApiSuccessResult<UpdateConfigResult>>> UpdateConfigAsync(UpdateConfigRequest request, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);

        return Ok(new ApiSuccessResult<UpdateConfigResult>
        {
            Code = StatusCodes.Status200OK,
            Message = $"Success executing {nameof(UpdateConfigAsync)}",
            Content = response
        });
    }

    [ClaimBasedAuthorization("Delete")]
    [HttpDelete("DeleteConfig")]
    public async Task<ActionResult<ApiSuccessResult<DeleteConfigResult>>> DeleteConfigAsync(DeleteConfigRequest request, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);

        return Ok(new ApiSuccessResult<DeleteConfigResult>
        {
            Code = StatusCodes.Status200OK,
            Message = $"Success executing {nameof(DeleteConfigAsync)}",
            Content = response
        });
    }

    [ClaimBasedAuthorization("Read")]
    [HttpGet("GetPagedConfig")]
    public async Task<ActionResult<ApiSuccessResult<GetPagedConfigResult>>> GetPagedConfigAsync(
        ODataQueryOptions<Config> options,
        CancellationToken cancellationToken,
        [FromQuery] string searchValue,
        [FromQuery] bool isDeleted = false)
    {
        var queryOptionsAdapter = new ODataQueryOptionsAdapter<Config>(options);
        var request = new GetPagedConfigRequest
        {
            QueryOptions = queryOptionsAdapter,
            SearchValue = searchValue,
            IsDeleted = isDeleted
        };
        var response = await _sender.Send(request, cancellationToken);

        return Ok(new ApiSuccessResult<GetPagedConfigResult>
        {
            Code = StatusCodes.Status200OK,
            Message = $"Success executing {nameof(GetPagedConfigAsync)}",
            Content = response
        });
    }

    [ClaimBasedAuthorization("Read")]
    [HttpGet("GetConfig")]
    public async Task<ActionResult<ApiSuccessResult<GetConfigResult>>> GetConfigAsync(
        [FromQuery] string id,
        CancellationToken cancellationToken)
    {
        var request = new GetConfigRequest { Id = id };
        var response = await _sender.Send(request, cancellationToken);

        return Ok(new ApiSuccessResult<GetConfigResult>
        {
            Code = StatusCodes.Status200OK,
            Message = $"Success executing {nameof(GetConfigAsync)}",
            Content = response
        });
    }

    [AllowAnonymous]
    [HttpGet("GetActiveConfig")]
    public async Task<ActionResult<ApiSuccessResult<GetActiveConfigResult>>> GetActiveConfigAsync(
        CancellationToken cancellationToken)
    {
        var request = new GetActiveConfigRequest();
        var response = await _sender.Send(request, cancellationToken);

        return Ok(new ApiSuccessResult<GetActiveConfigResult>
        {
            Code = StatusCodes.Status200OK,
            Message = $"Success executing {nameof(GetConfigAsync)}",
            Content = response
        });
    }


}
