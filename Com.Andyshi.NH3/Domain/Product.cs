using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.Type;
using NHibernate.UserTypes;

namespace Com.Andyshi.NH3.Domain
{
    public class Product
    {

        public Product()
        {
            this.CreateTime = DateTime.Now;
            this.ModifyTime = DateTime.Now;
        }

        public virtual Guid ID { get; set; }

        public virtual string Name { get; set; }

        public virtual bool Discontinued { get; set; }

        public virtual DateTime CreateTime { get; set; }

        public virtual DateTime ModifyTime { get; set; }

        public virtual Category Category { get; set; }

        public virtual int Version { get; set; }

        public virtual bool IsDelete { get; set; }

        public virtual Status Status { get; set; }
    }

    public enum Status
    {
        Yes = 1,
        No = 2
    }

    public class YesNo10 : IUserType
    {

        public bool IsMutable
        {
            get { return false; }
        }

        public Type ReturnedType
        {
            get { return typeof(YesNoType); }
        }

        public SqlType[] SqlTypes
        {
            get { return new[] { NHibernateUtil.String.SqlType }; }
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var obj = NHibernateUtil.String.NullSafeGet(rs, names[0]);

            if (obj == null) return null;

            var yesNo = (string)obj;

            if (yesNo != "1" && yesNo != "0")
                throw new Exception(string.Format ("Expected data to be '1' or '0' but was '{0}'.", yesNo));

            return yesNo == "1";
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null)
            {
                ((IDataParameter)cmd.Parameters[index]).Value = DBNull.Value;
            }
            else
            {
                var yes = (bool)value;
                ((IDataParameter)cmd.Parameters[index]).Value = yes ? "1" : "0";
            }
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        public object Disassemble(object value)
        {
            return value;
        }

        public new bool Equals(object x, object y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (x == null || y == null) return false;

            return x.Equals(y);
        }

        public int GetHashCode(object x)
        {
            return x == null ? typeof(bool).GetHashCode() + 473 : x.GetHashCode();
        }
    }

   
}
