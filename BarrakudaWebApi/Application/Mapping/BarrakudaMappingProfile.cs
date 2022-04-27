namespace Application.Mapping
{
    public class BarrakudaMappingProfile : Profile
    {
        public BarrakudaMappingProfile()
        {
            CreateMap<RegisterDto, User>();

            CreateMap<CreateProductDto, Product>();

            CreateMap<Product, ProductDto>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}
