

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace broker.Models
{
    public class Deals
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DealsId { get; set; }
        public int Quantity { get; set; }
        
        public string ProductName { get; set; }
        public string  ProductModel { get; set; }
        public string Color { get; set; }
        public string PaymentOption { get; set; }
        public string DeliveryOption { get; set; }
        public string DealsStatus { get; set; }
        // navigational property
       public int BrokerId { get; set; } 
        [JsonIgnore]
        public Broker Broker { get; set; }
        public int CustomerId { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }





     
       






    }

}