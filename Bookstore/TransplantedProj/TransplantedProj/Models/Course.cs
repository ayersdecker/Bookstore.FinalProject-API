using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models;

[Table("courses")]
public class Course
{
    [Column("id")]
    public int ID { get; set; }
    [Column("NAME")]
    public string Name { get; set; }
}