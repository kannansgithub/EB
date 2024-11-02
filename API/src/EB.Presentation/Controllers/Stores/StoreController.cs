using Azure;
using EB.Application.Features.Store.Commands.Create;
using EB.Application.Features.Store.Commands.Delete;
using EB.Application.Features.Store.Commands.Update;
using EB.Application.Features.Store.Queries.GetAll;
using EB.Application.Features.Store.Queries.GetById;
using EB.Domain.Abstrations;
using EB.Domain.Exceptions;
using EB.Presentation.Abstrations;
using EB.Presentation.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EB.Presentation.Controllers.Stores
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController(ISender _sender) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult<ApiSuccessResult<StoreResponse>>> CreateStoreAsync([FromBody] StoreModel model)
        {
            var response = await _sender.Send(new CreateStoreCommand(model));
            return Ok(new ApiSuccessResult<StoreResponse>
            {
                Code = StatusCodes.Status200OK,
                Message = $"Success executing {nameof(CreateStoreAsync)}",
                Content = response
            });

        }
        [HttpPut("{id}/update")]
        public async Task<ActionResult<ApiSuccessResult<StoreResponse>>> UpdateStoreAsync(string id, [FromBody] StoreModel model)
        {
            var response = await _sender.Send(new UpdateStoreCommand(id, model));
            return Ok(new ApiSuccessResult<StoreResponse>
            {
                Code = StatusCodes.Status200OK,
                Message = $"Success executing {nameof(UpdateStoreAsync)}",
                Content = response
            });

        }
        [HttpDelete("{id}/delete")]
        public async Task<ActionResult<ApiSuccessResult<string>>> DeleteStoreAsync(string id)
        {
            await _sender.Send(new DeleteStoreCommand(id));
            return Ok(new ApiSuccessResult<string>
            {
                Code = StatusCodes.Status200OK,
                Message = $"Success executing {nameof(DeleteStoreAsync)}",
                Content = "Requested Record Deleted Successfully"
            });
        }
        [HttpGet("GetStores")]

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByHeader = "Authorization")]
        public async Task<ActionResult<ApiSuccessResult<IEnumerable<StoreResponse>>>> GetStoreListAsync()
        {
            var response = await _sender.Send(new GetAllStoreQuery());
            return Ok(new ApiSuccessResult<IEnumerable<StoreResponse>>
            {
                Code = StatusCodes.Status200OK,
                Message = $"Success executing {nameof(GetStoreListAsync)}",
                Content = response
            });
        }

        [HttpGet("{id}/get")]

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByHeader = "Authorization")]
        public async Task<ActionResult<ApiSuccessResult<StoreResponse>>> GetStoreAsync(string id)
        {
            var response = await _sender.Send(new GetStoreQuery(id));
            return Ok(new ApiSuccessResult<StoreResponse>
            {
                Code = StatusCodes.Status200OK,
                Message = $"Success executing {nameof(GetStoreAsync)}",
                Content = response
            });

        }

    }
}
