using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Report
    {

        [Key]
        public int Id { get; set; }

        public string CreatedByUserName { get; set; }

        public int CustomerId { get; set; }

        public int RegionId { get; set; }

        public int TransporterId { get; set; }

        public int RecieverId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        
        public DateTime? RemovedDate { get; set; }

        [Required]
        //Default value is set to the day it will be created.
        public DateTime EditedDate { get; set; }

        [Required]
        public bool Approved { get; set; }

        public string LastEditBy { get; set; }

        public string Info { get; set; }

        public DateTime OrderedDate { get; set; }

        public virtual Region Region { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Transporter Transporter { get; set; }

        public virtual Reciever Reciever { get; set; }

        public virtual User CreatedBy { get; set; }
        //Default value is set to the user who created the report
        public virtual List<Article> Articles { get; set; }
    }
}
