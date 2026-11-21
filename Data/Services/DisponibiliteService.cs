using Microsoft.EntityFrameworkCore;
using MyAppData.Data;
using SharedModelsLib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppData.Services
{
    public class DisponibiliteService : IDisponibiliteService
    {
        private readonly SystemDbContext _db;
        public DisponibiliteService(SystemDbContext db) => _db = db;

        public async Task<ServiceResult> AddDisponibiliteAsync(DisponibiliteDto disponibilite)
        {
            var newDisponibilite = new Disponibilite
            {
                Jour = disponibilite.Jour,
                CoursId = disponibilite.CoursId,
                Heures = disponibilite.Heures,
                EtudiantId = disponibilite.EtudiantId
            };

            _db.Disponibilites.Add(newDisponibilite);
            await _db.SaveChangesAsync();

            return ServiceResult.Ok();
        }

        public async Task<ServiceResult> DeleteDisponibiliteAsync(int id)
        {
            var disponibiliteToDelete = await _db.Disponibilites.FindAsync(id);

            if (disponibiliteToDelete == null)
                return ServiceResult.Fail("Disponibilité introuvable");

            _db.Disponibilites.Remove(disponibiliteToDelete);

            await _db.SaveChangesAsync();

            return ServiceResult.Ok();
        }

        public async Task<List<DisponibiliteDto>> GetDisponibilitesAsync()
        {
            return await _db.Disponibilites.AsNoTracking()
                .Select(e => new DisponibiliteDto
                {
                    Id = e.Id,
                    Jour = e.Jour,
                    CoursId = e.CoursId,
                    Heures = e.Heures,
                    EtudiantId = e.EtudiantId
                })
                .ToListAsync();
        }

        public async Task<DisponibiliteDto?> GetDisponibiliteAsync(int id)
        {
            return await _db.Disponibilites.AsNoTracking()
                .Where(e => e.Id == id)
                .Select(e => new DisponibiliteDto
                {
                    Id = e.Id,
                    Jour = e.Jour,
                    CoursId = e.CoursId,
                    Heures = e.Heures,
                    EtudiantId = e.EtudiantId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<DisponibiliteDto>> GetDisponibilitesByCoursAsync(int coursId)
        {
            return await _db.Disponibilites.AsNoTracking()
                .Where(e => e.CoursId == coursId)
                .Select(e => new DisponibiliteDto
                {
                    Id = e.Id,
                    Jour = e.Jour,
                    CoursId = e.CoursId,
                    Heures = e.Heures,
                    EtudiantId = e.EtudiantId
                })
                .ToListAsync();
        }

        public async Task<ServiceResult> UpdateDisponibiliteAsync(DisponibiliteDto disponibilite)
        {
            var disponibiliteToUpdate = await _db.Disponibilites.FindAsync(disponibilite.Id);

            if (disponibiliteToUpdate == null)
                return ServiceResult.Fail("Disponibilité introuvable");

            disponibiliteToUpdate.Jour = disponibilite.Jour;
            disponibiliteToUpdate.CoursId = disponibilite.CoursId;
            disponibiliteToUpdate.Heures = disponibilite.Heures;
            disponibiliteToUpdate.EtudiantId = disponibilite.EtudiantId;

            await _db.SaveChangesAsync();

            return ServiceResult.Ok();
        }
    }
}
