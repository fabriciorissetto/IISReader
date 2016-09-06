using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IISReader.API.Models
{
    public class Project
    {
        public string Name { get; set; }
        public string Environment { get; set; }
        public List<string> Applications { get; set; } = new List<string>();
    }
}