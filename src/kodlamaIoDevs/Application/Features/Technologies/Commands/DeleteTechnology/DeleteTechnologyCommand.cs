using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
	public class DeleteTechnologyCommand:IRequest<DeletedTechnologyDto>, ISecuredRequest
	{
		public int Id { get; set; }
		public string[] Roles { get; } = { "admin" };

		public class DeleteTechnologyCommandHandler:IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
		{
			private readonly ITechnologyRepository _technologyRepository;
			private readonly IMapper _mapper;

			public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
			{
				_technologyRepository = technologyRepository;
				_mapper = mapper;
			}

			public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
			{
				Technology technology = await _technologyRepository.GetAsync(t => t.Id == request.Id);

				await _technologyRepository.DeleteAsync(technology);

				DeletedTechnologyDto mappedTechnology = _mapper.Map<DeletedTechnologyDto>(technology);
				return mappedTechnology;
			}
		}
	}
}
