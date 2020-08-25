﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quan_ly_vat_tu.Areas.Identity.Data;
using Quan_ly_vat_tu.Data;

[assembly: HostingStartup(typeof(Quan_ly_vat_tu.Areas.Identity.IdentityHostingStartup))]
namespace Quan_ly_vat_tu.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));

                //services.AddDefaultIdentity<ApplicationUser>(options => { 
                //    options.SignIn.RequireConfirmedAccount = false;
                //    options.Password.RequireLowercase = false;
                //    options.Password.RequireUppercase = false;
                //})
                //    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}