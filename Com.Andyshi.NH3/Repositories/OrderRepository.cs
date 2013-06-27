using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Andyshi.NH3.Domain;

namespace Com.Andyshi.NH3.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public void Add(Order order)
        {
            using (var session = SessionManager.Instance.CreateSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    session.Save(order);

                    tran.Commit();
                }
            }
        }


        public Order Get(Guid id)
        {
            using (var session = SessionManager.Instance.CreateSession())
            {
                return session.Get<Order>(id);
            }
        }
    }
}
