using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolwebsite.Models
{
    public class Teachers

    {
        public Teachers()
        {
            DateCreated = DateTime.Now;
            
        }
        public int id { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM,dd  yyyy  hh:mm}")]
        public DateTime? DateCreated { get; set; }
        [Required(ErrorMessage = "Please give your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please give your email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please give your Contact Number")]
        public string ContactNum { get; set; }
        [Required(ErrorMessage = "Please give your Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please give a username for your account")]

        public string Username { get; set; }
        [Required(ErrorMessage = "Please give a correct password")]
        public string password { get; set; }

        


    }
}
