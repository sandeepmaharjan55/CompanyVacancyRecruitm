using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstTask_Project.Models
{
   
    public class Person
    {

        public int PersonId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Experience Experience { get; set; }
        public int ExperienceId { get; set; }
        public string Gender { get; set; }
        public int Contactno { get; set; }
        public string Email { get; set; }

        public virtual ICollection<PersonToSkill> PersonToSkills { get; set; }
    }
    public class LoginViewModel
    {
        [Required]
        [DisplayName("User Name")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("User Name")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Contactno { get; set; }

    }

}