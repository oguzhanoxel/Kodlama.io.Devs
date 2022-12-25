﻿using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using ProfileEntity = Domain.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Rules
{
	public class UserOperationClaimBusinessRules
	{
		private readonly IUserOperationClaimRepository _userOperationClaimRepository;

		public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
		{
			_userOperationClaimRepository = userOperationClaimRepository;
		}

		public async Task UserOperationClaimShouldExistWhenRequested(UserOperationClaim userOperationClaim)
		{
			if (userOperationClaim == null) throw new BusinessException("Requested user operation claim does not exist");
		}
	}
}
