using AutoMapper;

namespace Delivery.Api
{
    public class Startup : Interface.IStartup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        public void Configure(WebApplication app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IMapper mapper)
        {
            throw new NotImplementedException();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            throw new NotImplementedException();
        }
    }
}
