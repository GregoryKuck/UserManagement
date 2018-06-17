using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Components.DataStub;
using UserManagement.Components.DataStub.Models;

namespace UserManagement.Services.Interfaces
{
    public interface IUserManagementService
    {
        List<RoleTickerPermission> GetAllPermissions();
        List<Role> GetAllRoles();
        List<Ticker> GetAllTickers();
        List<User> GetAllUsers();
        User FindUser(Guid userId);
        void AssignUsersRole(Guid roleId, Guid userId);
        List<string> GetPermissibleTickerCodes(Guid roleId);
        List<Ticker> GetPermissibleTickers(Guid roleId);
    }
}
