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
           new TodoRecord{ ID=Guid.NewGuid().ToString() , Title="Add more todos", Completed=false }
        };


        // GET api/todos
        [HttpGet]
        public IHttpActionResult ListTodos()
        {
            var jsonResponse = new { data = todoRecords };
            return Ok(jsonResponse);
        }

        // GET api/todos/get/UUID-HERE
        [HttpGet]
        public IHttpActionResult GetById(string id)
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
            newTodoRecord.ID = Guid.NewGuid().ToString();
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

        // DELETE api/todos/delete/UUID-HERE
        [HttpDelete]
        public IHttpActionResult DeleteTodo(string id)
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

        // POST api/todos/dup/UUID-HERE
        [HttpPost]
        public IHttpActionResult Duplicate(string id)
        {
            TodoRecord currentTodo = todoRecords.FirstOrDefault((todo) => todo.ID == id);
            if (currentTodo == null)
            {
                return NotFound();
            }
            TodoRecord duplicateTodo = new TodoRecord()
            {
                ID = Guid.NewGuid().ToString(),
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
        // DELETE api/todos/delete_all
        [HttpDelete]
        public IHttpActionResult DeleteAllItems() 
        {
             todoRecords.RemoveAll((todo) => true);
            var jsonResponse = new { data = "OK" };
            return Ok(jsonResponse);
        }
    }
}
