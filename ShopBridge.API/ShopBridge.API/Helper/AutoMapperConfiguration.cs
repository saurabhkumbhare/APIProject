using AutoMapper;
using ShopBridge.API.Model;
using ShopBridge.API.ViewModel;

namespace ShopBridge.API.Helper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Item, ItemVM>();
            CreateMap<ItemVM, Item>();
        }
    }
}
