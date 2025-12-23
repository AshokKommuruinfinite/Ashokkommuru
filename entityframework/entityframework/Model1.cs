using entityframework;
using System;

using System.Data.Entity;

using System.Linq;

namespace entityframework

{

    public class Model1 : DbContext

    {

        public Model1()

            : base("name=Model1")

        {

        }

        public virtual DbSet<Ipl> IPLs { get; set; }

    }

    //public class MyEntity

    //{

    //    public int Id { get; set; }

    //    public string Name { get; set; }

    //}

}
