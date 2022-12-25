using Application.Features.OperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Quaries.GetListOperationClaim
{
	public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>
	{
		public PageRequest PageRequest { get; set; }

		public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
		{
			private readonly IOperationClaimRepository _operationClaimRepository;
			private readonly IMapper _mapper;

			public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
			{
				_operationClaimRepository = operationClaimRepository;
				_mapper = mapper;
			}

			public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
			{
				IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync();
				OperationClaimListModel operationClaimListModel = _mapper.Map<OperationClaimListModel>(operationClaims);
				return operationClaimListModel;
			}
		}
	}
}
