using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstTask_Project.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonToSkill> PersonToSkills { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<RecruitmentRequest> RecruitmentRequests { get; set; }

    }
}