using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class ReportContract
    {
        public int Id { get; set; }

        public string CreatedByUserName { get; set; }

        public string LastEditBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EditedDate { get; set; }

        public DateTime? RemovedDate { get; set; }

        public string Info { get; set; }

        public DateTime OrderedDate { get; set; }

        public List<ArticleContract> Articles { get; set; }

        public bool Approved { get; set; }

        public RegionContract Region { get; set; }

        public RecieverContract Reciever { get; set; }

        public TransporterContract Transporter { get; set; }
        public CustomerContract Customer { get; set; }
    }
}
