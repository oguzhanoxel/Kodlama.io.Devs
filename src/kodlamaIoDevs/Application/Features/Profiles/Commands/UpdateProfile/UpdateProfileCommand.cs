using Application.Features.Profiles.Dtos;
using Application.Services.Repositories;
using ProfileEntity = Domain.Entities.Profile;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Profiles.Rules;

namespace Application.Features.Profiles.Commands.CreateProfile
{
	public class UpdateProfileCommand : IRequest<UpdatedProfileDto>
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Github { get; set; }

		public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, UpdatedProfileDto>
		{
			private readonly IProfileRepository _profileRepository;
			private readonly ProfileBusinessRules _profileBusinessRules;
			private readonly IMapper _mapper;

			public UpdateProfileCommandHandler(IProfileRepository profileRepository, IMapper mapper, ProfileBusinessRules profileBusinessRules)
			{
				_profileRepository = profileRepository;
				_mapper = mapper;
				_profileBusinessRules = profileBusinessRules;
			}

			public async Task<UpdatedProfileDto> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
			{
				ProfileEntity? profile = _mapper.Map<ProfileEntity>(request);
				await _profileBusinessRules.ProfileShouldExistWhenRequested(profile);
				ProfileEntity updatedProfile = await _profileRepository.UpdateAsync(profile);

				UpdatedProfileDto updatedProfileDto = _mapper.Map<UpdatedProfileDto>(updatedProfile);

				return updatedProfileDto;
			}
		}
	}
}
