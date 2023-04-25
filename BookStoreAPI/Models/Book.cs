using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAPI.Models;
[Table("books")]
public class Book
{
    public int ID { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Edition { get; set; }
    public string Description { get; set; }
    public string ISBN { get; set; }
    public string Condition { get; set; }
    public int SellerID { get; set; }
    public int CourseID { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
}