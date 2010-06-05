using AutoMapper;
using Stable.Core.Domain;
using Stable.Models;

namespace Stable
{
	public static class AutoMapperConfiguration
	{
		public static void Configure()
		{
			Mapper.CreateMap<Product, ProductListModel>();
			Mapper.CreateMap<Product, ProductForm>();
		}
	}
}