using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Field cant be longer then 50 or shorter then 1.")]
        public string Username { get; set; }

        [Required]
        public string Salt { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public PermissionType Permission { get; set; }

        public virtual List<Report> Reports { get; set; }
    }
}
