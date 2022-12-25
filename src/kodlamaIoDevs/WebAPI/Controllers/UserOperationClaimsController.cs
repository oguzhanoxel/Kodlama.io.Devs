﻿using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries.GetListByUserIdUserOperationClaim;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserOperationClaimsController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
		{
			CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
			return Created("", result);
		}

		[HttpDelete("{Id}")]
		public async Task<IActionResult> Delete([FromRoute] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
		{
			DeletedUserOperationClaimDto result = await Mediator.Send(deleteUserOperationClaimCommand);
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
		{
			UpdatedUserOperationClaimDto result = await Mediator.Send(updateUserOperationClaimCommand);
			return Ok(result);
		}

		[HttpGet("GetListByUserId")]
		public async Task<IActionResult> GetListByUserId([FromQuery] GetListByUserIdUserOperationClaimQuery getListByUserIdUserOperationClaimQuery)
		{
			UserOperationClaimListByUserIdModel result = await Mediator.Send(getListByUserIdUserOperationClaimQuery);
			return Ok(result);
		}
	}
}
