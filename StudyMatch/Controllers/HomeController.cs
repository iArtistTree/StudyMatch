using Microsoft.AspNetCore.Mvc;
using MyMvcHost.Data;
using SharedModelsLib;
using StudyMatch.Models;
using System.Diagnostics;

namespace StudyMatch.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<GroupeEtude> groupeEtude = AppDao.GetGroupEtude();
            return View(groupeEtude);
        }

        public IActionResult Match()
        {
            List<Cours> cours = AppDao.GetCours();
            return View(cours);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
