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
	public class JWTHandler1: IJWTHandler1
	{
		#region Fields
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IConfiguration _configuration;
		
		#endregion

		public JWTHandler1(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
		{
			_httpContextAccessor = httpContextAccessor;
			_configuration = configuration;
			
		}
		public string GenerateToken(JWTDTO data)
		{
			int ExpireHours = 5;
			var session_key = "login_session_" + data.user_id + "_" + Tools.GetNewGUID();
			//Redis.SetValue(session_key, data.loginName, TimeSpan.FromMinutes(ExpireHours * 60));

			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AuthenticationInformation").Get<AuthenticationInformation>().SymmetricSecretKey));

			//var symmetricSecretKeyString = _configuration.GetSection("AuthenticationInformation").Get<AuthenticationInformation>().SymmetricSecretKey;
			//var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(symmetricSecretKeyString));

			var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
			var tokeOptions = new JwtSecurityToken(
				claims: new List<Claim>
				{
					new Claim("admin", data.admin.ToString()),
					new Claim("user_id", data.user_id.ToString()),
					new Claim("company_id", data.company_id.ToString()),
					new Claim("my_company_id", data.my_company_id.ToString()),
					new Claim("company_min_credit", data.company_min_credit.ToString()),
					new Claim("roleId", data.roleId.ToString()),
					new Claim("licenseNo", data.licenseNo),
					new Claim("mobile", data.mobile),
					new Claim("loginName", data.loginName),
					new Claim("email", data.email),
					new Claim("logged_in", data.logged_in.ToString()),
					new Claim("session_key", session_key),
					new Claim("services", String.Join(",",data.services)),
					new Claim("type", data.type),
				},
				expires: DateTime.Now.AddHours(ExpireHours),
				signingCredentials: signinCredentials
			);
			return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
		}
	}
}
