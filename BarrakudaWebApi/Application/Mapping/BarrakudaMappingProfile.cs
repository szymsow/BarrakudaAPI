namespace Application.Mapping
{
    public class BarrakudaMappingProfile : Profile
    {
        public BarrakudaMappingProfile()
        {
            CreateMap<RegisterDto, User>();
        }
    }
}
