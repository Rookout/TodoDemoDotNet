using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TodoDemoDotNet
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            /*config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );*/

            config.Routes.MapHttpRoute(
                name: "AddTodo",
                routeTemplate: "api/{controller}/add",
                new { controller = "todos", action = "AddTodo" }
            );

            config.Routes.MapHttpRoute(
                name: "ListTodos",
                routeTemplate: "api/{controller}",
                new { controller = "todos", action = "ListTodos" }
            );

            config.Routes.MapHttpRoute(
                name: "GetById",
                routeTemplate: "api/{controller}/get/{id}",
                new { controller = "todos", action = "GetById", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DeleteTodo",
                routeTemplate: "api/{controller}/delete/{id}",
                new { controller = "todos", action = "DeleteTodo", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "UpdateTodo",
                routeTemplate: "api/{controller}/update",
                new { controller = "todos", action = "UpdateTodo" }
            );

            config.Routes.MapHttpRoute(
                name: "DuplicateTodo",
                routeTemplate: "api/{controller}/dup/{id}",
                new { controller = "todos", action = "Duplicate", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ClearCompletedTodos",
                routeTemplate: "api/{controller}/clear_completed",
                new { controller = "todos", action = "ClearCompleted" }
            );

                config.Routes.MapHttpRoute(
                name: "DeleteAllItems",
                routeTemplate: "api/{controller}/delete_all",
                new { controller = "todos", action = "DeleteAllItems" }
            );
        }
    }
}
