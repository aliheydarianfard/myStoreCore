using System;
using System.Collections.Generic;
using System.Text;

namespace identity.AuthenticateHandlers.DTOs
{
	public class JWTDTO
	{
		public bool admin { get; set; }
		public int user_id { get; set; }
		public int company_id { get; set; }
		public int my_company_id { get; set; }
		public int company_min_credit { get; set; }
		public int driver_id { get; set; }
		public int roleId { get; set; }
		public string licenseNo { get; set; }
		public string mobile { get; set; }
		public string loginName { get; set; }
		public string email { get; set; }
		public bool logged_in { get; set; }
		public List<int> services { get; set; }
		public string type { get; set; }
	}
}
