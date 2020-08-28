using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace schoolwebsite.Models
{
    public class Results
    {
        public int id { get; set; }
        [Required]
        public int Studentsid { get; set; }
        [Required]
        public int year { get; set; }
        public Students Students { get; set; }
        [Display(Name ="Class")]
        public int Subjectsid { get; set; }
        [ForeignKey("Subjectsid")]
        public Subjects Subjects { get; set; }
        public String Result1 { get; set; }
        public String Result2 { get; set; }
        public String Result3 { get; set; }
        public String Result4 { get; set; }
        public String Result5 { get; set; }
        public String Result6 { get; set; }
        public String Result7 { get; set; }
        public String Result8 { get; set; }
        public String Result9 { get; set; }

        public String Result10 { get; set; }

        public String Result11 { get; set; }
        public String Result12 { get; set; }
        public Attendance Attendances { get; set; }




    }
}
