using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace schoolwebsite.Models
{
    public class Studentdetails
    {
        public int id { get; set; }

        
        public Students Students { get; set; }
        
        public Results Results { get; set; }

        public Subjects Subjects { get; set; }

        
    }
}
