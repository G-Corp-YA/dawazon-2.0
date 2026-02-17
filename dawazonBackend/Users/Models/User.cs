using Microsoft.AspNetCore.Identity;

namespace dawazonBackend.Users.Models;

public class User: IdentityUser<long>
{
    public string Name { get; set; } = string.Empty;
    
}