using IntelliTect.Coalesce.AuditLogging;
using IntelliTect.Trivia.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IntelliTect.Trivia.Data;

[Coalesce]
public class AppDbContext : IdentityDbContext<AppUser, IAuditLogDbContext<AuditLog>
{
    // Audit Log Models
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<AuditLogProperty> AuditLogProperties { get; set; }

    // Models
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Answer> Answers => Set<Answer>();

    public AppDbContext() { }

    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Remove cascading deletes.
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCoalesceAuditLogging<AuditLog>(x => x.WithAugmentation<OperationContext>());
    }
}
