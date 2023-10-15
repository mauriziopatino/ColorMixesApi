using System.ComponentModel.DataAnnotations;

namespace ColorMixes.Infrastructure.Models
{
    public class Combination
    {
        public int Id { get; set; }
        public int? FirstColorId { get; set; }
        public int? SecondColorId { get; set; }
        [MaxLength(50)]
        public string Result { get; set; } = string.Empty;
        public Color? FirstColor { get; set; }
        public Color? SecondColor { get; set; }
    }
}
