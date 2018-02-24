using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Identity;
using Todo.Domain.Model.Identity;
using Todo.Domain.Storage.Identity;

namespace Todo.WebApi.Composition
{
    public static class IdentityBootstrapper
    {
        public static void BootstrapIdentity(this Container container, IApplicationBuilder builder, IConfiguration configuration)
        {
            RegisterUserManager(container, builder);
            RegisterRoleManager(container, builder);
        }

        private static void RegisterRoleManager(Container container, IApplicationBuilder builder)
        {
            container.CrossWire<ILookupNormalizer>(builder);
            container.CrossWire<ILogger<RoleManager>>(builder);

            container.Register<IRoleManager, RoleManager>(Lifestyle.Scoped);
        }

        private static void RegisterUserManager(Container container, IApplicationBuilder builder)
        {
            container.CrossWire<IOptions<IdentityOptions>>(builder);
            container.CrossWire<IPasswordHasher<User>>(builder);
            container.CrossWire<ILogger<UserManager>>(builder);

            container.Register<IUserManager, UserManager>(Lifestyle.Scoped);
        }
    }
}
