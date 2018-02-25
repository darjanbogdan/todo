using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Model.Identity;

namespace Todo.DataAccess.Context
{
    public class TodoDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public TodoDbContext(TodoDbContextConfiguration configuration)
            : this(CreateDbContextOptions(configuration))
        {
        }

        public TodoDbContext(DbContextOptions<TodoDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        private static DbContextOptions<TodoDbContext> CreateDbContextOptions(TodoDbContextConfiguration configuration) => 
            new DbContextOptionsBuilder<TodoDbContext>()
                .UseSqlServer(configuration.ConnectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
    }
}
