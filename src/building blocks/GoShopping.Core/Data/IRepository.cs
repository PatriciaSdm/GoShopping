using GoShopping.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoShopping.Core.Data
{
    public interface IRepository<T>: IDisposable where T : IAggregateRoot 
    {

    }
}
