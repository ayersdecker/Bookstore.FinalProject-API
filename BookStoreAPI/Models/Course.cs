using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAPI.Models;

[Table("courses")]
public class Course
{
    public int ID { get; set; }
    public string Name { get; set; }
}