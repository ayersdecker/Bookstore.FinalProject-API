using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models;
[Table("books")]
public class Book
{
    [Column("id")]
    public int ID { get; set; }
    [Column("author")]
    public string Author { get; set; }
    [Column("title")]
    public string Title { get; set; }
    [Column("edition")]
    public string Edition { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("isbn")]
    public string ISBN { get; set; }
    [Column("bookCondition")]
    public string Condition { get; set; }
    [Column("seller_id")]
    public int SellerID { get; set; }
    [Column("course_id")]
    public int CourseID { get; set; }
    [NotMapped]
    public double Price { get; set; }
    [NotMapped]
    public string Image { get; set; }
    
    
}