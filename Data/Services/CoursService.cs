using Microsoft.EntityFrameworkCore;
using MyAppData.Data;
using SharedModelsLib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppData.Services
{
    public class CoursService : ICoursService
    {
        private readonly SystemDbContext _db;
        public CoursService(SystemDbContext db) => _db = db;

        public async Task<ServiceResult> AddCoursAsync(CoursDto cours)
        {
            var newCours = new Cours
            {
                Code = cours.Code,
                Nom = cours.Nom
            };


            _db.Cours.Add(newCours);
            await _db.SaveChangesAsync();
            return ServiceResult.Ok();
        }

        public async Task<ServiceResult> DeleteCoursAsync(int id)
        {
            var coursToUpdate = await _db.Cours.FindAsync(id);

            if (coursToUpdate == null)
                return ServiceResult.Fail("Cours introuvable");

            _db.Cours.Remove(coursToUpdate);

            await _db.SaveChangesAsync();

            return ServiceResult.Ok();
        }

        public async Task<List<CoursDto>> GetCoursAsync()
        {
            List<CoursDto> coursList = await _db.Cours.AsNoTracking()
                .Select(e => new CoursDto
                {
                    Id = e.Id,
                    Code = e.Code,
                    Nom = e.Nom,
                }).ToListAsync();

            return coursList;
        }

        public async Task<CoursDto?> GetCoursByCodeAsync(string coursCode)
        {
            return await _db.Cours.AsNoTracking()
                .Where(e => e.Code == coursCode)
                .Select(e => new CoursDto
                {
                    Id = e.Id,
                    Code = e.Code,
                    Nom = e.Nom,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ServiceResult> UpdateCoursAsync(CoursDto cours)
        {
            var coursToUpdate = await _db.Cours.FindAsync(cours.Id);

            if (coursToUpdate == null)
                return ServiceResult.Fail("Cours introuvable");

            coursToUpdate.Code = cours.Code;
            coursToUpdate.Nom = cours.Nom;

            await _db.SaveChangesAsync();
            return ServiceResult.Ok();
        }
    }
}
