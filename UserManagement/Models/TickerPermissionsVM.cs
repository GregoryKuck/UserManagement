using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Components.DataStub.Models;

namespace UserManagement.Models
{
    public class TickerPermissionsVM
    {
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Ticker> Tickers { get; set; }
        public Guid SelectedRoleId { get; set; }

        public TickerPermissionsVM(IEnumerable<Role> roles, IEnumerable<Ticker> tickers, Guid roleId)
        {
            Roles = roles;
            Tickers = tickers;
            SelectedRoleId = roleId;
        }
    }
}
