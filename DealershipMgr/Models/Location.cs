using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DealershipMgr.Models
{
    public class Location
    {
        public int LocationID { get; set; }

        [Display(Name = "Location")]
        public string LocationName { get; set; }

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

        public int? SalespersonID { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Salesperson> Salespersons { get; set; }
    }
}