using System;
using System.Collections.Generic;

namespace JeuPokemon
{
    public class Joueur
    {
        public string Nom { get; set; }
        public int MancheGagnee { get; set; }
        public int Argent { get; set; }
        private List<Pokemon> pokemons;

        public Joueur(string nom, int mancheGagnee, int argent)
        {
            Nom = nom;
            MancheGagnee = mancheGagnee;
            Argent = argent;
            pokemons = new List<Pokemon>();
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
        }

        public void ChoisirPokemon(List<Pokemon> pokemonsDisponibles)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Choisir le Pokémon {i + 1} parmi la liste suivante (Argent disponible: {Argent}):");

                for (int j = 0; j < pokemonsDisponibles.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {pokemonsDisponibles[j].Nom} (Prix: {pokemonsDisponibles[j].Prix})");
                }

                int choix;
                while (true)
                {
                    Console.Write("Votre choix: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out choix) && choix >= 1 && choix <= pokemonsDisponibles.Count)
                    {
                        choix--; 
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Choix invalide, réessayez.");
                    }
                }

                AcheterPokemon(pokemonsDisponibles[choix]);
            }
        }

        public void AcheterPokemon(Pokemon pokemon)
        {
            if (Argent >= pokemon.Prix)
            {
                pokemons.Add(pokemon);
                Argent -= pokemon.Prix;

                Console.WriteLine($"Vous avez acheté {pokemon.Nom} pour {pokemon.Prix} argent. Argent restant: {Argent}");
            }
            else
            {
                Console.WriteLine($"Vous n'avez pas assez d'argent pour acheter {pokemon.Nom}. Choisissez un autre Pokémon.");
            }
        }

        public Attaque ChoisirAttaque(Pokemon pokemon)
        {
            Console.WriteLine();
            pokemon.AfficherAttaquesAvecPP(); // Afficher les attaques avec leurs PP restants
            Console.WriteLine();

            Console.WriteLine($"Choisir une attaque pour {pokemon.Nom} :");
            for (int i = 0; i < pokemon.Attaques.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pokemon.Attaques[i].Nom}");
            }

            int choix;
            while (true)
            {
                Console.Write("Votre choix: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out choix) && choix >= 1 && choix <= pokemon.Attaques.Count)
                {
                    choix--; 
                    break;
                }
                else
                {
                    Console.WriteLine("Choix invalide, réessayez.");
                }
            }

            return pokemon.Attaques[choix];
        }

        public Pokemon RecupererPokemon(int index)
        {
            return pokemons[index];
        }

        public void AfficherPokemons()
        {
            foreach (var pokemon in pokemons)
            {
                pokemon.Afficher();
            }
        }

        public void Afficher()
        {
            Console.WriteLine($"Joueur: {Nom}, Manches gagnées: {MancheGagnee}, Argent: {Argent}");
        }
    }
}
