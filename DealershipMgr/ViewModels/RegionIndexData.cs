using DealershipMgr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealershipMgr.ViewModels
{
    public class RegionIndexData
    {
        // Each holds the data for one of the tables on the Regions page.
        public IEnumerable<Region> Regions { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Salesperson> Salespersons { get; set; }
    }
}
