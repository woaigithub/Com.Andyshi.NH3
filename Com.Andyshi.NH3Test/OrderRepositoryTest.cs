using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Andyshi.NH3.Domain;
using Com.Andyshi.NH3.Repositories;
using NUnit.Framework;

namespace Com.Andyshi.NH3Test
{
    [TestFixture]
    public class OrderRepositoryTest
    {
        [Test]
        public void test_add()
        {
            var now = DateTime.Now;
            var order = new Order()
            {
                CreateTime = now,
                ModifyTime = now
            };

            order.AddItem(100);
            order.AddItem(200);


            var repository = new OrderRepository();
            repository.Add(order);

            var orderindb = repository.Get(order.ID);

            Assert.IsNotNull(orderindb);
            
        }

    }
}
