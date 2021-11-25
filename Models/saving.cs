

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace broker.Models
{
    public class Saving
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SavingId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }
        public string IdentificationCard { get; set; }

      
    }

}