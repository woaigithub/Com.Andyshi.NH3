using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Andyshi.NH3.Domain
{
    public class OrderItem
    {
       
        public virtual int Amount { get; set; }

        public virtual Order Order { get; set; }

        //public virtual int Version { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual DateTime ModifyTime { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return this.Amount == item.Amount
                && this.CreateTime == item.CreateTime
                && this.ModifyTime == item.ModifyTime;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
