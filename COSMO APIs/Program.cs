using cosmo.core2.Reposatries;
using cosmo.repro;
using cosmo.repro.Data;
using COSMO_APIs.Helper;
using Microsoft.EntityFrameworkCore;

namespace COSMO_APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection"));
            });
             builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(IGenericRepository<>));
            builder.Services.AddAutoMapper(M=>M.AddProfile(new MappingProfiles()));

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();



            #region Update_Database
            // StoreContext dbContext = new StoreContext();
            //await dbContext.Database.MigrateAsync();
using var scope = app.Services.CreateScope();
                var services = scope.ServiceProvider;
            var LoggerFactory=services.GetRequiredService<ILoggerFactory>();    
            try
            {

              
              
                var DbContext = services.GetRequiredService<StoreContext>();
                await DbContext.Database.MigrateAsync();
                await StoreContextSeed.SeedAsync(DbContext);
  
            } catch(Exception ex)
            {
                var Logger= LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex, "An Errore Occered During Appling THE Migration");
            }
            #endregion
            app.Run();
        }
    }
}
