using SharedModelsLib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppData.Services
{
    public interface IDisponibiliteService
    {
        Task<List<DisponibiliteDto>> GetDisponibilitesAsync();
        Task<DisponibiliteDto?> GetDisponibiliteAsync(int id);
        Task<List<DisponibiliteDto>> GetDisponibilitesByCoursAsync(int coursId);
        Task<ServiceResult> AddDisponibiliteAsync(DisponibiliteDto disponibilite);
        Task<ServiceResult> UpdateDisponibiliteAsync(DisponibiliteDto disponibilite);
        Task<ServiceResult> DeleteDisponibiliteAsync(int id);
    }
}
