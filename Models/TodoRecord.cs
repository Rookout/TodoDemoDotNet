using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoDemoDotNet.Models
{
    public class TodoRecord
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}