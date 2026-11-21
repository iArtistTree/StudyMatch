using SharedModelsLib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppData.Services
{
    public interface IEtudiantService
    {
        Task<EtudiantDto?> GetEtudiantAsync(int etudiantId);
        Task<ServiceResult> AddEtudiantAsync(EtudiantDto etudiant);

    }
}
