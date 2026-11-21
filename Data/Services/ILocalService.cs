using SharedModelsLib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppData.Services
{
    public interface ILocalService
    {
        Task<List<LocalDto>> GetLocauxAsync();
        Task<LocalDto?> GetLocalByHoraireAsync(string jour, int heure);
    }
}
