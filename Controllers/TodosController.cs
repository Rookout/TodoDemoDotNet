using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoDemoDotNet.Models;

namespace TodoDemoDotNet.Controllers
{
    public class TodosController : ApiController
    {
        List<TodoRecord> todoRecords = new List<TodoRecord> {
           new TodoRecord{ ID=1, Title="A", Completed=false },
           new TodoRecord{ ID=2, Title="B", Completed=false },
           new TodoRecord{ ID=3, Title="C", Completed=false },
        };


        // GET api/todos
        public IHttpActionResult Get()
        {
            var jsonResponse = new { data = todoRecords };
            return Ok(jsonResponse);
        }

        // GET api/todos/5
        public IHttpActionResult Get(int id)
        {
            TodoRecord requestedTodo;
            requestedTodo = todoRecords.FirstOrDefault((todo) => todo.ID == id);
            if (requestedTodo == null)
            {
                return NotFound();
            }
            var jsonResponse = new { data = requestedTodo };
            return Ok(jsonResponse);
        }

        // POST api/todos
        public void Post([FromBody]string value)
        {
        }

        // PUT api/todos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/todos/5
        public void Delete(int id)
        {
        }
    }
}
