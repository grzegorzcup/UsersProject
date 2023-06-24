using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public class AuthResult
    {
        public string Token { get; set; }

        public bool Succes { get; set; }

        public List<string> Errors { get; set; }
    }
}
