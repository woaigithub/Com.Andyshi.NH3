using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Andyshi.NH3.Domain
{
    public class Customer
    {
        public virtual Guid ID { get; set; }

        public virtual string Username { get; set; }

        public virtual string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


    }
}
