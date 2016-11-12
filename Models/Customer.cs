using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string CorporateIdentity { get; set; }
        public string Tel { get; set; }
        public string CustNumber { get; set; }
        public virtual List<Report> Reports { get; set; }
    }
}
