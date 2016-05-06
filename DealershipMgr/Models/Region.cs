using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DealershipMgr.Models
{
    public class Region
    {
        public int RegionID { get; set; }
        public string RegionName { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal SalesYtd { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal SalesGoal { get; set; }

        public bool MetSalesGoal { get; set; }

        public virtual ICollection<Salesperson> Salespersons { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}