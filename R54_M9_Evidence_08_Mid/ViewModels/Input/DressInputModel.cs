using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using R54_M9_Evidence_08_Mid.Models;

namespace R54_M9_Evidence_08_Mid.ViewModels.Input
{
    public class DressInputModel
    {
        public int DressId { get; set; }
        [Required, StringLength(50)]
        public string DressName { get; set; } = default!;
        [Required, EnumDataType(typeof(Size))]
        public Size Size { get; set; } = default!;
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required]
        public IFormFile Picture { get; set; } = default!;

        public bool OnSale { get; set; }
    }
}
