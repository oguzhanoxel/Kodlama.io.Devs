using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Profile : Entity
	{
		public int UserId { get; set; }
		public string Github { get; set; }

		public virtual User User { get; set; }

		public Profile()
		{

		}
		public Profile(int id, int userId, string github)
		{
			Id = id;
			UserId = userId;
			Github = github;
		}
	}
}
