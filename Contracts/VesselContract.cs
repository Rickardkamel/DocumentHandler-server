using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class VesselContract
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal PalletSpace { get; set; }
    }
}
