using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class ArticleContract
    {
        public int Id { get; set; }

        public string WasteId { get; set; }

        public int ReportId { get; set; }

        public int Quantity { get; set; }

        public int Exchange { get; set; }

        public string Info { get; set; }

        public VesselContract Vessel { get; set; }

        public WasteContract Waste { get; set; }
    }
}
