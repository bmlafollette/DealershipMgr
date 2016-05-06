using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DealershipMgr.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        /*[Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }*/

        //[Key]
        //[ForeignKey("Salesperson")]
        //public int SalespersonID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Relationship Start Date")]
        public DateTime RelationshipDate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal PurchasesToDate { get; set; }

        public string City { get; set; }
        public decimal PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual Salesperson Salesperson { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}