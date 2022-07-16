using bugraGundoganASP.entity;
using System.ComponentModel.DataAnnotations;

namespace bugraGundoganASP.webUI.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Display(Name="Name",Prompt="Enter product name")]
        [Required(ErrorMessage="Name zorunlu bir alan.")]
        [StringLength(60,MinimumLength=5,ErrorMessage="Ürün ismi 5-60 karakter aralýðýnda olmalýdýr.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url zorunlu bir alan.")]
        public string Url { get; set; }

        [Required(ErrorMessage="Price zorunlu bir alan.")]  
        [Range(1,10000,ErrorMessage="Price için 1-10000 arasýnda deðer girmelisiniz.")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Description zorunlu bir alan.")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Description 5-1000 karakter aralýðýnda olmalýdýr.")]

        public string Description { get; set; }

        [Required(ErrorMessage = "ImageUrl zorunlu bir alan.")]
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public List<Category>? SelectedCategories { get; set; }
    }
}