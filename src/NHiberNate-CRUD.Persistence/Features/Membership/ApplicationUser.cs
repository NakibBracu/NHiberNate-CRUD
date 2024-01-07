using Microsoft.AspNetCore.Identity;
using System;

namespace NHiberNate_CRUD.Persistence.Features.Membership
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ApplicationUser()
        {
        }
    }
}
