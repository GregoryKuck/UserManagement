using System;
using UserManagement.Components.DataStub.Models.Interfaces;

namespace UserManagement.Components.DataStub.Models
{
    public class Role : IGuidIdentifiable
    {
        public Guid Id { get; set; }
        public string Rolename { get; set; }

        public Role (string rolename)
        {
            Id = Guid.NewGuid();
            Rolename = rolename;
        }

        public Role(Guid id, string rolename)
        {
            Id = id;
            Rolename = rolename;
        }
    }
}
