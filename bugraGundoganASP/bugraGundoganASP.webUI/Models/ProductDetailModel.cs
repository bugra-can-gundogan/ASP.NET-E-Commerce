using System.Collections.Generic;
using bugraGundoganASP.entity;

namespace bugraGundoganASP.webUI.Models
{
    public class ProductDetailModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}