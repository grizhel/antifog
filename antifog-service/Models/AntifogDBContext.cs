using antifog_service.Models.Basics;
using Grizhla.UtilitiesCore.EF;
using Microsoft.EntityFrameworkCore;

namespace antifog_service.Models;

public class AntifogDBContext : GrizhlaDBContext
{
	private readonly IConfiguration configuration;

	public AntifogDBContext(DbContextOptions options, IConfiguration configuration) : base(options, bool.Parse(configuration["GrizhlaSettings:GrizhlaDBSettings:HistoryEnabled"] ?? "true"))
	{
		this.configuration = configuration;
	}

	public DbSet<FoggyInformation> FoggyInformation { get; set; }

	public DbSet<FoggyTag> FoggyTag { get; set; }

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		base.ConfigureConventions(configurationBuilder);
		_ = configurationBuilder.Properties<DateTime>().HaveColumnType("timestamp");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var defaultSchema = configuration.GetConnectionString("DefaultSchema");
		modelBuilder.HasDefaultSchema(defaultSchema);
		base.OnModelCreating(modelBuilder);
	}
}
