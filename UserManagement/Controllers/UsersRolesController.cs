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
    public class UsersRolesController : Controller
    {
        private readonly IUserManagementService _ums;
        
        public UsersRolesController(IUserManagementService userManagementService)
        {
            _ums = userManagementService;

        }
        
        //TODO: This is a very rudimentary way to assign roles, but will do for assesessment purposes
        [HttpGet("[action]")]
        public UsersRolesVM GetUsersAndRoles()
        {
            var roles = _ums.GetAllRoles();
            var users = _ums.GetAllUsers();

            var vm = new UsersRolesVM(users, roles);
            return vm;
        }

        //TODO: This should be a PUT and is dumbed down, limited by getting angular to hook up properly to URL roles/{roleId}/users/{userId}/ and time
        [HttpGet("[action]")]
        public void SetUserRole(string roleId = "", string userId = "")
        {
            Guid roleGuid;
            Guid userGuid;

            Guid.TryParse(userId, out userGuid);
            Guid.TryParse(roleId, out roleGuid);

            _ums.AssignUsersRole(roleGuid, userGuid);
        }
    }
}
