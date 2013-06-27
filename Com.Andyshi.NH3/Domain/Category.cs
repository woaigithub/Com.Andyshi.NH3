using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Andyshi.NH3.Domain
{
    public class Category
    {
        public Category()
        {
            this.CreateTime = DateTime.Now;
            this.ModifyTime = DateTime.Now;
        }
        public virtual Guid ID { get; set; }


        public virtual string Name { get; set; }

        public virtual DateTime CreateTime { get; set; }

        public virtual DateTime ModifyTime { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
