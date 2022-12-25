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
	public class DeleteProfileCommand : IRequest<DeletedProfileDto>
	{
		public int Id { get; set; }

		public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand, DeletedProfileDto>
		{
			private readonly IProfileRepository _profileRepository;
			private readonly ProfileBusinessRules _profileBusinessRules;
			private readonly IMapper _mapper;

			public DeleteProfileCommandHandler(IProfileRepository profileRepository, IMapper mapper, ProfileBusinessRules profileBusinessRules)
			{
				_profileRepository = profileRepository;
				_mapper = mapper;
				_profileBusinessRules = profileBusinessRules;
			}

			public async Task<DeletedProfileDto> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
			{
				ProfileEntity? profile = await _profileRepository.GetAsync(p => p.Id == request.Id);
				await _profileBusinessRules.ProfileShouldExistWhenRequested(profile);
				ProfileEntity deletedProfile = await _profileRepository.DeleteAsync(profile);

				DeletedProfileDto deletedProfileDto = _mapper.Map<DeletedProfileDto>(deletedProfile);
				return deletedProfileDto;
			}
		}
	}
}
