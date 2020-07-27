using GoShopping.Core;
using GoShopping.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoShopping.Catalog.API.Model
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public decimal Value { get; set; }
        public DateTime CreateData { get; set; }
        public string Image { get; set; }
        public int StockAmount { get; set; }
    }
}
