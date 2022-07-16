using Microsoft.AspNetCore.Identity;

namespace bugraGundoganASP.webUI.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
