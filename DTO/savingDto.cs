using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;
using broker.Models;

namespace broker.Dto
{
    public class SavingDto
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

