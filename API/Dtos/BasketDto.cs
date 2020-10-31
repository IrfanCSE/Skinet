using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class BasketDto
    {
        [Required]
        public string Id { get; set; }
        
        public List<BasketItemDto> items { get; set; }
    }
}