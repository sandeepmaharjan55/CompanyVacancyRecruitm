using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstTask_Project.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phoneno { get; set; }
        public string ContactPerson { get; set; }
        public string CompanyURL { get; set; }
        public string Logo { get; set; }
        public string FacebookURL { get; set; }
    }
}