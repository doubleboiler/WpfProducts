using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProdutcs.Models
{
    [Table("Product")]
    public class Product : ModelBase
    {
        [Required, StringLength(10)]
        [Index(IsUnique=true)]
        public string ProductCode { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
        [Required]
        public double Quantity { get; set; }

    }
}
