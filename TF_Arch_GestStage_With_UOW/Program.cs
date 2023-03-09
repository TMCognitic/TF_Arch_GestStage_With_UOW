using TF_Arch_GestStage_With_UOW.Models.Repositories;
using TF_Arch_GestStage_With_UOW.Models.Services;

namespace TF_Arch_GestStage_With_UOW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = builder.Configuration;
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient("Api", (client) =>
            {
                client.BaseAddress = new Uri(configuration["ApiUri"]);
            });

            builder.Services.AddScoped<IStageRepository, StageService>();
            builder.Services.AddScoped<IEnfantRepository, EnfantService>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}