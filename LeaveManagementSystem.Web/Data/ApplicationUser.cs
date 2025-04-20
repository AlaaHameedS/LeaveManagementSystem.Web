using Microsoft.AspNetCore.Identity;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateOnly DateOfBirth { get; set; }
    }
}
