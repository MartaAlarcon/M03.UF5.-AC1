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
            const string MsgPlayer = "Introdueix el nom (només lletres): ";
            const string MsgMission = "Introdueix la missió (nom adaptat de les lletres en grec, seguit d’un guió i un número de 3 xifres) : ";
            const string MsgScore = "Introdueix la puntuació [0-500]: ";


            List<Score> scores = new List<Score>();

            for (int i = 0; i < MAX; i++)
            {
                Console.WriteLine($"Dades {i+1}");
                Console.WriteLine(MsgPlayer);
                string? player = Console.ReadLine();
                Console.WriteLine(MsgMission);
                string? mission = Console.ReadLine();
                Console.WriteLine(MsgScore);
                int score = Convert.ToInt32(Console.ReadLine());
                Score s = new Score(player, mission, score);
                scores.Add(s);
                
            }
            Console.Clear();

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