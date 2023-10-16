using ColorMixesApi.Core.Helpers;
using ColorMixesApi.Infrastructure.DTOs.Color;

namespace ColorMixesApi.Core.Services
{
    public interface IColorService
    {
        Task<ServiceResponse<GetColorDto>> CreateColor(CreateColorDto newColor);
        Task<ServiceResponse<GetColorDto>> GetColorByName(string name);
    }
}
