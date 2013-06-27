using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Andyshi.NH3.Domain
{
    public class Order
    {

        public Order()
        {
            this.Items = new Iesi.Collections.Generic.HashedSet<OrderItem>();
            
            //it is ok too
            //this.Items = new List<OrderItem>();
        }

        public virtual Guid ID { get; set; }

        public virtual Iesi.Collections.Generic.ISet<OrderItem> Items { get; set; }
        
        //it is ok too
        //public virtual ICollection<OrderItem> Items { get; set; }

        //public virtual Customer Customer { get; set; }

        public virtual DateTime CreateTime { get; set; }
        public virtual DateTime ModifyTime { get; set; }

        public virtual int Version { get; set; }

        public virtual void AddItem(int amount)
        {
            var now = DateTime.Now;
            var item = new OrderItem() { CreateTime = now, ModifyTime = now, Amount = amount, Order = this };
            this.Items.Add(item);
        }
    }
}
