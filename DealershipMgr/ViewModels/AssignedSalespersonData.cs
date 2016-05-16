using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealershipMgr.ViewModels
{
    public class AssignedSalespersonData
    {
        public int SalespersonID { get; set; }
        public string FullName { get; set; }
        public bool Assigned { get; set; }
    }
}
