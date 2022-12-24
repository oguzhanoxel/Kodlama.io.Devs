using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
	public interface IProfileRepository: IAsyncRepository<Profile>, IRepository<Profile>
	{

	}
}
