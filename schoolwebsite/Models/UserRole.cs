using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolwebsite.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="User")]
        public string UserId { get; set; }
        [Required]
        public string RoleId { get; set; }
    }
}
