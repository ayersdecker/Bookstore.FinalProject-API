using System.Text.Json.Serialization;

namespace Bookstore.Models;

public class Item
{
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    
    
        [JsonIgnore]
        public double UnitPrice { get; set; }
        [JsonIgnore]
        public string CurrencyCode { get; set; }
    
}