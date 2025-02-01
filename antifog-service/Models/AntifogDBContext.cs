using antifog_service.Models.Primary;
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

	public DbSet<FoggyInformation> __FoggyInformation { get; set; }

	public DbSet<FoggyTag> __FoggyTag { get; set; }

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		base.ConfigureConventions(configurationBuilder);
		_ = configurationBuilder.Properties<DateTime>().HaveColumnType("timestamp");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		string defaultSchema = configuration.GetConnectionString("DefaultSchema") ?? "public";
		modelBuilder.HasDefaultSchema(defaultSchema);
		base.OnModelCreating(modelBuilder);
	}
}
