﻿using ColorMixes.Infrastructure.Data;
using ColorMixes.Infrastructure.Models;
using ColorMixesApi.Core.Helpers;
using ColorMixesApi.Infrastructure.DTOs.Color;
using Microsoft.EntityFrameworkCore;

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

            if (await ColorExistsByName(newColor.Name))
            {
                response.Message = "El color ya existe.";
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

        public async Task<ServiceResponse<GetColorDto>> GetColorByName(string name)
        {
            var response = new ServiceResponse<GetColorDto>();

            if (string.IsNullOrEmpty(name))
            {
                response.Message = "El nombre es incorrecto.";
                response.Success = false;
                return response;
            }

            if (!await ColorExistsByName(name))
            {
                response.Message = "El color no existe.";
                response.Success = false;
                return response;
            }

            var color = await _context.Colors.FirstOrDefaultAsync(x => x.Name == name);
            response.Data = new GetColorDto { Id = color!.Id, Name = color.Name };

            return response;
        }

        public async Task<bool> ColorExistsByName(string name)
        {
            var colors = await _context.Colors.ToListAsync();
            var result = colors.Any(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));

            return result;

        }
    }
}
