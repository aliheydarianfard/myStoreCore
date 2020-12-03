using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myShop.Utilities
{
	public class SuccessMessageHandler
	{
		public static IActionResult InsertCategory()
		{
			return new OkObjectResult(new MessageTemplate.BaseMessage { Message = "دسته مورد نظر با موفقیت ثبت شد", Success = true });
		}
		public static IActionResult EditCategory()
		{
			return new OkObjectResult(new MessageTemplate.BaseMessage { Message = "دسته مورد نظر با موفقیت ویزایش شد", Success = true });
		}
		public static IActionResult DeleteCategory()
		{
			return new OkObjectResult(new MessageTemplate.BaseMessage { Message = "دسته مورد نظر با موفقیت حذف شد", Success = true });
		}
	}
}
