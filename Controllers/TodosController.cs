using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoDemoDotNet.Models;
using Newtonsoft.Json;
using TodoDemoDotNet.NakedBody;

namespace TodoDemoDotNet.Controllers
{
    public class TodosController : ApiController
    {
        static List<TodoRecord> todoRecords = new List<TodoRecord> {
           new TodoRecord{ ID=1, Title="A", Completed=false },
           new TodoRecord{ ID=2, Title="B", Completed=false },
           new TodoRecord{ ID=3, Title="C", Completed=false },
        };


        // GET api/todos
        [HttpGet]
        public IHttpActionResult ListTodos()
        {
            var jsonResponse = new { data = todoRecords };
            return Ok(jsonResponse);
        }

        // GET api/todos/get/5
        [HttpGet]
        public IHttpActionResult GetById(int id)
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

        // POST api/todos/add
        [HttpPost]
        public IHttpActionResult AddTodo([NakedBody]string value)
        {
            TodoRecord newTodoRecord = JsonConvert.DeserializeObject<TodoRecord>(value);
            newTodoRecord.ID = todoRecords.Last().ID + 1;
            todoRecords.Add(newTodoRecord);
            var jsonResponse = new { data = "OK" };
            return Ok(jsonResponse);
        }

        // PUT api/todos/update
        [HttpPut]
        public IHttpActionResult UpdateTodo([NakedBody]string value)
        {
            TodoRecord updatedTodoRecord = JsonConvert.DeserializeObject<TodoRecord>(value);
            TodoRecord currentTodo = todoRecords.FirstOrDefault((todo) => todo.ID == updatedTodoRecord.ID);
            if (currentTodo == null)
            {
                return NotFound();
            }
            int indexOfRecord = todoRecords.IndexOf(currentTodo);
            todoRecords[indexOfRecord] = updatedTodoRecord;
            var jsonResponse = new { data = "OK" };
            return Ok(jsonResponse);
        }

        // DELETE api/todos/delete/5
        [HttpDelete]
        public IHttpActionResult DeleteTodo(int id)
        {
            TodoRecord currentTodo = todoRecords.FirstOrDefault((todo) => todo.ID == id);
            if (currentTodo == null)
            {
                return NotFound();
            }
            int indexOfRecord = todoRecords.IndexOf(currentTodo);
            todoRecords.RemoveAt(indexOfRecord);
            var jsonResponse = new { data = "OK" };
            return Ok(jsonResponse);
        }

        // POST api/todos/dup/5
        [HttpPost]
        public IHttpActionResult Duplicate(int id)
        {
            TodoRecord currentTodo = todoRecords.FirstOrDefault((todo) => todo.ID == id);
            if (currentTodo == null)
            {
                return NotFound();
            }
            TodoRecord duplicateTodo = new TodoRecord()
            {
                ID = todoRecords.Last().ID + 1,
                Title = currentTodo.Title,
                Completed = currentTodo.Completed
            };
            todoRecords.Add(duplicateTodo);
            var jsonResponse = new { data = "OK" };
            return Ok(jsonResponse);
        }

        // DELETE api/todos/clear_completed
        [HttpDelete]
        public IHttpActionResult ClearCompleted()
        {
            todoRecords.RemoveAll((todo) => todo.Completed == true);
            var jsonResponse = new { data = "OK" };
            return Ok(jsonResponse);
        }
    }
}
