using identity.AuthenticateHandlers.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace identity.AuthenticateHandlers
{
	public interface IJWTHandler
	{
		string GenerateToken(JWTDTO data);
	}
}
