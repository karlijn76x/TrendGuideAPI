using Microsoft.EntityFrameworkCore;
using FunnelTrendRadarAPI.Models.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    public DbSet<Trend> Trend { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Trend>()
            .Property(t => t.Category)
            .HasConversion<string>();

        modelBuilder.Entity<Trend>()
            .Property(t => t.TrendType)
            .HasConversion<string>();
    }
}
