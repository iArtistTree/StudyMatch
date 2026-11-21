using MyAppData;

namespace MyAppData
{
    public class GroupeEtude
    {
        public int Id { get; set; }
        public int CoursId { get; set; }
        public Cours Cours { get; set; }
        public string JourRetenu { get; set; }
        public int HeureRetenu { get; set; }
        public List<Etudiant> Membres { get; set; }
        public int? LocalId { get; set; }
        public Local? Local { get; set; }
        public bool Status { get; set; }

        public GroupeEtude()
        {
            Membres = new List<Etudiant>();
        }
    }
}