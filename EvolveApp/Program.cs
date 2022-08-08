using System.Data.SqlClient;

namespace EvolveApp
{
    public class Program
    {
        private static readonly string EnvironmentName;
        private static readonly IConfiguration Configuration;

        static Program()
        {
            EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();
        }

        public static void Main(string[] args)
        {
            MigrateDatabase();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            app.Run();
        }

        private static void MigrateDatabase()
        {
            try
            {
                var location = "Data/Migrations";

                var cnx = new SqlConnection(Configuration.GetConnectionString("local"));
                var evolve = new Evolve.Evolve(cnx)
                {
                    Locations = new[] { location },
                    IsEraseDisabled = true,
                    TransactionMode = Evolve.Configuration.TransactionKind.CommitAll
                };

                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database migration failed:\n" + ex);
                throw;
            }
        }
    }
}
