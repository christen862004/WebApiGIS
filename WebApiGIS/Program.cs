
namespace WebApiGIS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(option =>
                option.SuppressModelStateInvalidFilter = true);
           
            builder.Services.AddCors(option => {
                option.AddPolicy("myPolicy",
                    policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

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
            app.UseStaticFiles();//mapp any reuqest to wwwroot

            app.UseCors("myPolicy");//allow ,reject setting

            app.UseAuthorization();

            app.MapControllers();//no default route make your own custom route per resourse

            app.Run();
        }
    }
}
