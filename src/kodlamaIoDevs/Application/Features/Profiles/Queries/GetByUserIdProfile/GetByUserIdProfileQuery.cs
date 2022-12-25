using Application.Features.Profiles.Dtos;
using Application.Features.Profiles.Rules;
using Application.Services.Repositories;
using ProfileEntity = Domain.Entities.Profile;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Profiles.Queries.GetByUserIdProfile
{
	public class GetByUserIdProfileQuery:IRequest<ProfileGetByUserIdDto>
	{
		public int UserId { get; set; }

		public class GetByUserIdProfileQueryHandler : IRequestHandler<GetByUserIdProfileQuery, ProfileGetByUserIdDto>
		{
			private readonly IProfileRepository _profileRepository;
			private readonly ProfileBusinessRules _profileBusinessRules;
			private readonly IMapper _mapper;

			public GetByUserIdProfileQueryHandler(IProfileRepository profileRepository, ProfileBusinessRules profileBusinessRules, IMapper mapper)
			{
				_profileRepository = profileRepository;
				_profileBusinessRules = profileBusinessRules;
				_mapper = mapper;
			}

			public async Task<ProfileGetByUserIdDto> Handle(GetByUserIdProfileQuery request, CancellationToken cancellationToken)
			{
				ProfileEntity? profile = await _profileRepository.GetAsync(p => p.UserId == request.UserId, include: p => p.Include(p => p.User));
				await _profileBusinessRules.ProfileShouldExistWhenRequested(profile);
				ProfileGetByUserIdDto profileGetByUserIdDto = _mapper.Map<ProfileGetByUserIdDto>(profile);
				return profileGetByUserIdDto;
			}
		}
	}
}
