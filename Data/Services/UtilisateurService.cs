using Microsoft.EntityFrameworkCore;
using MyAppData.Data;
using MyAppData.Entities;
using SharedModelsLib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppData.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly SystemDbContext _db;
        public UtilisateurService(SystemDbContext db) => _db = db;

        public async Task<ServiceResult> AddUtilisateurAsync(UtilisateurDto utilisateur)
        {
            var newUtilisateur = new Utilisateur
            {
                Email = utilisateur.Email,
                Mdp = utilisateur.Mdp,
                EtudiantId = utilisateur.EtudiantId
            };

            _db.Utilisateurs.Add(newUtilisateur);
            await _db.SaveChangesAsync();
            return ServiceResult.Ok();
        }

        public async Task<UtilisateurDto?> GetUtilisateurAsync(string email)
        {
            return await _db.Utilisateurs.AsNoTracking()
                .Where(e => e.Email == email)
                .Select(e => new UtilisateurDto
                {
                    Id = e.Id,
                    Email = e.Email,
                    Mdp = e.Mdp,
                    EtudiantId = e.EtudiantId
                }).FirstOrDefaultAsync();
        }
    }
}
