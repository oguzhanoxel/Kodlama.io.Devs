using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Profiles
{
	public class MappingProfiles: AutoMapper.Profile
	{
		public MappingProfiles()
		{
			CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
			CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();

			CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();

			CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
			CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();

			CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
			CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
		}
	}
}
