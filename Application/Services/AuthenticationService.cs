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

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
    }
}
