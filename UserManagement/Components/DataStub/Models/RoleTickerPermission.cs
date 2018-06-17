using System;
using UserManagement.Components.DataStub.Models.Interfaces;

namespace UserManagement.Components.DataStub.Models
{
    public class RoleTickerPermission : IGuidIdentifiable
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid TickerId { get; set; }

        public RoleTickerPermission(Guid roleId, Guid tickerId)
        {
            Id = Guid.NewGuid();
            RoleId = roleId;
            TickerId = tickerId;
        }
    }
}
