using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace Contracts
{
    public class UserContract
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public PermissionType Permission { get; set; }

    }
}
