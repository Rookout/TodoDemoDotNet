using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoDemoDotNet.Models
{
    public class TodoRecord
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}