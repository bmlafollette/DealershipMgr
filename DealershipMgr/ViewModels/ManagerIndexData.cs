using DealershipMgr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealershipMgr.ViewModels
{
    public class ManagerIndexData
    {
        // Each holds the data for one of the tables on the Regions page.
        public IEnumerable<Manager> Managers { get; set; }
        public IEnumerable<Salesperson> Salespersons { get; set; }
    }
}
