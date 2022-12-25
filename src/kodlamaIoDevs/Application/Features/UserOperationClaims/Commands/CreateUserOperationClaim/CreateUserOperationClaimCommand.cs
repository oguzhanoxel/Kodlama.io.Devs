using Application.Features.OperationClaims.Dtos;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
	public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>
	{
		public int UserId { get; set; }
		public int OperationClaimId { get; set; }
		public class CreateOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
		{
			private readonly IUserOperationClaimRepository _userOperationClaimRepository;
			private readonly IMapper _mapper;
			private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

			public CreateOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
			{
				_userOperationClaimRepository = userOperationClaimRepository;
				_mapper = mapper;
				_userOperationClaimBusinessRules = userOperationClaimBusinessRules;
			}

			public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
			{
				UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);
				UserOperationClaim addedUserOperationClaim = await _userOperationClaimRepository.AddAsync(userOperationClaim);

				CreatedUserOperationClaimDto createdUserOperationClaimDto = _mapper.Map<CreatedUserOperationClaimDto>(addedUserOperationClaim);

				return createdUserOperationClaimDto;
			}
		}
	}
}
