using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Repository.Context;
using Todo.Domain.Model.Identity;

namespace Todo.Repository.Identity
{
    public class UserRepository : UserStore<User, Role, TodoDbContext, Guid>
    {
        public UserRepository(TodoDbContext context) 
            : base(context)
        {
        }
    }
}
