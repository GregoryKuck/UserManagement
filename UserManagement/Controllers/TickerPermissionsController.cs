using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Components.DataStub.Models;
using UserManagement.Models;
using UserManagement.Services.Interfaces;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    public class TickerPermissionsController : Controller
    {
        private readonly IUserManagementService _ums;
        //HACK: Short cut:  This should never be allowed, but not implementing the Authentication or Authorization
        private const string _tmpRoleName = "Admin";
        
        public TickerPermissionsController(IUserManagementService userManagementService)
        {
            _ums = userManagementService;

        }
        
        //TODO: refactor out to the service class: GetVM
        [HttpGet("[action]")]
        public TickerPermissionsVM PermissionBasedTickers(string roleId = "")
        {
            Guid roleGuid;
            Guid.TryParse(roleId, out roleGuid);

            var roles = _ums.GetAllRoles();
            //HACK: You would typically never do this, but here for demonstration purposes
            var permissionRoleId = roleGuid != Guid.Empty ? roleGuid : roles.FirstOrDefault(r => r.Rolename.Equals(_tmpRoleName, StringComparison.InvariantCultureIgnoreCase)).Id;

            var tickers = _ums.GetPermissibleTickers(permissionRoleId);
            var vm = new TickerPermissionsVM(roles, tickers, permissionRoleId);
            return vm;
        }

        [HttpGet("[action]")]
        public UserTickerPermissionsVM UserPermissionBasedTickers(string userId = "")
        {
            //TODO: HACK: This would usually come through from your identity provider (many options of provider), not being implemented 
            Guid userGuid;
            Guid.TryParse(userId, out userGuid);

            var users = _ums.GetAllUsers();
            //HACK: Again, you would typically never do this, but here for demonstration purposes
            if (userGuid == Guid.Empty)
                userGuid = users.FirstOrDefault(u => u.Name.Equals(_tmpRoleName, StringComparison.InvariantCultureIgnoreCase)).Id;

            var roleId = users.FirstOrDefault(u => u.Id == userGuid).RoleId;
            var tickers = _ums.GetPermissibleTickers(roleId);
            var vm = new UserTickerPermissionsVM(users, tickers, userGuid);
            return vm;
        }
    }
}
