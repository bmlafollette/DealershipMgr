using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DealershipMgr.Models
{
    public class Location
    {
        public int LocationID { get; set; }

        [Display(Name = "City")]
        public string LocationName { get; set; }

        public int? RegionID { get; set; }

        public virtual ICollection<Salesperson> Salespersons { get; set; }
        public virtual Region Region { get; set; }
    }
}