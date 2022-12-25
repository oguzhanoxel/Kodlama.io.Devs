using Application.Features.OperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Models
{
	public class UserOperationClaimListByUserIdModel
	{
		public IList<UserOperationClaimListByUserIdDto> Items { get; set; }
	}
}
