using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Model.Identity;

namespace Todo.Domain.Storage.Identity
{
    public interface IUserManager
    {
        Task<bool> CreateAsync(User user, string password);
    }
}
