using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
	public class CreateOperationClaimCommand:IRequest<CreatedOperationClaimDto>
	{
		public string Name { get; set; }

		public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
		{
			private readonly IOperationClaimRepository _operationClaimRepository;
			private readonly IMapper _mapper;
			private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

			public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
			{
				_operationClaimRepository = operationClaimRepository;
				_mapper = mapper;
				_operationClaimBusinessRules = operationClaimBusinessRules;
			}

			public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
			{
				OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);
				OperationClaim addedOperationClaim = await _operationClaimRepository.AddAsync(operationClaim);

				CreatedOperationClaimDto createdOperationClaimDto = _mapper.Map<CreatedOperationClaimDto>(addedOperationClaim);

				return createdOperationClaimDto;
			}
		}
	}
}
