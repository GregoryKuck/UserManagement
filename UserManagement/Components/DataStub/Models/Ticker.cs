using System;
using UserManagement.Components.DataStub.Models.Interfaces;

namespace UserManagement.Components.DataStub.Models
{
    public class Ticker : IGuidIdentifiable
    {
        public Guid Id { get; set; }
        public string TickerCode { get; set; }
        public string Index { get; set; }
        public decimal Price { get; set; }
        
        public Ticker(string tickerCode, string index, decimal price)
        {
            Id = Guid.NewGuid();
            TickerCode = tickerCode;
            Index = index;
            Price = price;
        }
    }
}
