using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Application.Authentication;
using System.Runtime.CompilerServices;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly JWTConfig _jWTConfig;

        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager, IPostRepository postRepository, IMapper mapper, JWTConfig jWTConfig)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _postRepository = postRepository;
            _mapper = mapper;
            _jWTConfig = jWTConfig;
        }

        public async Task<AuthenticationResult> Login(string username, string password)
        {
            await _signInManager.PasswordSignInAsync(username, password,false,false);

            throw new NotImplementedException();
        }

        public Task<AuthenticationResult> Logout(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthenticationResult> Register(UserRegistrationDto user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                throw new Exception("błędne login lub hasło");
            var newuser = new IdentityUser() { UserName = user.UserName };
            newuser = _mapper.Map<User>(newuser);
            var create = await _userManager.CreateAsync((User)newuser, user.Password);
            
        }
    }
}
