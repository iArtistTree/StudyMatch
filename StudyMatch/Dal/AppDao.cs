/*
using System.Collections.Generic;
using SharedModelsLib;

namespace MyMvcHost.Data
{
    public static class AppDao
    {
        public static List<Cours> Cours = new List<Cours>
        {
            new Cours("MATH101", "Mathématiques"),
            new Cours("FR102", "Français"),
            new Cours("ANG103", "Anglais"),
            new Cours("WEB201", "Programmation Web"),
            new Cours("JEU202", "Développement de jeux vidéo")
        };

        public static List<Etudiant> Etudiants = new List<Etudiant>
        {
            new Etudiant("Alice"),
            new Etudiant("Bob"),
            new Etudiant("Chloé"),
            new Etudiant("David"),
            new Etudiant("Emma"),
            new Etudiant("Félix"),
            new Etudiant("Katelynn"),
            new Etudiant("Eddy")
        };

        public static List<Disponibilite> Disponibilites = new List<Disponibilite>
        {
            new Disponibilite("Lundi", "MATH101", new List<int> { 10, 11, 13 }, "Alice"),
            new Disponibilite("Lundi", "MATH101", new List<int> { 10, 11 }, "Bob"),
            new Disponibilite("Mardi", "FR102", new List<int> { 9, 10 }, "Chloé"),
            new Disponibilite("Mardi", "FR102", new List<int> { 9, 14 }, "David"),
            new Disponibilite("Mercredi", "ANG103", new List<int> { 13, 14, 15 }, "Emma"),
            new Disponibilite("Mercredi", "ANG103", new List<int> { 14, 15 }, "Félix"),
            new Disponibilite("Jeudi", "WEB201", new List<int> { 8, 9, 10 }, "Katelynn"),
            new Disponibilite("Jeudi", "WEB201", new List<int> { 9, 10 }, "Eddy"),
            new Disponibilite("Vendredi", "JEU202", new List<int> { 11, 12 }, "Alice"),
            new Disponibilite("Vendredi", "JEU202", new List<int> { 12, 13 }, "Bob"),
            new Disponibilite("Vendredi", "JEU202", new List<int> { 14, 15 }, "Eddy")
        };

        public static List<Local> Locaux = new List<Local>
        {
            new Local("A-101", new Dictionary<string, List<int>>
            {
                { "Lundi", new List<int> { 10, 11 } },
                { "Jeudi", new List<int> { 8, 9 } }
            }),
            new Local("A-102", new Dictionary<string, List<int>>
            {
                { "Mardi", new List<int> { 9, 10 } },
                { "Vendredi", new List<int> { 12, 13 } }
            }),
            new Local("B-201", new Dictionary<string, List<int>>
            {
                { "Mercredi", new List<int> { 14, 15 } }
            }),
            new Local("B-202", new Dictionary<string, List<int>>()),
            new Local("C-312", new Dictionary<string , List<int>>
            {
                { "Vendredi", new List<int> { 14, 15 } }
            })
        };

        public static List<GroupeEtude> Groupes = new List<GroupeEtude>
        {
            new GroupeEtude(
                Cours[0],           // MATH101
                "Lundi", 10,
                new List<Etudiant> { Etudiants[0], Etudiants[1] }, // Alice, Bob
                Locaux[0]           // A-101
            ),
            new GroupeEtude(
                Cours[2],           // ANG103
                "Mercredi", 14,
                new List<Etudiant> { Etudiants[4], Etudiants[5] }, // Emma, Félix
                Locaux[2]           // B-201
            ),
            new GroupeEtude(
                Cours[3],           // WEB201
                "Jeudi", 9,
                new List<Etudiant> { Etudiants[6], Etudiants[7] }, // Katelynn, Eddy
                null                // pas de local assigné (à tester)
            )
        };

        //Methodes d'acces
        public static List<GroupeEtude> GetGroupEtude()
        {
            return Groupes;
        }

        public static List<Cours> GetCours()
        {
            return Cours;
        }

        public static List<Disponibilite> GetDisponibilitesByCours(string ccode)
        {
            return Disponibilites.Where(d => d.CoursCode == ccode).ToList();
        }

        public static List<Local> GetLocaux()
        {
            return Locaux;
        }

        public static Cours GetCoursByCode(string coursCode)
        {
            return Cours.FirstOrDefault(c => c.Code == coursCode);
        }

        public static Etudiant GetEtudiantByName(string name)
        {
            return Etudiants.FirstOrDefault(e => e.Nom == name);
        }

        public static Local? GetLocalByHoraire(string day, int time)
        {
            return Locaux.FirstOrDefault(l =>
            l.Horaires.TryGetValue(day, out var heures) && heures.Contains(time)
            && !GetGroupEtude().Any(g => g.Local == l && g.JourRetenu == day && g.HeureRetenu == time));

            
        }
    }
}
*/