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
        private readonly TodoDbContextConfiguration configuration;

        public TodoDbContext(TodoDbContextConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //Note: Used for EF migrations
        public TodoDbContext(DbContextOptions<TodoDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //Note: Due to EF migrations
            if (this.configuration != null)
            {
                optionsBuilder = new DbContextOptionsBuilder<TodoDbContext>()
                    .UseSqlServer(this.configuration.ConnectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
