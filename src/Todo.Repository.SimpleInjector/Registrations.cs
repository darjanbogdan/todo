using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using System;
using Todo.Domain.Model.Identity;
using Todo.Repository.Context;
using Todo.Repository.Identity;

namespace Todo.Repository.SimpleInjector
{
    public static class Registrations
    {
        public static void BootstrapRepository(this Container container, IConfiguration configuration)
        {
            RegisterDatabaseContext(container, configuration);
            RegisterRepositories(container);
            RegisterStorages(container);
        }

        private static void RegisterDatabaseContext(Container container, IConfiguration configuration)
        {
            container.RegisterSingleton(() => new TodoDbContextConfiguration(configuration.GetConnectionString("TodoConnection")));
            container.Register(() => new TodoDbContext(container.GetInstance<TodoDbContextConfiguration>()), Lifestyle.Scoped);
        }

        private static void RegisterRepositories(Container container)
        {
            container.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            container.Register<IUserStore<User>, UserRepository>();
            container.Register<IRoleStore<Role>, RoleRepository>();
        }

        private static void RegisterStorages(Container container)
        {

        }
    }
}
