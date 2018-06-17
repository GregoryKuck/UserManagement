using System.Collections.Generic;
using UserManagement.Components.DataStub.Models;

namespace UserManagement.Components.DataStub
{
    public interface IDataSource
    {
        List<User> Users { get; }
        List<Role> Roles { get; }
        List<Ticker> Tickers { get; }
        List<RoleTickerPermission> RoleTickerPermissions { get; }
    }
}
