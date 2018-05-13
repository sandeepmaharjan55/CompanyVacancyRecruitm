using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstTask_Project.Models
{
    public class RecruitmentRequest
    {
      [Key]
        public int RecruitId { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? RequestDate { get; set; }
        public int NumOfOpening { get; set; }
        public DateTime? Deadline { get; set; }   
        public int Exp { get; set; }
        
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}