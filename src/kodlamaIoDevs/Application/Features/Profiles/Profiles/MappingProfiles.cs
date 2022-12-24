using ProfileEntity = Domain.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Profiles.Commands.CreateProfile;
using Application.Features.Profiles.Dtos;

namespace Application.Features.Profiles.Profiles
{
	public class MappingProfiles : AutoMapper.Profile
	{
		public MappingProfiles()
		{
			CreateMap<ProfileEntity, CreateProfileCommand>().ReverseMap();
			CreateMap<ProfileEntity, CreatedProfileDto>().ReverseMap();

			CreateMap<ProfileEntity, DeletedProfileDto>().ReverseMap();

			CreateMap<ProfileEntity, UpdateProfileCommand>().ReverseMap();
			CreateMap<ProfileEntity, UpdatedProfileDto>().ReverseMap();

			CreateMap<ProfileEntity, ProfileGetByUserIdDto>()
				.ForMember(p => p.FirstName, opt => opt.MapFrom(p => p.User.FirstName))
				.ForMember(p => p.LastName, opt => opt.MapFrom(p => p.User.LastName))
				.ForMember(p => p.Email, opt => opt.MapFrom(p => p.User.Email))
				.ReverseMap();
		}
	}
}
