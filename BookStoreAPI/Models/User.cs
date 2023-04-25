using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAPI.Models;

[Table("users")]
public class User
{
    public int ID { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string ProfilePicture { get; set; }
}