namespace JeuPokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Jeu jeu = new Jeu();
                jeu.Jouer();

                Console.WriteLine("Voulez-vous rejouer ? (o/n)");
            } while (Console.ReadLine().ToLower() == "o");

            Console.WriteLine("Merci d'avoir joué ! À la prochaine !");
        }
    }
}
