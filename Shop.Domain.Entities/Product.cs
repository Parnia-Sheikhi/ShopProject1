using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Entities
{
    public class Product
    {
        [Required]
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "نام محصول حتما ذکر شود")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "توضیحات مربوط به محصول را کامل کنید")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "قیمت محصول را مشخص کنید")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "نوع محصول را مشخص کنید")]
        [StringLength(100)]
        public string Category { get; set; }

        [Required(ErrorMessage = "")]
        [StringLength(100)]
        public string ImageUrl { get; set; }
    }
}
