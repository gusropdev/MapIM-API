using MapIM.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

ConfigureMvc(builder);
ConfigureServices(builder);


var app = builder.Build();

app.UseCors("AllowAllOrigins");
Configure(app);

app.MapControllers();
app.Run();


void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services.AddControllers()
                    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
                    .AddJsonOptions(x =>
                    {
                        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
                    });
}

void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<MapimDataContext>(
        options => options.UseSqlServer(connectionString)
    );

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });
}
void Configure(IApplicationBuilder app)
{
    app.UseRouting();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers(); // Isso deve estar presente para mapear os controladores
    });
}
