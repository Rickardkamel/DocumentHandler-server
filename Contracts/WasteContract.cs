using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class WasteContract
    {

        public string Id { get; set; }

        public string Text { get; set; }

        public string EuropeanWasteCatalogueCode { get; set; }

        public string UnTextGroup { get; set; }
    }
}
