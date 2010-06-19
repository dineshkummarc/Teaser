using AutoMapper;
using Teaser.Entities;
using Teaser.Web.Models;


namespace Teaser.Web.Core
{
	public static class AutoMapperConfiguration
	{
		public static void Configure()
        {
            Mapper.CreateMap<Product, ProductListModel>();
            Mapper.CreateMap<Product, ProductForm>();
            Mapper.CreateMap<RpxUser, RpxUserModel>();
            Mapper.CreateMap<SiteUser, SiteUserModel>();
            Mapper.CreateMap<UserProfile, UserProfileModel>(); 
 
		}
	}
}