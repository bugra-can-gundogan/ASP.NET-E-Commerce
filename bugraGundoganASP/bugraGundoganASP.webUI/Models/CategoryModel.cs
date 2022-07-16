using bugraGundoganASP.entity;
using System.ComponentModel.DataAnnotations;

namespace bugraGundoganASP.webUI.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Kategori adý zorunludur.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Kategori için 5-100 arasýnda deðer giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url zorunludur.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Url için 5-100 arasýnda deðer giriniz.")]

        public string Url { get; set; }

        public List<Product> Products { get; set; }
    }
}