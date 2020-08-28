using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace schoolwebsite.Models
{
    public class PersoninRole
    {
        public int Id { get; set; }
        [ForeignKey("IndentityUserId")]
        public int IndentityUserId { get; set; }
        public UserManager<IdentityUser> identityUser { get; set; }
        public RoleManager<IdentityRole> roleManager { get; set; }

    }
}
