using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VentePc.Areas.Identity.Data;
using VentePc.Data;

[assembly: HostingStartup(typeof(VentePc.Areas.Identity.IdentityHostingStartup))]
namespace VentePc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<VentePcContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("VentePcContextConnection")));

                services.AddDefaultIdentity<VentePcUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<VentePcContext>();
            });
        }
    }
}