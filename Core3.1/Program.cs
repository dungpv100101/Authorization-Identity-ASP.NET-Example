using Core3._1.Authorization.Handler;
using Core3._1.Authorization.Requirement;
using Core3._1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        string connectionString = builder.Configuration.GetConnectionString("default");
        builder.Services.AddDbContext<AppDBContext>(c => c.UseSqlServer(connectionString));
        builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDBContext>();

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("Employee", "5", "6", "4"));
            options.AddPolicy("DevUser",
                    policy => policy.RequireAssertion(
                        context => context.User.HasClaim(claim => claim.Type == "Dev")
                            || context.User.HasClaim(claim => claim.Type == "IT")
                            || context.User.IsInRole("User")));
        });


        builder.Services.AddSingleton<IAuthorizationHandler, IsAccountNotDisabledHandler>();
        builder.Services.AddSingleton<IAuthorizationHandler, IsEmployeeHandler>();
        builder.Services.AddSingleton<IAuthorizationHandler, IsVIPCustomerHandler>();

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("canManageProduct",
                policyBuilder =>
                    policyBuilder.AddRequirements(
                        new IsAccountEnabledRequirement(),
                        new IsAllowedToManageProductRequirement()
                    ));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}