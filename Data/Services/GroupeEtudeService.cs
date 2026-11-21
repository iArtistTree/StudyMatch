using MyAppData.Data;
using SharedModelsLib;
using SharedModelsLib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MyAppData.Services
{
    public class GroupeEtudeService : IGroupeEtudeService
    {
        private readonly SystemDbContext _db;

        public GroupeEtudeService(SystemDbContext db) => _db = db;

        public async Task<ServiceResult> AddGroupeEtudeAsync(GroupeEtudeDto groupe)
        {
            var newGroupe = new GroupeEtude
            {
                CoursId = groupe.CoursId,
                JourRetenu = groupe.JourRetenu,
                HeureRetenu = groupe.HeureRetenu,
                LocalId = groupe.LocalId,
                Status = groupe.Status,
                Membres = await _db.Etudiants
                    .Where(e => groupe.MembresIds.Contains(e.Id))
                    .ToListAsync()
            };

            _db.Groupes.Add(newGroupe);

            await _db.SaveChangesAsync();

            return ServiceResult.Ok();
        }

        public async Task<ServiceResult> DeleteGroupeEtudeAsync(int id)
        {
            var groupeToDelete = await _db.Groupes.FindAsync(id);

            if (groupeToDelete == null)
                return ServiceResult.Fail("Groupe d'étude introuvable");

            _db.Groupes.Remove(groupeToDelete);

            await _db.SaveChangesAsync();

            return ServiceResult.Ok();
        }

        public async Task<List<GroupeEtudeDto>> GetGroupesEtudeAsync()
        {
            return await _db.Groupes.AsNoTracking()
                .Select(e => new GroupeEtudeDto
                {
                    Id = e.Id,
                    CoursId = e.CoursId,
                    JourRetenu = e.JourRetenu,
                    HeureRetenu = e.HeureRetenu,
                    LocalId = e.LocalId,
                    Status = e.Status,
                    MembresIds = e.Membres.Select(m => m.Id).ToList(),
                    MembresNoms = e.Membres.Select(m => m.Nom).ToList(),
                    LocalNom = e.Local.Nom,
                    CoursCode = e.Cours.Code
                })
                .ToListAsync();
        }

        public Task<GroupeEtudeDto?> GetGroupeEtudeAsync(int id)
        {
            return _db.Groupes.AsNoTracking()
                .Where(e => e.Id == id)
                .Select(e => new GroupeEtudeDto
                {
                    Id = e.Id,
                    CoursId = e.CoursId,
                    JourRetenu = e.JourRetenu,
                    HeureRetenu = e.HeureRetenu,
                    LocalId = e.LocalId,
                    Status = e.Status,
                    MembresIds = e.Membres.Select(m => m.Id).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ServiceResult> UpdateGroupeEtudeAsync(GroupeEtudeDto groupe)
        {
            var groupeToUpdate = await _db.Groupes
                .Include(e => e.Membres)
                .FirstOrDefaultAsync(e => e.Id == groupe.Id);

            if (groupeToUpdate == null)
                return ServiceResult.Fail("Groupe d'étude introuvable");

            groupeToUpdate.CoursId = groupe.CoursId;
            groupeToUpdate.JourRetenu = groupe.JourRetenu;
            groupeToUpdate.HeureRetenu = groupe.HeureRetenu;
            groupeToUpdate.LocalId = groupe.LocalId;
            groupeToUpdate.Status = groupe.Status;

            var membres = await _db.Etudiants
                .Where(e => groupe.MembresIds.Contains(e.Id))
                .ToListAsync();

            groupeToUpdate.Membres = membres;

            await _db.SaveChangesAsync();

            return ServiceResult.Ok();
        }
    }
}
