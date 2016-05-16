using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DealershipMgr.Models
{
    public class Manager
    {
        public int ID { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Manager")]
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

        public int? SalespersonID { get; set; }

        public virtual ICollection<Salesperson> Salespersons { get; set; }
        public virtual Location Location { get; set; }
    }
}