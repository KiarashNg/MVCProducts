using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Runtime.Remoting.Contexts;
using Product.Models;

namespace Product.DAL
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext()
            :base("name=ProductDBContext")
        {

        }

        public DbSet<product> Products { get; set; }
    }
}