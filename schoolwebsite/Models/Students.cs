using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace schoolwebsite.Models
{
    public class Students

    {

        public Students()
        {
            DateCreated = DateTime.Now;
            
        }
        
        public int id { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM,dd  yyyy  hh:mm}")]
        public DateTime? DateCreated { get; set; }
              
        [Required]
        public string Name { get; set; }
        [Required]
        public int classinfo { get; set; }
        [Required]
        public int roll { get; set; }
        [Required]
        public string section{ get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string parentscontact { get; set; }
        [Required]
        public string username { get; set; }
        
        public string dateofbirth { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        
        public string Imagefilename { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

        public List<Subjects> results { get; set; }




    }
}
