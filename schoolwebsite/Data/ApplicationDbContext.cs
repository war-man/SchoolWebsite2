using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using schoolwebsite.Models;

namespace schoolwebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<schoolwebsite.Models.Students> Students { get; set; }
        public DbSet<schoolwebsite.Models.Teachers> Teachers { get; set; }
        public DbSet<schoolwebsite.Models.Results> Results { get; set; }
        public DbSet<schoolwebsite.Models.Subjects> Subjects { get; set; }

        public DbSet<schoolwebsite.Models.Studentdetails> Studentdetails { get; set; }

        public DbSet<schoolwebsite.Models.Attendance>Attendances{ get; set; }
        public DbSet<schoolwebsite.Models.UserRole> UserRole{ get; set; }
    }
}
