using SharedModelsLib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppData.Services
{
    public interface IGroupeEtudeService
    {
        Task<List<GroupeEtudeDto>> GetGroupesEtudeAsync();
        Task<GroupeEtudeDto?> GetGroupeEtudeAsync(int id);
        Task<ServiceResult> AddGroupeEtudeAsync(GroupeEtudeDto groupe);
        Task<ServiceResult> UpdateGroupeEtudeAsync(GroupeEtudeDto groupe);
        Task<ServiceResult> DeleteGroupeEtudeAsync(int id);
    }
}
