using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Andyshi.NH3.Domain
{
    public class Product
    {

        public Product()
        {
            this.CreateTime = DateTime.Now;
            this.ModifyTime = DateTime.Now;
        }

        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual bool Discontinued { get; set; }

        public virtual DateTime CreateTime { get; set; }

        public virtual DateTime ModifyTime { get; set; }

        public virtual Category Category { get; set; }

        public virtual int Version { get; set; }
    }
}
