using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModelsLib
{
    public class GroupeEtude
    {
        public Cours Cours { get; set; }
        public string JourRetenu { get; set; }
        public int HeureRetenu {  get; set; }
        public List<Etudiant> Membres { get; set; }
        public Local Local {  get; set; }

        public GroupeEtude(Cours Cours, string JourRetenu, int HeureRetenu, List<Etudiant> Membres, Local Local = null)
        {
            this.Cours = Cours;
            this.JourRetenu = JourRetenu;
            this.HeureRetenu = HeureRetenu;
            this.Membres = Membres;
            this.Local = Local;
        }
    }
}
