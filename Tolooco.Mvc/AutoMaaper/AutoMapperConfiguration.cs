using AutoMapper;

namespace Tolooco.Mvc.AutoMaaper
{
    public class AutoMapperConfiguration
    {
        public static IMapper Mapper;
        public static void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
            });

            Mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }
    }
}