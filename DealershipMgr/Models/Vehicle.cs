using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DealershipMgr.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public int VehicleYear { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleVIN { get; set; }

        //[Key]
        //[ForeignKey("Client")]
        //public int ClientID { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual Client Client { get; set; }
        public virtual Salesperson Salesperson { get; set; }
    }
}