using System;
using System.Collections.Generic;
using System.Text;

namespace identity.AuthenticateHandlers.DTOs
{
    public class AuthenticationInformation
    {
        public string SymmetricSecretKey { get; set; }
        public string AuthenticationHeaderName { get; set; }
    }
}
