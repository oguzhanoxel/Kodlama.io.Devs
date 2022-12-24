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

namespace Application.Features.Profiles.Commands.CreateProfile
{
	public class CreateProfileCommand : IRequest<CreatedProfileDto>
	{
		public int UserId { get; set; }
		public string Github { get; set; }

		public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, CreatedProfileDto>
		{
			private readonly IProfileRepository _profileRepository;
			private readonly IMapper _mapper;

			public CreateProfileCommandHandler(IProfileRepository profileRepository, IMapper mapper)
			{
				_profileRepository = profileRepository;
				_mapper = mapper;
			}

			public async Task<CreatedProfileDto> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
			{
				ProfileEntity profile = _mapper.Map<ProfileEntity>(request);
				ProfileEntity addedProfile = await _profileRepository.AddAsync(profile);

				CreatedProfileDto createdProfileDto = _mapper.Map<CreatedProfileDto>(addedProfile);

				return createdProfileDto;
			}
		}
	}
}
