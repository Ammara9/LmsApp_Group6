using Microsoft.AspNetCore.Identity;

namespace LMS.Blazor;

//Only used with Usermanager
//No navigationproperties or FK here!!!
public class ApplicationUser : IdentityUser
{
    // Om vi för tillfället ska kunna spara direkt från blazor får inte denna vara null
    // TODO: När vi fixat att spara via backend API kan vi ta bort den här property
    public DateTime RefreshTokenExpireTime { get; set; } = DateTime.Now + TimeSpan.FromHours(1);

}
