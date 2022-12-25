using Application.Features.OperationClaims.Dtos;
using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Profiles
{
	public class MappingProfiles : AutoMapper.Profile
	{
		public MappingProfiles()
		{
			CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
			CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();

			CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();

			CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
			CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();

			CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListByUserIdModel>().ReverseMap();
			CreateMap<UserOperationClaim, UserOperationClaimListByUserIdDto>()
				.ForMember(o => o.Email, opt => opt.MapFrom(o => o.User.Email))
				.ForMember(o => o.OperationClaimName, opt => opt.MapFrom(o => o.OperationClaim.Name))
				.ReverseMap();
		}
	}
}
