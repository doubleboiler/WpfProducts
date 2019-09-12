using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProdutcs.Models;

namespace WpfProductsData
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("Default")
        {

        }
        public DbSet<Product> Products { get; set; }


    }
}
