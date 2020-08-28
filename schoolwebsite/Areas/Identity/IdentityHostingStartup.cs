using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using schoolwebsite.Data;

[assembly: HostingStartup(typeof(schoolwebsite.Areas.Identity.IdentityHostingStartup))]
namespace schoolwebsite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<schoolwebsiteContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("schoolwebsiteContextConnection")));

                //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                 //   .AddEntityFrameworkStores<schoolwebsiteContext>();
            });
        }
    }
}