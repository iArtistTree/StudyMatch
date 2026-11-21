using Microsoft.AspNetCore.Mvc;
using MyAppData.Services;
using SharedModelsLib.Dtos;

namespace MyMvcHost.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUtilisateurService _utilisateurs;

        public AccountController(IUtilisateurService utilisateurs)
        {
            _utilisateurs = utilisateurs;
        }

        public IActionResult Index()
        {
            if (IsLoggedIn())
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string mdp)
        {
            string msg = string.Empty;

            var compte = await _utilisateurs.GetUtilisateurAsync(email);

            if (compte == null || mdp != compte.Mdp) //Email ou Mdp incorrect
            {
                ViewBag.Message = "Email ou mot de passe incorrecte";
                return View("Index");
            }

            HttpContext.Session.SetInt32("UtilisateurId", compte.Id);

            return RedirectToAction("Index", "Home", new {msg=email});
        }

        public IActionResult Register()
        {
            if (IsLoggedIn())
                return RedirectToAction("Index", "Home");

            return View("Signup");
        }

        [HttpPost]
        public async Task<IActionResult> Signin(string email, string mdp, string mdpc)
        {
            if(mdp != mdpc)
            {
                ViewBag.Message = "Les mots de passe ne correspondent pas";
                return View("Signup");
            }

            UtilisateurDto newCompte = new UtilisateurDto
            {
                Email = email,
                Mdp = mdp,
                //Will need to rework form and stuff to link it to an Etudiant object
            };

            TryValidateModel(newCompte);

            if (!ModelState.IsValid)
                return View("Signup");

            await _utilisateurs.AddUtilisateurAsync(newCompte);

            return RedirectToAction("Index");
        }

        private bool IsLoggedIn()
        {
            return HttpContext.Session.GetInt32("UtilisateurId") != null;
        }
    }
}
