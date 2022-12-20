using Application.Features.Auths.Dtos;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
	public class AuthBusinessRules
	{
		private readonly IUserRepository _userRepository;

		public AuthBusinessRules(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public async Task WrongEmailOrPasswordWhenLoggedIn(UserForLoginDto userForLoginDto)
		{
			User? user = await _userRepository.GetAsync(u => u.Email == userForLoginDto.Email);
			if (user == null && !HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt)) throw new BusinessException("Wrong User Email or Password");
		}
		public async Task NotFoundEmailWhenLoggedIn(string email)
		{
			User? user = await _userRepository.GetAsync(u => u.Email == email);
			if (user == null) throw new BusinessException("User not found");
		}

		public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
		{
			User? user = await _userRepository.GetAsync(u => u.Email == email);
			if (user != null) throw new BusinessException("Mail already exists.");
		}
	}
}
