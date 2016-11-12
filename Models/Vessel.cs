using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Vessel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Field cant be longer then 128 or shorter then 1.")]
        public string Type { get; set; }

        [Required]
        public decimal PalletSpace { get; set; }

        public virtual List<Article> Reports { get; set; }
    }
}
