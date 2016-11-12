using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string WasteId { get; set; }

        public int VesselId { get; set; }

        public int ReportId { get; set; }

        public int Quantity { get; set; }

        public int Exchange { get; set; }

        public string Info { get; set; }

        public virtual Vessel Vessel { get; set; }

        public virtual Report Report { get; set; }
    }
}
