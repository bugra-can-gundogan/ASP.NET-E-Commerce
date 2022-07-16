using bugraGundoganASP.entity;
using System.ComponentModel.DataAnnotations;

namespace bugraGundoganASP.webUI.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Kategori ad� zorunludur.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Kategori i�in 5-100 aras�nda de�er giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url zorunludur.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Url i�in 5-100 aras�nda de�er giriniz.")]

        public string Url { get; set; }

        public List<Product> Products { get; set; }
    }
}