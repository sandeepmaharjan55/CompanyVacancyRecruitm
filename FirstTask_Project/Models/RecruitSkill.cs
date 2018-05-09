using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstTask_Project.Models
{
    public class RecruitSkill
    {
        public int RecruitSkillId { get; set; }
        public Skill Skill { get; set; }
        public int SkillId { get; set; }
        public RecruitmentRequest RecruitmentRequest { get; set; }
        public int RecruitId { get; set; }
    }
}