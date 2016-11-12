using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Field cant be longer then 150 or shorter then 1.")]
        public string Name { get; set; }

        public virtual Region Region { get; set; }
    }
}
