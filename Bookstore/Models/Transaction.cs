using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models;

[Table("transactions")]
public class Transaction
{
    [Column("id")]
    public int ID { get; set; }
    [Column("book_id")]
    public int BookID { get; set; }
    [Column("buyer_id")]
    public int BuyerID { get; set; }
    [Column("winning_patron_id")]
    public int SellerID { get; set; }
    [Column("transaction_amount")]
    public double Price { get; set; }
    [Column("interested_patrons")]
    public string Interested { get; set; }
    [Column("transaction_date")]
    public DateTime TimeStamp { get; set; }
}