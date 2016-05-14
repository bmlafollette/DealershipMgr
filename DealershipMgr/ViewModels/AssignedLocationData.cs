using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealershipMgr.ViewModels
{
    public class AssignedLocationData
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public bool Assigned { get; set; }
    }
}
