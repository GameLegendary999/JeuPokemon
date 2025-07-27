using System;

namespace JeuPokemon
{
    public class Attaque
    {
        public string Nom { get; set; }
        public string Type { get; set; }
        public string CategorieAttaque { get; set; }
        public int Precision { get; set; }
        public int Puissance { get; set; }
        public int Pp { get; set; }
        private static Random random = new Random();

        public Attaque(string nom, string type, string categorie, int precision, int puissance, int pp)
        {
            Nom = nom;
            Type = type;
            CategorieAttaque = categorie;
            Precision = precision;
            Puissance = puissance;
            Pp = pp;
        }

        public int CalculerDegats(Pokemon attaquant, Pokemon defenseur)
        {
            double stab = Array.Exists(attaquant.Types, t => t == Type) ? 1.5 : 1.0; // STAB
            double cm = stab * (Precision / 100.0);
            double niv = attaquant.Niveau;
            double att = CategorieAttaque == "Physique" ? attaquant.Attaque : attaquant.AttaqueSpeciale;
            double def = CategorieAttaque == "Physique" ? defenseur.Defense : defenseur.DefenseSpeciale;
            double pui = Puissance;

            // Calcul des chances de coup critique
            bool critique = random.Next(16) == 0; // 1 chance sur 16 d'un coup critique
            double facteurCritique = critique ? 2.0 : 1.0; // Dégâts doublés

            double dommages = (((niv * 0.4 + 2) * att * pui) / (def * 50) + 2) * cm * facteurCritique;

            if (critique)
            {
                Console.WriteLine("Coup critique !");
            }

            return (int)dommages;
        }

        public void Afficher()
        {
            Console.WriteLine($"Attaque: {Nom}, Type: {Type}, Précision: {Precision}, Puissance: {Puissance}, PP: {Pp}");
        }
    }
}
