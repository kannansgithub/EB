using EB.Application.Features.Client.Commands.Create;
using EB.Application.Features.Client.Commands.Delete;
using EB.Application.Features.Client.Commands.Update;
using EB.Application.Features.Client.Queries.GetAll;
using EB.Application.Features.Client.Queries.GetById;
using EB.Domain.Abstrations;
using EB.Presentation.Shared.Filters;
using EB.Presentation.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EB.Presentation.Controllers.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(ISender sender) : BaseApiController(sender)
    {


        [ClaimBasedAuthorization("Update")]
        [HttpPost("create")]
        public async Task<ActionResult<ApiSuccessResult<ClientModel>>> CreateClientAsync([FromBody] ClientRequest model)
        {

            var response = await _sender.Send(new CreateClientCommand(model));
            return Ok(new ApiSuccessResult<ClientModel>
            {
                Code = StatusCodes.Status200OK,
                Message = $"Success executing {nameof(CreateClientAsync)}",
                Content = response
            });
        }
        [ClaimBasedAuthorization("Update")]
        [HttpPut("{id}/update")]
        public async Task<ActionResult<ApiSuccessResult<ClientModel>>> UpdateClientAsync(string id, [FromBody] ClientRequest model)
        {
            var response = await _sender.Send(new UpdateClientCommand(id, model));
            return Ok(new ApiSuccessResult<ClientModel>
            {
                Code = StatusCodes.Status200OK,
                Message = $"Success executing {nameof(UpdateClientAsync)}",
                Content = response
            });

        }
        [ClaimBasedAuthorization("Update")]
        [HttpDelete("{id}/delete")]
        public async Task<ActionResult<ApiSuccessResult<string>>> DeleteClientAsync(string id)
        {
            await _sender.Send(new DeleteClientCommand(id));
            return Ok(new ApiSuccessResult<string>
            {
                Code = StatusCodes.Status200OK,
                Message = $"Success executing {nameof(DeleteClientAsync)}",
                Content = "Requested Record Deleted Successfully"
            });
        }
        [ClaimBasedAuthorization("Read")]
        [HttpGet("GetClients")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByHeader = "Authorization")]
        public async Task<ActionResult<ApiSuccessResult<IEnumerable<ClientModel>>>> GetClientListAsync(
            CancellationToken cancellationToken=default
        )
        {
            var response = await _sender.Send(new GetClientsQuery(), cancellationToken);
            return Ok(new ApiSuccessResult<IEnumerable<ClientModel>>
            {
                Code = StatusCodes.Status200OK,
                Message = $"Success executing {nameof(GetClientListAsync)}",
                Content = response
            });
        }
        [ClaimBasedAuthorization("Read")]
        [HttpGet("{id}/get")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByHeader = "Authorization")]
        public async Task<ActionResult<ApiSuccessResult<ClientModel>>> GetClientAsync(string id)
        {
            var response = await _sender.Send(new GetClientQuery(id));
            return Ok(new ApiSuccessResult<ClientModel>
            {
                Code = StatusCodes.Status200OK,
                Message = $"Success executing {nameof(GetClientAsync)}",
                Content = response
            });
        }
    }
}
