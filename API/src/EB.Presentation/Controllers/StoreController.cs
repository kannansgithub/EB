using EB.Application.Features.Store.Commands.Create;
using EB.Application.Features.Store.Commands.Delete;
using EB.Application.Features.Store.Commands.Update;
using EB.Application.Features.Store.Queries.GetAll;
using EB.Application.Features.Store.Queries.GetById;
using EB.Domain.Abstrations;
using EB.Domain.Exceptions;
using EB.Presentation.Abstrations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EB.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController(ILogger<StoreController> _logger, ISender _sender) : ControllerBase
    {
        [HttpGet("GetStores")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByHeader = "Authorization")]
        public async Task<IActionResult> GetStoreList()
        {
            try
            {
                var clients = await _sender.Send(new GetAllStoreQuery());
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
        [HttpGet("{id}/get")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByHeader = "Authorization")]
        public async Task<IActionResult> GetStore(string id)
        {
            try
            {
                var clients = await _sender.Send(new GetStoreQuery(id));
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
        public async Task<IActionResult> CreateStore([FromBody] StoreModel model)
        {
            try
            {
                var clients = await _sender.Send(new CreateStoreCommand(model));
                return Ok(clients);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(Constants.ERROR_MSG_500);
            }
        }
        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateStore(string id, [FromBody] StoreModel model)
        {
            try
            {
                var clients = await _sender.Send(new UpdateStoreCommand(id,
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
        public async Task<IActionResult> DeleteStore(string id)
        {
            try
            {
                await _sender.Send(new DeleteStoreCommand(id));
                return Ok();
            }
            catch (DeleteOperationException ex)
            {
                return Conflict(ex.Message);
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
