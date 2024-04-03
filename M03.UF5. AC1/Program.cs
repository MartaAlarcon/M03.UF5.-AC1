using M03.UF5._AC1;
using System;
using System.Text.RegularExpressions;
namespace AC1
{
    public class Program
    {
        public static void Main()
        {
            const int MAX = 10;

            List<Score> scores = new List<Score>();

            for (int i = 0; i < MAX; i++)
            {
                Console.WriteLine("Introduce el nombre: ");
                string? player = Console.ReadLine();
                Console.WriteLine("Introduce la misión: ");
                string? mission = Console.ReadLine();
                Console.WriteLine("Introduce la puntuación: ");
                int score = Convert.ToInt32(Console.ReadLine());
                Score s = new Score(player, mission, score);
                scores.Add(s);
                
            }

            List<Score> uniqueScores = GenerateUniqueScores(scores);
            uniqueScores.Sort();
            foreach (Score s in uniqueScores)
            {
                Console.WriteLine(s);
            }
        }

        public static List<Score> GenerateUniqueScores(List<Score> scores)
        {
            var uniqueScores = from s in scores
                               group s by new { s.Player, s.Mission } into g
                               select new Score(g.Key.Player, g.Key.Mission, g.Max(x => x.Scoring));
            return uniqueScores.ToList();

        }
    }
}