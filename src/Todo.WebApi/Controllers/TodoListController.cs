using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Repository.Context;

namespace Todo.WebApi.Controllers
{
    [Route("todo-lists")]
    public class TodoListController : Controller
    {
        public TodoListController(TodoDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public TodoDbContext DbContext { get; }

        [HttpGet("{id}")]
        public Task<IActionResult> GetAsync(string id)
        {
            return Task.FromResult<IActionResult>(Ok(DbContext != null));
        }
    }
}
