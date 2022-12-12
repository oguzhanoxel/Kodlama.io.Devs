using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
	public class DeleteProgrammingLanguageCommand:IRequest<DeletedProgrammingLanguageDto>
	{
		public int Id { get; set; }

		public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
		{
			private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
			private readonly IMapper _mapper;
			private readonly ProgrammingLanguageBusinessRules _ProgrammingLanguageBusinessRules;

			public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules, IMapper mapper)
			{
				_programmingLanguageRepository = programmingLanguageRepository;
				_ProgrammingLanguageBusinessRules = programmingLanguageBusinessRules;
				_mapper = mapper;
			}

			public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
			{
				ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);

				await _ProgrammingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);

				await _programmingLanguageRepository.DeleteAsync(programmingLanguage);

				DeletedProgrammingLanguageDto mappedDeletedProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(programmingLanguage);

				return mappedDeletedProgrammingLanguageDto;
			}
		}
	}
}
