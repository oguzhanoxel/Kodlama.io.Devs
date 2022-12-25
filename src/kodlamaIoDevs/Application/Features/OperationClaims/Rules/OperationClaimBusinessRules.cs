using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using ProfileEntity = Domain.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Rules
{
	public class OperationClaimBusinessRules
	{
		private readonly IOperationClaimRepository _operationClaimRepository;

		public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
		{
			_operationClaimRepository = operationClaimRepository;
		}

		public async Task OperationClaimShouldExistWhenRequested(OperationClaim operationClaim)
		{
			if (operationClaim == null) throw new BusinessException("Requested operation claim does not exist");
		}
	}
}
