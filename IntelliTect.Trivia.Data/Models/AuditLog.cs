using IntelliTect.Coalesce.AuditLogging;

namespace IntelliTect.Trivia.Data.Models;

[Read(SecurityPermissionLevels.AllowAuthorized)]
public class AuditLog : DefaultAuditLog
{
    // TODO: Track UserId when we add a user model... 
}
