using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Components.DataStub.Models;

namespace UserManagement.Models
{
    public class UsersRolesVM
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Role> Roles { get; set; }

        public UsersRolesVM(IEnumerable<User> users, IEnumerable<Role> roles)
        {
            Users = users;
            Roles = roles;
        }
    }
}
