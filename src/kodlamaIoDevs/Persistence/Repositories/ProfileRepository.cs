using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class ProfileRepository : EfRepositoryBase<Profile, BaseDbContext>, IProfileRepository
	{
		public ProfileRepository(BaseDbContext context) : base(context)
		{
		}
	}
}
