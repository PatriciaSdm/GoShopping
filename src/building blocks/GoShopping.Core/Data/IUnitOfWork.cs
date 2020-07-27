using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoShopping.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
