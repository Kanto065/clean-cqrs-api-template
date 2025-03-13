using System.Net;
using Application.Features.User.Commands.Create;
using Application.Features.User.Commands.Delete;
using Application.Features.User.Commands.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Wrappers;

namespace clean_cqrs_api_template.Controllers
{
    public class UserController : BaseApiController
    {

        [HttpPost]
        [ProducesResponseType(typeof(Response<int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Response<int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Response<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(DeleteUserCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

    }
}
