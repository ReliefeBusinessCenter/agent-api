using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;
using broker.Models;

namespace broker.Dto
{
    public class BrokerDto
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrokerId { get; set; }
        public ICollection<Portfolio> Portfolio { get; set; }
        public ICollection<Delivery> Delivery { get; set; }
        public ICollection<Deals> Deals { get; set; }
        public ICollection<Review> Review { get; set; }
        public ICollection<Sales> Sales { get; set; }

        public Skills Skills { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
         public bool Approved { get; set; }
        
        public string About { get; set; }

        // navigational properties

        public User User { get; set; }















    }
}