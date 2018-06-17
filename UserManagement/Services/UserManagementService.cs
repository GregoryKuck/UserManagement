using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Components.DataStub;
using UserManagement.Components.DataStub.Models;
using UserManagement.Services.Interfaces;

namespace UserManagement.Services
{
    //HACK: NOT SOLID: In keeping with the monolith style API, for abstraction simplicity I am using a  single service to work on user, ticker, role, etc. 
    public class UserManagementService : IUserManagementService
    {
        private readonly IDataSource _dataSource;

        public UserManagementService(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        #region Users
        public List<User> GetAllUsers()
        {
            return _dataSource.Users.ToList();
        }

        public User FindUser(Guid userId)
        {
            return _dataSource.Users.FirstOrDefault(u => u.Id == userId);
        }

        #endregion

        #region Tickers
        public List<Ticker> GetAllTickers()
        {
            return _dataSource.Tickers.ToList();
        }
        #endregion

        #region Roles
        public List<Role> GetAllRoles()
        {
            return _dataSource.Roles.ToList();
        }
        #endregion

        #region UsersRoles
        public void AssignUsersRole(Guid roleId, Guid userId)
        {
            _dataSource.Users.FirstOrDefault(u => u.Id == userId).RoleId = roleId;
        }
        #endregion

        #region Permissions
        public List<RoleTickerPermission> GetAllPermissions()
        {
            return _dataSource.RoleTickerPermissions.ToList();
        }

        public List<string> GetPermissibleTickerCodes(Guid roleId)
        {
            return _dataSource.RoleTickerPermissions.Where(p => p.RoleId == roleId)
                    .Join(_dataSource.Tickers,
                        p => p.TickerId, t => t.Id,
                        (p, t) => t.TickerCode ).ToList();
        }

        public List<Ticker> GetPermissibleTickers(Guid roleId)
        {
            return _dataSource.RoleTickerPermissions.Where(p => p.RoleId == roleId)
                    .Join(_dataSource.Tickers,
                        p => p.TickerId, t => t.Id,
                        (p, t) => t).ToList();
        }
        #endregion
    }
}
