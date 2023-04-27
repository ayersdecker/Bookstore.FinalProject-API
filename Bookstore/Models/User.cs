using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models;

[Table("users")]
public class User
{
    [Column("id")]
    public int ID { get; set; }
    [Column("username")]
    public string Username { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("email_address")]
    public string Email { get; set; }
    [Column("profile_picture")]
    public string ProfilePicture { get; set; }
}