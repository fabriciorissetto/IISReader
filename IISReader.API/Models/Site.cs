using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IISReader.API.Models
{
    public class Site
    {
        public string Name { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}