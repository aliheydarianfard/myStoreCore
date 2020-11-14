using identity.AuthenticateHandlers.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using identity.AuthenticateHandlers;
using Utilities;
namespace StoreCore
{
	public interface IJWTHandler1
	{
		string GenerateToken(JWTDTO data);
	}
}
