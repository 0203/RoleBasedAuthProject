using Microsoft.AspNetCore.Identity;

namespace Yt_DotNet6IdentityWeb.Models.Domain
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string ? ProfilePicture { get; set; }
        
    }
}
