using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using System;
using Todo.Domain.Model.Identity;
using Todo.Domain.Storage.Identity;

namespace Todo.Domain.Identity.SimpleInjector
{
    public static class Registrations
    {
        public static void BootstrapIdentity(this Container container, IConfiguration configuration)
        {
            Registration userManagerRegistration = Lifestyle.Transient.CreateRegistration<UserManager>(container);
            container.AddRegistration<UserManager<User>>(userManagerRegistration);
            container.AddRegistration<IUserStorage>(userManagerRegistration);

            Registration roleManagerRegistration = Lifestyle.Transient.CreateRegistration<RoleManager>(container);
            container.AddRegistration<RoleManager<Role>>(roleManagerRegistration);
            container.AddRegistration<IRoleStorage>(roleManagerRegistration);
        }
    }
}
