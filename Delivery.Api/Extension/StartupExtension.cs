using AutoMapper;
using ICSharpCode.SharpZipLib.Zip;
using NPOI.HSSF.Record;
using System;

namespace Delivery.Api.Extension
{
    public static class StartupExtension
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder builder, IConfiguration configuration) where TStartup : Interface.IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), builder.Configuration, builder.Environment) as Interface.IStartup;

            if (startup == null)
                throw new InvalidOperationException("Startup inválido");

            var mapperConfig = new MapperConfiguration(mc =>
            {
                // mc.AddProfile(new AutenticacaoProfile());
            });

            builder.WebHost.UseConfiguration(configuration);

            var app = builder.Build();

            startup.Configure(app, builder.Environment, app.Services.GetRequiredService<ILoggerFactory>(), mapperConfig.CreateMapper());

            app.Run();

            return builder;
        }
    }
}
