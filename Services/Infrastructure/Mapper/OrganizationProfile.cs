using Ahf.Core.Domain;
using Ahf.Services.DTO.Categories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahf.Services.Infrastructure.Mapper
{
	public class OrganizationProfile:Profile
	{
		public OrganizationProfile()
		{
			CreateMap<CategoryRegisterDTO, Category>().ReverseMap();
		}
	}
}
