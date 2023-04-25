using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAPI.Models;

[Table("transactions")]
public class Transaction
{
    public int ID { get; set; }
    public int BookID { get; set; }
    public int BuyerID { get; set; }
    public int SellerID { get; set; }
    public double Price { get; set; }
    public string Status { get; set; }
    public DateTime TimeStamp { get; set; }
}