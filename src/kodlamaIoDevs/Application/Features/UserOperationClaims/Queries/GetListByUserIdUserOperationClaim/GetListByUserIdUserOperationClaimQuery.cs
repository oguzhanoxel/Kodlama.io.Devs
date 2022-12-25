using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetListByUserIdUserOperationClaim
{
	public class GetListByUserIdUserOperationClaimQuery : IRequest<UserOperationClaimListByUserIdModel>
	{
		public int UserId { get; set; }

		public class GetListByUserIdUserOperationClaimQueryHandler:IRequestHandler<GetListByUserIdUserOperationClaimQuery, UserOperationClaimListByUserIdModel>
		{
			private readonly IUserOperationClaimRepository _userOperationClaimRepository;
			private readonly IMapper _mapper;
			private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

			public GetListByUserIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
			{
				_userOperationClaimRepository = userOperationClaimRepository;
				_mapper = mapper;
				_userOperationClaimBusinessRules = userOperationClaimBusinessRules;
			}

			public async Task<UserOperationClaimListByUserIdModel> Handle(GetListByUserIdUserOperationClaimQuery request, CancellationToken cancellationToken)
			{
				IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(u => u.UserId == request.UserId, include: u => u.Include(u => u.User).Include(o => o.OperationClaim));

				UserOperationClaimListByUserIdModel operationClaimListByUserIdModel = _mapper.Map<UserOperationClaimListByUserIdModel>(userOperationClaims);

				return operationClaimListByUserIdModel;
			}
		}
	}
}
