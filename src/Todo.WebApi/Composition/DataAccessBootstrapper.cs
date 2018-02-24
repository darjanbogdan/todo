using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.DataAccess;
using Todo.DataAccess.Context;
using Todo.DataAccess.Identity;
using Todo.Domain.Model.Identity;

namespace Todo.WebApi.Composition
{
    public static class DataAccessBootstrapper
    {
        public static void BootstrapDataAccess(this Container container, IConfiguration configuration)
        {
            RegisterDatabaseContext(container, configuration);
            RegisterRepositories(container);
        }

        private static void RegisterDatabaseContext(Container container, IConfiguration configuration)
        {
            container.RegisterSingleton(() => new TodoDbContextConfiguration(configuration.GetConnectionString("TodoConnection")));
            container.Register(() => new TodoDbContext(container.GetInstance<TodoDbContextConfiguration>()), Lifestyle.Scoped);
        }

        private static void RegisterRepositories(Container container)
        {
            container.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            container.Register<IUserStore<User>, UserStore>(Lifestyle.Scoped);
            container.Register<IRoleStore<Role>, RoleStore>(Lifestyle.Scoped);
        }
    }
}
