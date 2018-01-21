using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Model.Identity;
using Todo.Domain.Storage.Identity;

namespace Todo.Domain.Identity
{
    public class UserManager : UserManager<User>, IUserStorage
    {
        public UserManager(
            IUserStore<User> store, 
            IOptions<UserManagerOptions> optionsAccessor, 
            IPasswordHasher<User> passwordHasher, 
            IServiceProvider services, 
            ILogger<UserManager> logger) 
            : base(
                store, 
                optionsAccessor, 
                passwordHasher, 
                userValidators: null, 
                passwordValidators: null, 
                keyNormalizer: null, 
                errors: null, 
                services, 
                logger)
        {
        }
    }
}
