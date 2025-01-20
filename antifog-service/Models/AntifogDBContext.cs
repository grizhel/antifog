using Microsoft.EntityFrameworkCore;

namespace antifog_service.Models;

public class AntifogDBContext : DbContext
{
	private readonly IConfiguration configuration;

	public AntifogDBContext(DbContextOptions options, IConfiguration configuration) : base(options)
	{
		this.configuration = configuration;
	}

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		base.ConfigureConventions(configurationBuilder);
		_ = configurationBuilder.Properties<DateTime>().HaveColumnType("timestamp");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var defaultSchema = configuration.GetConnectionString("DefaultSchema");
		modelBuilder.HasDefaultSchema(defaultSchema);
	}
}
