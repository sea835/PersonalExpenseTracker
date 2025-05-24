using PersonalExpenseTracker.Context;
using PersonalExpenseTracker.Interface;
using PersonalExpenseTracker.Repository;
using PersonalExpenseTracker.Services;

namespace PersonalExpenseTracker;

using PersonalExpenseTracker.Context;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
        builder.Services.AddScoped<IExpenseService, ExpenseService>();
        
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();       
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
            )
        );
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Expense}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}