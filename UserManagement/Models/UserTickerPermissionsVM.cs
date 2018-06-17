using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Components.DataStub.Models;

namespace UserManagement.Models
{
    public class UserTickerPermissionsVM
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Ticker> Tickers { get; set; }
        public Guid SelectedUserId { get; set; }

        public UserTickerPermissionsVM(IEnumerable<User> users, IEnumerable<Ticker> tickers, Guid userId) 
        {
            Users = users;
            Tickers = tickers;
            SelectedUserId = userId;
        }
    }
}
