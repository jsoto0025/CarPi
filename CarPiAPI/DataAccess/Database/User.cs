using System;
using System.Collections.Generic;

namespace DataAccess.Database
{
    public partial class User
    {
        public User()
        {
            RoleByUser = new HashSet<RoleByUser>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public ICollection<RoleByUser> RoleByUser { get; set; }
    }
}
