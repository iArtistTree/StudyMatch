using Microsoft.EntityFrameworkCore;
using MyAppData.Data;
using SharedModelsLib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MyAppData.Services
{
    public class EtudiantService : IEtudiantService
    {
        private readonly SystemDbContext _db;
        public EtudiantService(SystemDbContext db) => _db = db;

        public async Task<EtudiantDto?> GetEtudiantAsync(int etudiantId)
        {
            return await _db.Etudiants.AsNoTracking()
                .Where(e => e.Id == etudiantId)
                .Select(e => new EtudiantDto
                {
                    Id = e.Id,
                    Nom = e.Nom
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ServiceResult> AddEtudiantAsync(EtudiantDto etudiant)
        {
            var newEtudiant = new Etudiant
            {
                Nom = etudiant.Nom,

            };

            _db.Etudiants.Add(newEtudiant);

            await _db.SaveChangesAsync();

            etudiant.Id = newEtudiant.Id;

            return ServiceResult.Ok();
        }
    }
}
