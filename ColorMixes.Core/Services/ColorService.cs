using ColorMixes.Infrastructure.Data;
using ColorMixes.Infrastructure.Models;
using ColorMixesApi.Core.Helpers;
using ColorMixesApi.Infrastructure.DTOs.Color;

namespace ColorMixesApi.Core.Services
{
    public class ColorService : IColorService
    {
        private readonly ColorMixesApiDbContext _context;

        public ColorService(ColorMixesApiDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<GetColorDto>> CreateColor(CreateColorDto newColor)
        {
            var response = new ServiceResponse<GetColorDto>();

            if(string.IsNullOrEmpty(newColor.Name))
            {
                response.Message = "El nombre es incorrecto.";
                response.Success = false;
                return response;
            }

            try
            {
                var color = new Color()
                {
                    Name = newColor.Name,
                };

                _context.Colors.Add(color);
                await _context.SaveChangesAsync();

                response.Data = new GetColorDto()
                {
                    Id = color.Id,
                    Name = color.Name,
                };

                response.Message = "Color creado correctamente.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;

                return response;
            }
        }
    }
}
