using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using antifog_service.Models;
using antifog_service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
	options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}); ;

builder.Services.AddHttpClient();

builder.Services.AddScoped<BasicsService>();

builder.Services.AddDbContext<AntifogDBContext>(options =>
{
	_ = options.UseNpgsql(builder.Configuration.GetConnectionString("Default"), x
							 => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName,
							 builder.Configuration.GetConnectionString("DefaultSchema")));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement()
		{
				{
						new OpenApiSecurityScheme
						{
								Reference = new OpenApiReference
								{
										Type = ReferenceType.SecurityScheme,
										Id = "Bearer"
								},
								Scheme = "oauth2",
								Name = "Bearer",
								In = ParameterLocation.Header,

						},
						new List<string>()
				}
		});
});





var app = builder.Build();

#if DEBUG
app.UseSwagger();
app.UseSwaggerUI();
using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
using var context = serviceScope.ServiceProvider.GetService<AntifogDBContext>();
context!.Database.Migrate();
#endif

app.UseCors(x => x.SetIsOriginAllowed(t => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
