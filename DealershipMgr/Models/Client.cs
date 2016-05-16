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

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Client")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public int? SalespersonID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Relationship Start Date")]
        public DateTime RelationshipDate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Purchases To Date")]
        public decimal PurchasesToDate { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public virtual Salesperson Salesperson { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}