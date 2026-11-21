using SharedModelsLib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppData.Services
{
    public interface IUtilisateurService
    {
        Task<UtilisateurDto?> GetUtilisateurAsync(string email);
        Task<ServiceResult> AddUtilisateurAsync(UtilisateurDto utilisateur);
    }
}
