using Microsoft.AspNetCore.Identity;

namespace WebApi.Models;

public class User : IdentityUser
{
    public User() { }
    public DateTime BirthDate { get; set; }
}
