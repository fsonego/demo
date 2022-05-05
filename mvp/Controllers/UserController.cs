using Microsoft.AspNetCore.Mvc;
using mvp.application.Users.Commands.CreateUser;
using mvp.application.Users.Queries.GetAllUsersByActive;
using mvp.webpi.Controllers;

namespace mvp.Controllers;

public class UserController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult> GetAllUsersByActive([FromQuery] GetAllUsersQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromBody] CreateUserCommand command)
    {
        try
        {
            await Mediator.Send(command);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
        
        return Ok();

    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetails(Guid id, UpdateUserCommand command)
    {
        if (id != command.userDto.UserId)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteUserCommand { Id = id });

        return NoContent();
    }

}
