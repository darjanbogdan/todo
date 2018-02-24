using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Context;
using Todo.Domain.Identity;
using Todo.DataAccess.Context;
using Todo.Domain.Storage.Identity;

namespace Todo.WebApi.Controllers
{
    [Route("todo-lists")]
    public class TodoListController : ControllerBase
    {
        private readonly IUserManager userStorage;

        public TodoListController(IUserManager userStorage)
        {
            this.userStorage = userStorage;
        }

        [HttpGet("")]
        public Task<IActionResult> GetAsync()
        {
            if (this.userStorage != null)
            {

            }

            return Task.FromResult<IActionResult>(Ok());
        }
    }
}
