using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliTect.Trivia.Data.Models;

[Read(SecurityPermissionLevels.AllowAll)]
[Edit(Roles.Admin)]
[Create(SecurityPermissionLevels.DenyAll)]
[Delete(SecurityPermissionLevels.DenyAll)]
public class AppUser: IdentityUser
{
}
