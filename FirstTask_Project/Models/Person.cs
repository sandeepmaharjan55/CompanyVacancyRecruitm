using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstTask_Project.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public Experience Experience { get; set; }
        public int ExpId { get; set; }

        public virtual ICollection<PersonToSkill> PersonToSkills { get; set; }
    }
}