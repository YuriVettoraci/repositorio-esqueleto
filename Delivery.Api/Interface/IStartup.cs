using AutoMapper;

namespace Delivery.Api.Interface
{
    public interface IStartup
    {
        void Configure(WebApplication app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IMapper mapper);
        void ConfigureServices(IServiceCollection services);
    }
}
