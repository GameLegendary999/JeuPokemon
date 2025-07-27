using System;
using System.Collections.Generic;

namespace JeuPokemon
{
    public class Pokemon
    {
        public string Nom { get; set; }
        public int Prix { get; set; }
        public string[] Types { get; set; }
        public int PointsDeVie { get; set; }
        public int Niveau { get; set; }
        public int Attaque { get; set; }
        public int AttaqueSpeciale { get; set; }
        public int Defense { get; set; }
        public int DefenseSpeciale { get; set; }
        public int Vitesse { get; set; }
        private List<Attaque> attaques;

        public Pokemon(string nom, int prix, string[] types, int pointsDeVie, int niveau, int attaque, int attaqueSpeciale, int defense, int defenseSpeciale, int vitesse)
        {
            Nom = nom;
            Prix = prix;
            Types = types;
            PointsDeVie = pointsDeVie;
            Niveau = niveau;
            Attaque = attaque;
            AttaqueSpeciale = attaqueSpeciale;
            Defense = defense;
            DefenseSpeciale = defenseSpeciale;
            Vitesse = vitesse;
            attaques = new List<Attaque>();
        }

        public List<Attaque> Attaques
        {
            get { return attaques; }
            set { attaques = value; }
        }

        public void AjouterAttaque(Attaque attaque)
        {
            attaques.Add(attaque);
        }

        public void Attaquer(Pokemon cible, Attaque attaque)
        {
            if (attaque.Pp > 0)
            {
                int degats = attaque.CalculerDegats(this, cible);
                cible.PointsDeVie -= degats;
                attaque.Pp--;

                Console.WriteLine($"{Nom} utilise {attaque.Nom} contre {cible.Nom}, causant {degats} dégâts.");
            }
            else
            {
                Console.WriteLine($"{Nom} ne peut pas utiliser {attaque.Nom}, les PP sont à zéro.");
            }
        }

        public bool EstKO()
        {
            return PointsDeVie <= 0;
        }

        public void AfficherAttaquesAvecPP()
        {
            foreach (var attaque in attaques)
            {
                Console.WriteLine($"Attaque: {attaque.Nom}, Type: {attaque.Type}, Précision: {attaque.Precision}, Puissance: {attaque.Puissance}, PP restants: {attaque.Pp}");
            }
        }

        public void Afficher()
        {
            Console.WriteLine($"Pokémon: {Nom}, Types: {string.Join(", ", Types)}, PV: {PointsDeVie}, Niveau: {Niveau}");
        }
    }
}
