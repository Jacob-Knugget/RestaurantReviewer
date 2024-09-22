using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReviewer.Models
{
    public class Restaurants
    {
        public int ID { get; set; }
        public byte[]? RestaurantPicture { get; set; }
        public string? Name { get; set; }
        public double? Rating { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Cost { get; set; }
        [NotMapped]
        public List<string>? Reviews { get; set; } = new List<string>();
    }
}
