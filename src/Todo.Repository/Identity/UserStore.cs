using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.DataAccess.Context;
using Todo.Domain.Model.Identity;

namespace Todo.DataAccess.Identity
{
    public class UserStore : UserStore<User, Role, TodoDbContext, Guid>
    {
        public UserStore(TodoDbContext context) 
            : base(context)
        {
        }
    }
}
