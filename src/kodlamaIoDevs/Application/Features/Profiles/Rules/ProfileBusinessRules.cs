using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using ProfileEntity = Domain.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Rules
{
	public class ProfileBusinessRules
	{
		private readonly IProfileRepository _profileRepository;

		public ProfileBusinessRules(IProfileRepository profileRepository)
		{
			_profileRepository = profileRepository;
		}

		public async Task ProfileShouldExistWhenRequested(ProfileEntity profile)
		{
			if (profile == null) throw new BusinessException("Requested profile does not exist");
		}
	}
}
