using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.WebApi.Composition
{
    public static class WebApiBoostrapper
    {
        public static void BootstrapWebApi(this Container container, IApplicationBuilder builder, IConfiguration configuration)
        {
            container.RegisterMvcControllers(builder);

            //container.RegisterSingleton(() => new RequestContextFactory(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>()));
            //container.Register<IPipelineContext>(() => container.GetInstance<RequestContextFactory>().Create(), Lifestyle.Scoped);
        }
    }
}
