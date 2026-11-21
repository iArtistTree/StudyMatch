using Microsoft.EntityFrameworkCore;
using MyAppData.Data;
using SharedModelsLib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppData.Services
{
    public class LocalService : ILocalService
    {
        private readonly SystemDbContext _db;
        public LocalService(SystemDbContext db) => _db = db;

        public async Task<List<LocalDto>> GetLocauxAsync()
        {
            List<LocalDto> locaux = await _db.Locaux.AsNoTracking()
                .Select(e => new LocalDto
                {
                    Id = e.Id,
                    Nom = e.Nom,
                    Capacite = e.Capacite
                }).ToListAsync();

            return locaux;
        }

        public Task<LocalDto?> GetLocalByHoraireAsync(string jour, int heure)
        {
            return _db.Locaux.AsNoTracking()
                .Where(e => e.Horaires.Any(h =>
                    h.Jour == jour && h.Heure == heure))
                .Select(e => new LocalDto
                {
                    Id = e.Id,
                    Nom = e.Nom,
                    Capacite = e.Capacite
                })
                .FirstOrDefaultAsync();
        }
    }
}
