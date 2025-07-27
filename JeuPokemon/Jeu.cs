using System;
using System.Collections.Generic;

namespace JeuPokemon
{
    public class Jeu
    {
        private Joueur joueur1;
        private Joueur joueur2;
        private List<Pokemon> pokemonsDisponibles;

        public Jeu()
        {
            pokemonsDisponibles = InitialiserPokemons();
        }

        public void Jouer()
        {
            // Créer le joueur 1
            Console.WriteLine($"Saisir le nom du joueur 1: ");
            string nom1 = Console.ReadLine();
            joueur1 = new Joueur(nom1, 0, 500);
            joueur1.ChoisirPokemon(pokemonsDisponibles);

            // Créer    le joueur 2
            Console.WriteLine($"Saisir le nom du joueur 2: ");
            string nom2 = Console.ReadLine();
            joueur2 = new Joueur(nom2, 0, 500);
            joueur2.ChoisirPokemon(pokemonsDisponibles);

            // Logique du jeu
            for (int round = 0; round < 3; round++)
            {
                    
                Console.WriteLine($"Round {round + 1}");
                if (joueur1.Pokemons.Count <= round)
                { 
                    Console.WriteLine($"{joueur1.Nom} n'a pas de Pokémon pour le round {round + 1}.");
                    joueur2.MancheGagnee++;
                    continue;
                }
                
                if (joueur2.Pokemons.Count <= round) 
                {
                    Console.WriteLine($"{joueur2.Nom} n'a pas de Pokémon pour le round {round + 1}.");
                    joueur1.MancheGagnee++;
                    continue;
                }


                
                Pokemon pokemon1 = joueur1.RecupererPokemon(round);

                Pokemon pokemon2 = joueur2.RecupererPokemon(round);


                while (!pokemon1.EstKO() && !pokemon2.EstKO())
                {
                    // Choix d'attaques
                    Attaque attaque1 = joueur1.ChoisirAttaque(pokemon1);
                    Attaque attaque2 = joueur2.ChoisirAttaque(pokemon2);

                    // Le Pokémon avec la plus grande vitesse attaque en premier
                    if (pokemon1.Vitesse >= pokemon2.Vitesse)
                    {
                        pokemon1.Attaquer(pokemon2, attaque1);
                        if (!pokemon2.EstKO())
                        {
                            pokemon2.Attaquer(pokemon1, attaque2);
                        }
                    }
                    else
                    {
                        pokemon2.Attaquer(pokemon1, attaque2);
                        if (!pokemon1.EstKO())
                        {
                            pokemon1.Attaquer(pokemon2, attaque1);
                        }
                    }
                }

                // Déterminer le gagnant du round
                if (pokemon1.EstKO())
                {
                    joueur2.MancheGagnee++;
                }
                else
                {
                    joueur1.MancheGagnee++;
                }

                Console.WriteLine($"Fin du round {round + 1}");
                Console.WriteLine($"{joueur1.Nom} - Manches gagnées: {joueur1.MancheGagnee}");
                Console.WriteLine($"{joueur2.Nom} - Manches gagnées: {joueur2.MancheGagnee}");
                Console.ReadLine(); // Attendre que l'utilisateur appuie sur une touche avant de nettoyer
                Console.Clear();
            }

            // Déterminer le gagnant final
            Joueur gagnant = joueur1.MancheGagnee > joueur2.MancheGagnee ? joueur1 : joueur2;
            Console.WriteLine($"Le gagnant est {gagnant.Nom}");

            Console.ReadLine();// Attendre que l'utilisateur appuie sur une touche avant de nettoyer

        }
        private List<Pokemon> InitialiserPokemons()
        {
            var liste = new List<Pokemon>
    {

        new Pokemon("Electrode", 180, new string[] { "Électrique" }, 110, 10, 50, 80, 50, 80, 140)
        {
            Attaques = new List<Attaque>
            {
                new Attaque("Tonnerre", "Électrique", "Spéciale", 100, 90, 15),
                new Attaque("Explosion", "Normal", "Physique", 100, 250, 5),
                new Attaque("Balle Graine", "Normal", "Physique", 100, 25, 30)
            }
        },
        new Pokemon("Caninos", 190, new string[] { "Feu" }, 120, 10, 60, 60, 45, 50, 55)
        {
            Attaques = new List<Attaque>
            {
                new Attaque("Flameche", "Feu", "Spéciale", 100, 40, 25),
                new Attaque("Charge", "Normal", "Physique", 100, 50, 35),
                new Attaque("Crocs Feu", "Feu", "Physique", 95, 65, 15)
            }
        },
        new Pokemon("Krabby", 170, new string[] { "Eau" }, 90, 10, 105, 25, 90, 25, 50)
        {
            Attaques = new List<Attaque>
            {
                new Attaque("Pince Masse", "Eau", "Physique", 90, 55, 20),
                new Attaque("Bulldoboule", "Normal", "Physique", 85, 85, 10),
                new Attaque("Écras'Face", "Normal", "Physique", 100, 40, 35)
            }
        },
        new Pokemon("Rocabot", 120, new string[] { "Roche" }, 110, 10, 65, 45, 50, 55, 60)
        {
            Attaques = new List<Attaque>
            {
                new Attaque("Jet-Pierres", "Roche", "Physique", 95, 50, 15),
                new Attaque("Coup d'Boule", "Normal", "Physique", 100, 70, 15),
                new Attaque("Morsure", "Normal", "Physique", 100, 60, 25)
            }
        },
        new Pokemon("Tritox", 150, new string[] { "Poison", "Feu" }, 120, 10, 54, 50, 40, 50, 64)
        {
            Attaques = new List<Attaque>
            {
                new Attaque("Déflagration", "Feu", "Spéciale", 85, 110, 5),
                new Attaque("Acide", "Poison", "Spéciale", 100, 40, 30),
                new Attaque("Flameche", "Feu", "Spéciale", 100, 40, 25)
            }
        },
        new Pokemon("Lucario", 230, new string[] { "Combat", "Acier" }, 130, 10, 70, 115, 70, 70, 90)
        {
            Attaques = new List<Attaque>
            {
                new Attaque("Close Combat", "Combat", "Physique", 100, 120, 5),
                new Attaque("Poing Météore", "Acier", "Physique", 85, 90, 10),
                new Attaque("Aurasphère", "Combat", "Spéciale", 100, 80, 20)
            }
        },
        new Pokemon("Absol", 200, new string[] { "Ténèbres" }, 140, 10, 130, 75, 60, 60, 75)
        {
            Attaques = new List<Attaque>
            {
                new Attaque("Tranche", "Normal", "Physique", 100, 70, 20),
                new Attaque("Psycho-Croc", "Ténèbres", "Physique", 95, 85, 15),
                new Attaque("Vibrobscur", "Ténèbres", "Spéciale", 100, 80, 15)
            }
        },
        new Pokemon("Arbok", 220, new string[] { "Poison" }, 120, 10, 85, 65, 69, 79, 80)
        {
            Attaques = new List<Attaque>
            {
                new Attaque("Acide", "Poison", "Spéciale", 100, 40, 30),
                new Attaque("Morsure", "Normal", "Physique", 100, 60, 25),
                new Attaque("Dard-Venin", "Poison", "Physique", 100, 15, 35)
            }
        },
        new Pokemon("Maraiste", 190, new string[] { "Eau", "Sol" }, 160, 10, 85, 65, 95, 85, 35)
        {
            Attaques = new List<Attaque>
            {
                new Attaque("Surf", "Eau", "Spéciale", 100, 90, 15),
                new Attaque("Séisme", "Sol", "Physique", 100, 100, 10),
                new Attaque("Plaquage", "Normal", "Physique", 100, 85, 20)
            }
        }
    };
            return liste;
        }



    }
}
