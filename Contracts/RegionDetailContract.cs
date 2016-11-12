using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class RegionDetailContract : RegionContract
    {
        public int TotalReports { get; set; }

        public int TotalOldReports { get; set; }

        public decimal TotalPalletSpace { get; set; }
    }
}
