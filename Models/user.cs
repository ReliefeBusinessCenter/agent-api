

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace broker.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

       

        public string City { get; set; }
        public string Subcity { get; set; }
        public string Kebele { get; set; }
        public string Picture { get; set; }
        public string IdentificationCard { get; set; }
        public string Sex { get; set; }


        public string Role { get; set; }

        public ICollection<Buy> Buys { get; set; }
        public double  Latitude { get; set; }
        public double  Longtiude { get; set; }





    }

}