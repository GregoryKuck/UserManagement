using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Components.DataStub.Models;

namespace UserManagement.Components.DataStub
{
    public class StaticDataSource: IDataSource
    {
        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }
        public List<Ticker> Tickers { get; set; }
        public List<RoleTickerPermission> RoleTickerPermissions { get; }

        public StaticDataSource()
        {
            //TODO: These rolenames are terrible
            Roles = new List<Role>()
            {
                new Role("Admin"),
                new Role("SpyOnly"),
                new Role("VtiExcluded")
            };

            Tickers = new List<Ticker>()
            {
                new Ticker("SPY", "SPDR S&P 500 ETF", 272.12M),
                new Ticker("DIA", "SPDR Dow Jones Industrial Average", 250.80M),
                new Ticker("SPYD", "S & P 500 High Dividend Index ", 36.58M),
                new Ticker("VTI", "Vanguard Total Stock Market ETF ", 139.34M),
            };

            RoleTickerPermissions = new List<RoleTickerPermission>()
            {
                new RoleTickerPermission(
                    Roles.FirstOrDefault(r => r.Rolename == "SpyOnly").Id,
                    Tickers.FirstOrDefault(t => t.TickerCode.Equals("SPY", StringComparison.InvariantCultureIgnoreCase)).Id),

                new RoleTickerPermission(
                    Roles.FirstOrDefault(r => r.Rolename == "VtiExcluded").Id,
                    Tickers.FirstOrDefault(t => t.TickerCode.Equals("SPY", StringComparison.InvariantCultureIgnoreCase)).Id),
                new RoleTickerPermission(
                    Roles.FirstOrDefault(r => r.Rolename == "VtiExcluded").Id,
                    Tickers.FirstOrDefault(t => t.TickerCode.Equals("DIA", StringComparison.InvariantCultureIgnoreCase)).Id),
                new RoleTickerPermission(
                    Roles.FirstOrDefault(r => r.Rolename == "VtiExcluded").Id,
                    Tickers.FirstOrDefault(t => t.TickerCode.Equals("SPYD", StringComparison.InvariantCultureIgnoreCase)).Id),
                
                //HACK: This should never be here, merely for display simplicity
                new RoleTickerPermission(
                    Roles.FirstOrDefault(r => r.Rolename == "Admin").Id,
                    Tickers.FirstOrDefault(t => t.TickerCode.Equals("SPY", StringComparison.InvariantCultureIgnoreCase)).Id),
                new RoleTickerPermission(
                    Roles.FirstOrDefault(r => r.Rolename == "Admin").Id,
                    Tickers.FirstOrDefault(t => t.TickerCode.Equals("DIA", StringComparison.InvariantCultureIgnoreCase)).Id),
                new RoleTickerPermission(
                    Roles.FirstOrDefault(r => r.Rolename == "Admin").Id,
                    Tickers.FirstOrDefault(t => t.TickerCode.Equals("SPYD", StringComparison.InvariantCultureIgnoreCase)).Id),
                new RoleTickerPermission(
                    Roles.FirstOrDefault(r => r.Rolename == "Admin").Id,
                    Tickers.FirstOrDefault(t => t.TickerCode.Equals("VTI", StringComparison.InvariantCultureIgnoreCase)).Id)
            };

            Users = new List<User>()
            {
                new User(
                    "Admin",
                    Roles.FirstOrDefault(p => p.Rolename.Equals("Admin", StringComparison.InvariantCultureIgnoreCase)).Id),
                new User(
                    "Client A", 
                    Roles.FirstOrDefault(p => p.Rolename.Equals("SpyOnly", StringComparison.InvariantCultureIgnoreCase)).Id),
                new User(
                    "Client B",
                    Roles.FirstOrDefault(p => p.Rolename.Equals("VtiExcluded", StringComparison.InvariantCultureIgnoreCase)).Id)
            };
        }
    }
}
