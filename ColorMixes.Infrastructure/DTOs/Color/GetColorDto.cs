using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorMixesApi.Infrastructure.DTOs.Color
{
    public class GetColorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
