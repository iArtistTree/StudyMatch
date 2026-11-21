using Microsoft.AspNetCore.Mvc;
using MyAppData;
using MyAppData.Data;
using MyAppData.Services;
using SharedModelsLib;
using SharedModelsLib.Dtos;
using StudyMatch.Models;
using System.Diagnostics;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace StudyMatch.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGroupeEtudeService _groupes;
        private readonly ICoursService _cours;
        private readonly IEtudiantService _etudiants;
        private readonly IDisponibiliteService _disponibilites;
        private readonly ILocalService _locaux;

        public HomeController(IGroupeEtudeService groupes, ICoursService cours, IEtudiantService etudiants, IDisponibiliteService disponibilites, ILocalService locaux)
        {
            _groupes = groupes;
            _cours = cours;
            _etudiants = etudiants;
            _disponibilites = disponibilites;
            _locaux = locaux;
        }

        public async Task<IActionResult> Index()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Index", "Account");
            }

            var groupeEtude = await _groupes.GetGroupesEtudeAsync(); //AppDao.GetGroupEtude();
            return View(groupeEtude);
        }

        public async Task<IActionResult> Match()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Index", "Account");
            }

            var cours = await _cours.GetCoursAsync(); //AppDao.GetCours();
            return View(cours);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> AddEtudiant(string etudiant, string disponibilites)
        {
            var e = JsonSerializer.Deserialize<EtudiantDto>(etudiant);
            List<DisponibiliteDto>? d = JsonSerializer.Deserialize<List<DisponibiliteDto>>(disponibilites);

            if (e == null || d == null || d.Count == 0)
                return BadRequest("Données invalides");

            TryValidateModel(e);

            foreach (var dispo in d)
            {
                TryValidateModel(dispo);
            }

            if(!ModelState.IsValid)
                return BadRequest(ModelState);


            //Adds student
            //AppDao.Etudiants.Add(e);
            await _etudiants.AddEtudiantAsync(e);


            //Add dispos
            foreach (var dispo in d)
            {
                dispo.EtudiantId = e.Id;
                //AppDao.Disponibilites.Add(dispo);
                await _disponibilites.AddDisponibiliteAsync(dispo);
            }

            await MatchGroupes(d);

            return RedirectToAction("Index");
        }

        private async Task MatchGroupes(List<DisponibiliteDto> disponibilites)
        {
            foreach (var ed in disponibilites)
            {
                List<DisponibiliteDto> dispoCours = await _disponibilites.GetDisponibilitesByCoursAsync(ed.CoursId);

                //foreach (var dispo in AppDao.GetDisponibilitesByCours(ed.CoursCode))
                foreach (var d in dispoCours)
                {
                    if (ed.EtudiantId == d.EtudiantId)
                        continue;

                    if (ed.Jour != d.Jour) 
                        continue;

                    var heuresMatching = ed.Heures.Intersect(d.Heures).ToList();

                    if (heuresMatching.Count == 0)
                        continue;

                    var groupesExistant = await _groupes.GetGroupesEtudeAsync();

                    var ge = groupesExistant.FirstOrDefault(g =>
                        g.CoursId == ed.CoursId &&
                        g.JourRetenu == ed.Jour &&
                        g.HeureRetenu == heuresMatching[0]
                    );

                    if(ge != null)
                    {
                        if (!ge.MembresIds.Contains(ed.EtudiantId))
                        {
                            ge.MembresIds.Add(ed.EtudiantId);
                            await _groupes.UpdateGroupeEtudeAsync(ge);
                        }
                        break;
                    }

                    List<EtudiantDto> eList = new List<EtudiantDto>();
                    /*
                    var localChoisi = AppDao.GetLocalByHoraire(ed.Jour, heuresMatching[0]);
                    eList.Add(AppDao.GetEtudiantByName(ed.EtudiantNom));
                    eList.Add(AppDao.GetEtudiantByName(dispo.EtudiantNom));
                    
                    GroupeEtude ge = new GroupeEtude(AppDao.GetCoursByCode(ed.CoursCode), ed.Jour, heuresMatching[0], eList, localChoisi);
                    AppDao.Groupes.Add(ge);
                    */

                    var localChoisi = await _locaux.GetLocalByHoraireAsync(ed.Jour, heuresMatching[0]);
                    var etudiant1 = await _etudiants.GetEtudiantAsync(ed.EtudiantId);
                    var etudiant2 = await _etudiants.GetEtudiantAsync(d.EtudiantId);

                    if (etudiant1 == null || etudiant2 == null)
                        continue;

                    eList.Add(etudiant1);
                    eList.Add (etudiant2);

                    GroupeEtudeDto groupe = new GroupeEtudeDto
                    {
                        CoursId = ed.CoursId,
                        JourRetenu = ed.Jour,
                        HeureRetenu = heuresMatching[0],
                        LocalId = localChoisi?.Id,
                        MembresIds = eList.Select(e => e.Id).ToList(),
                        Status = true
                    };

                    await _groupes.AddGroupeEtudeAsync(groupe);
                }
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UtilisateurId");

            return RedirectToAction("Index", "Account");
        }

        private bool IsLoggedIn()
        {
            return HttpContext.Session.GetInt32("UtilisateurId") != null;
        }
    }
}
