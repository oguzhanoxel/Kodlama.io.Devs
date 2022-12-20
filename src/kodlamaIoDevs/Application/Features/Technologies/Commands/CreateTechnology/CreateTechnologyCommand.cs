﻿using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
	public class CreateTechnologyCommand:IRequest<CreatedTechnologyDto>
	{
		public string Name { get; set; }
		public int ProgrammingLanguageId { get; set; }

		public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
		{
			private readonly ITechnologyRepository _technologyRepository;
			private readonly TechnologyBusinessRules _technologyBusinessRules;
			private readonly IMapper _mapper;

			public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
			{
				_technologyRepository = technologyRepository;
				_mapper = mapper;
				_technologyBusinessRules = technologyBusinessRules;
			}

			public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
			{
				await _technologyBusinessRules.TechnologyCanNotBeDuplicatedWhenInserted(request.Name);

				Technology mappedTechnology = _mapper.Map<Technology>(request);
				Technology addedTechnology = await _technologyRepository.AddAsync(mappedTechnology);
				CreatedTechnologyDto createdTechnologyDto = _mapper.Map<CreatedTechnologyDto>(addedTechnology);
				
				return createdTechnologyDto;
			}
		}
	}
}
