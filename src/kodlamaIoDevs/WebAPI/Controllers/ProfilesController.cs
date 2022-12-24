using Application.Features.Profiles.Commands.CreateProfile;
using Application.Features.Profiles.Dtos;
using Application.Features.Profiles.Queries.GetByUserIdProfile;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProfilesController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateProfileCommand createProfileCommand)
		{
			CreatedProfileDto result = await Mediator.Send(createProfileCommand);
			return Created("", result);
		}

		[HttpDelete("{Id}")]
		public async Task<IActionResult> Delete([FromRoute] DeleteProfileCommand deleteProfileCommand)
		{
			DeletedProfileDto result = await Mediator.Send(deleteProfileCommand);
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateProfileCommand updateProfileCommand)
		{
			UpdatedProfileDto result = await Mediator.Send(updateProfileCommand);
			return Ok(result);
		}

		[HttpGet("{UserId}")]
		public async Task<IActionResult> GetByUserId([FromRoute] GetByUserIdProfileQuery getByUserIdProfileQuery)
		{
			ProfileGetByUserIdDto result = await Mediator.Send(getByUserIdProfileQuery);
			return Ok(result);
		}
	}
}
