using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DealershipMgr.Models
{
    public class Salesperson
    {
        public int ID { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Salesperson")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime HireDate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Sales YTD")]
        public decimal SalesYtd { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Sales Goal")]
        public decimal SalesGoal { get; set; }

        [Display(Name = "Met Sales Goal?")]
        public bool MetSalesGoal { get; set; }

        public int? LocationID { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}