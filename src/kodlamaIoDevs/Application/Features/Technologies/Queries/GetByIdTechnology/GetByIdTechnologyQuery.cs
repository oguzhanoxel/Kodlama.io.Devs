using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetByIdTechnology
{
	public class GetByIdTechnologyQuery:IRequest<TechnologyGetByIdDto>
	{
		public int Id { get; set; }

		public class GetByIdTechnologyQueryHandler:IRequestHandler<GetByIdTechnologyQuery, TechnologyGetByIdDto>
		{
			private readonly ITechnologyRepository _technologyRepository;
			private readonly IMapper _mapper;

			public GetByIdTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
			{
				_technologyRepository = technologyRepository;
				_mapper = mapper;
			}

			public async Task<TechnologyGetByIdDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
			{
				Technology technology = await _technologyRepository.GetAsync(t => t.Id == request.Id);
				TechnologyGetByIdDto technologyGetByIdDto = _mapper.Map<TechnologyGetByIdDto>(technology);
				return technologyGetByIdDto;
			}
		}
	}
}
