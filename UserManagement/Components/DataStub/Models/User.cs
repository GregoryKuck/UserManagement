using System;
using UserManagement.Components.DataStub.Models.Interfaces;

namespace UserManagement.Components.DataStub.Models
{
    public class User : IGuidIdentifiable
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public DateTime LastLoginDate { get; set; }

        public User(string name, Guid roleId)
        {
            Id = Guid.NewGuid();
            RoleId = roleId;
            Name = name;
            LastLoginDate = DateTime.Now;
        }
    }
}
