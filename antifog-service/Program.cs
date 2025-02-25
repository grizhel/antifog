using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using antifog_service.Models;
using Grizhla.UtilitiesCore.Helpers.Converters;
using antifog_service.Services.Primary;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
	options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	options.JsonSerializerOptions.Converters.Add(new JsonDecimalConverter());
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}); ;

builder.Services.AddHttpClient();

builder.Services.AddScoped<FoggyTagService>();

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

WebApplication app = builder.Build();



app.UseCors(x => x.SetIsOriginAllowed(t => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


#if DEBUG
app.UseSwagger();
app.UseSwaggerUI();
using IServiceScope serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
using AntifogDBContext context = serviceScope.ServiceProvider.GetService<AntifogDBContext>()!;
context!.Database.Migrate();
#endif


app.Run();


