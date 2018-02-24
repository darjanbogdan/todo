using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Storage.Identity;

namespace Todo.WebApi.Controllers
{
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IUserManager userStorage;

        public AccountController(IUserManager userStorage)
        {
            this.userStorage = userStorage;
        }

        [HttpGet]
        public Task<IActionResult> RegisterAccount()
        {
            return Task.FromResult<IActionResult>(Ok(this.userStorage != null));
        }
    }
}
