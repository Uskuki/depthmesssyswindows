namespace Environment.Mapper
{
    using AutoMapper;

    public interface IAutoMapperConfiguration
    {   
    }
    
    public class AutoMapperConfiguration : IAutoMapperConfiguration
    {
        public AutoMapperConfiguration()
        {
            
        }

        static AutoMapperConfiguration()
        {
            Configure();
        }

        private static void Configure()
        {
            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}