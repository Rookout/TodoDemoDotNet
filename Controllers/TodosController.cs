using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoDemoDotNet.Models;
using Newtonsoft.Json;
using TodoDemoDotNet.NakedBody;
using HugeLib;

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



            HugeLib.Class0 cl0 = new HugeLib.Class0();
            HugeLib.Class10 cl10 = new HugeLib.Class10();

            HugeLib2.Class0 cl20 = new HugeLib2.Class0();
            HugeLib2.Class10 cl210 = new HugeLib2.Class10();

            HugeLib3.Class0 cl2a0 = new HugeLib3.Class0();
            HugeLib3.Class10 cl2a10 = new HugeLib3.Class10();

            HugeLib4.Class0 cl230 = new HugeLib4.Class0();
            HugeLib4.Class10 cl2d10 = new HugeLib4.Class10();

            HugeLib5.Class0 cl250 = new HugeLib5.Class0();
            HugeLib5.Class10 cl2u10 = new HugeLib5.Class10();

            HugeLib6.Class0 cl280 = new HugeLib6.Class0();
            HugeLib6.Class10 cl2k10 = new HugeLib6.Class10();

            HugeLib7.Class0 cl270 = new HugeLib7.Class0();
            HugeLib7.Class10 cl2f10 = new HugeLib7.Class10();

            HugeLib8.Class0 cl2t0 = new HugeLib8.Class0();
            HugeLib8.Class10 cl2tt10 = new HugeLib8.Class10();

            HugeLib9.Class0 cl2yy0 = new HugeLib9.Class0();
            HugeLib9.Class10 cl2888810 = new HugeLib9.Class10();

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
    }
}
