using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string ProductName { get; set; }
        
        [Required]
        [Range(1,double.MaxValue,ErrorMessage="Quantity at least one")]
        public int Quantity { get; set; }
        
        [Required]
        [Range(.1,double.MaxValue,ErrorMessage="Price should greater then .10 cent")]
        public decimal Price { get; set; }
        
        [Required]
        public string PictureUrl { get; set; }
        
        [Required]
        public string Type { get; set; }
        
        [Required]
        public string Brand { get; set; }
    }
}