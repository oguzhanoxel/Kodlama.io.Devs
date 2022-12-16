using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Profiles
{
	public class MappingProfiles:Profile
	{
		public MappingProfiles()
		{
			CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
			CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();

			CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();

			CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();
			CreateMap<Technology, UpdatedTechnologyDto>().ReverseMap();

			CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
			CreateMap<Technology, TechnologyListDto>().ForMember(t => t.ProgrammingLanguageName, opt => opt.MapFrom(p => p.ProgrammingLanguage.Name)).ReverseMap();

			CreateMap<Technology, TechnologyGetByIdDto>().ForMember(t => t.ProgrammingLanguageName, opt => opt.MapFrom(p => p.ProgrammingLanguage.Name)).ReverseMap();
		}
	}
}
