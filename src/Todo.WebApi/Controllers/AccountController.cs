using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Model.Identity;
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
        public async Task<IActionResult> RegisterAccount()
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = "test@gmail.com",
                EmailConfirmed = true,
                UserName = "test"
            };

            try
            {
                bool created = await this.userStorage.CreateAsync(user, "Password1!");
            }
            catch (Exception ex)
            {

                throw;
            }


            return Created($"/accounts/{user.Id}", user);
        }
    }
}
