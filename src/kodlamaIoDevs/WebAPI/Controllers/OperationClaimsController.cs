using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Quaries.GetListOperationClaim;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OperationClaimsController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
		{
			CreatedOperationClaimDto result = await Mediator.Send(createOperationClaimCommand);
			return Created("", result);
		}

		[HttpDelete("{Id}")]
		public async Task<IActionResult> Delete([FromRoute] DeleteOperationClaimCommand deleteOperationClaimCommand)
		{
			DeletedOperationClaimDto result = await Mediator.Send(deleteOperationClaimCommand);
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
		{
			UpdatedOperationClaimDto result = await Mediator.Send(updateOperationClaimCommand);
			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetByUserId([FromQuery] PageRequest pageRequest)
		{
			GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
			OperationClaimListModel result = await Mediator.Send(getListOperationClaimQuery);
			return Ok(result);
		}
	}
}
