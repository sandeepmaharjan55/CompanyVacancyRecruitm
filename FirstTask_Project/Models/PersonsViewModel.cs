using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstTask_Project.Models
{
    public class PersonsViewModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public Experience Experience { get; set; }
        public int ExpId { get; set; }
        public int Contactno { get; set; }
        public string Email { get; set; }
        public List<CheckBoxViewModel> Skills { get; set; }
    }
}