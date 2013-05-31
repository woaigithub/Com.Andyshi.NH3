using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Andyshi.NH3.Domain
{
    public class Category
    {
        public virtual Guid Id { get; set; }


        public virtual string Name { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}
