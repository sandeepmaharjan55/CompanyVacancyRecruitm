using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstTask_Project.Models
{
    public class PersonToSkill
    {
        public int PersonToSkillId { get; set; }
        public int PersonId { get; set; }
        public int SkillId { get; set; }
        public int ExperienceId { get; set; }
      
        public virtual Person Person { get; set; }
        public virtual Skill Skill { get; set; }
      

    }
}