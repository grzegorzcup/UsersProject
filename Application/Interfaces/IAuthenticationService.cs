using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> Login (string username, string password);
        Task<AuthenticationResult> Logout (string username, string password);
    }
}
