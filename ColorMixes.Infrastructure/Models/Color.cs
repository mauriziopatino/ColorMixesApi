using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorMixes.Infrastructure.Models
{
    public class Color
    {
        [Column(Order = 1)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
