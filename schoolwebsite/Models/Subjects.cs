using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolwebsite.Models
{
    public class Subjects
    {
        public int id { get; set; }
        [Required]        
        public string Class { get; set; }
        [Required]
        public string Exam { get; set; }

        public string Subject1 { get; set; }
       

        public string Subject2 { get; set; }
        

        public string Subject3 { get; set; }
        

        public string Subject4 { get; set; }
        

        public string Subject5 { get; set; }
       

        public string Subject6 { get; set; }
        

        public string Subject7 { get; set; }
        

        public string Subject8 { get; set; }
        

        public string Subject9 { get; set; }
        

        public string Subject10 { get; set; }
        

        public string Subject11 { get; set; }
        

        public string Subject12 { get; set; }
        

        

    }
}
