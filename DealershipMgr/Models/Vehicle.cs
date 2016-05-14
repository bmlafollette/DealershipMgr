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

        [Display(Name = "Year")]
        public int VehicleYear { get; set; }

        [Display(Name = "Make")]
        public string VehicleMake { get; set; }

        [Display(Name = "Model")]
        public string VehicleModel { get; set; }

        [Display(Name = "Vehicle")]
        public string FullName
        {
            get
            {
                return VehicleYear + " " + VehicleMake + " " + VehicleModel;
            }
        }

        [Display(Name = "VIN")]
        public string VehicleVIN { get; set; }

        //[Key]
        //[ForeignKey("Client")]
        //public int ClientID { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        public virtual Client Client { get; set; }
        public virtual Salesperson Salesperson { get; set; }
    }
}