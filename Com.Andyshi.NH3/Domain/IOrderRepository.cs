using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Andyshi.NH3.Domain
{
    public interface IOrderRepository
    {
        void Add(Order order);

        Order Get(Guid id);
    }
}
