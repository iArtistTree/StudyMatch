using SharedModelsLib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppData.Services
{
    public interface ICoursService
    {
        Task<List<CoursDto>> GetCoursAsync();
        Task<CoursDto?> GetCoursByCodeAsync(string coursCode);
        Task<ServiceResult> AddCoursAsync(CoursDto cours);
        Task<ServiceResult> UpdateCoursAsync(CoursDto cours);
        Task<ServiceResult> DeleteCoursAsync(int id);
    }
}
