using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstTask_Project.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Skills { get; set; }

        public virtual ICollection<PersonToSkill> PersonToSkills { get; set; }
        
    }
}