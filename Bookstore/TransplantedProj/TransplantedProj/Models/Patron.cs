using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models;

[Table("patron")]
public class Patron
{
    [Column("id")]
    public int ID { get; set; } 
}