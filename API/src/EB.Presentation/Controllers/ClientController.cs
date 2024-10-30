using EB.Application.Features.Clients.Commands.Create;
using EB.Application.Features.Clients.Commands.Delete;
using EB.Application.Features.Clients.Commands.Update;
using EB.Application.Features.Clients.Queries.GetAll;
using EB.Application.Features.Clients.Queries.GetById;
using EB.Domain.Abstrations;
using EB.Domain.Exceptions;
using EB.Presentation.Abstrations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EB.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(ILogger<ClientController> _logger, ISender _sender) : ControllerBase
    {
        [HttpGet("GetClients")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByHeader = "Authorization")]
        public async Task<IActionResult> GetClientList()
        {
            try
            {
                var clients = await _sender.Send(new GetClientsQuery());
                return Ok(clients);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message, ex);
                return BadRequest(Constants.ERROR_MSG_500);
            }
        }
        [HttpGet("{id}/get")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByHeader = "Authorization")]
        public async Task<IActionResult> GetClient(string id)
        {
            try
            {
                var clients = await _sender.Send(new GetClientQuery(id));
                return Ok(clients);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(Constants.ERROR_MSG_500);
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateClient([FromBody] ClientRequest model)
        {
            try
            {
                var clients = await _sender.Send(new CreateClientCommand(model));
                return Ok(clients);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(Constants.ERROR_MSG_500);
            }
        }
        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateClient(string id,[FromBody]ClientRequest model)
        {
            try
            {
                var clients = await _sender.Send(new UpdateClientCommand(id,
                    model));
                return Ok(clients);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(Constants.ERROR_MSG_500);
            }
        }
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            try
            {
                await _sender.Send(new DeleteClientCommand(id));
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(Constants.ERROR_MSG_500);
            }
        }
    }
}
