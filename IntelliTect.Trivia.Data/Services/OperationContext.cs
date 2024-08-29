using IntelliTect.Coalesce.AuditLogging;
using IntelliTect.Trivia.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IntelliTect.Trivia.Data.Services;
public class OperationContext : DefaultAuditOperationContext<AuditLog>
{
    public OperationContext(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) { }

    public override void Populate(AuditLog auditEntry, EntityEntry changedEntity)
    {
        base.Populate(auditEntry, changedEntity);

        // TODO: Map UserId
    }
}
