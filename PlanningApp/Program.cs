using Microsoft.EntityFrameworkCore;

namespace PlanningApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register DbContext
            builder.Services.AddDbContext<PlanningDbContext>(options =>
                options.UseSqlite("Data Source=Planning.db"));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Initialize database on startup
            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<PlanningDbContext>();
                PlanningDbInitializer.Initialize(ctx);
            }   

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
