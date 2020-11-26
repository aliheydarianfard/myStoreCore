using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myShop.Utilities
{
	public class SuccessMessageHandler
	{
		public static IActionResult InsertCategory(	)
		{
			return new OkObjectResult(new MessageTemplate.BaseMessage { Message="دسته مورد نظر با موفقیت ثبت شد" ,Success=true});
		}
	}
}
