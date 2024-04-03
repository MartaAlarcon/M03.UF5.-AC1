using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace M03.UF5._AC1
{
    public class Score : IComparable<Score>
    {
        private string? player;
        private string? mission;
        private int scoring;

        public Score(string player, string mission, int scoring)
        {
            this.Player = player;
            this.Mission = mission;
            this.Scoring = scoring;
        }

        public string? Player
        {
            get { return player; }
            set
            {
                if (Regex.IsMatch(value.Trim(), @"^[A-Za-z]+$"))
                {
                    player = value;
                }
                else
                {
                    Console.WriteLine("Només pot contenir caràcters alfabètics (sense accents ni caràcters especials)\r\n");
                    player = "Unknown"; //Si no se introduce bien, te pone este valor.
                }
            }
        }

        public string? Mission
        {
            get { return mission; }
            set
            {

                if (Regex.IsMatch(value.Trim(), @"^(Alpha|Beta|Gamma|Delta|Epsilon|Zeta|Eta|Theta|Iota|Kappa|Lambda|Mu|Nu|Xi|Omicron|Pi|Rho|Sigma|Tau|Upsilon|Phi|Chi|Psi|Omega)-[0-9]{3}$"))
                {
                    mission = value;
                }
                else  
                {
                    Console.WriteLine("Ha de contenir com a prefix el nom adaptat de les lletres en grec, seguit d’un guió i un número de 3 xifres. Per exemple: Delta-003\r\n");
                    mission = "Delta-003"; //Si no se introduce bien, te pone este valor.                
                }
            }
        }

        public int Scoring
        {
            get { return scoring; }
            set
            {
                if (value >= 0 && value <= 500)
                {
                    scoring = value;
                }
                else 
                {
                    Console.WriteLine("Ha de ser un valor comprès en el rang [0-500]");
                    scoring = 0; //Si no se introduce bien, te pone este valor.
                }
            }
        }

        public int CompareTo(Score? other)
        {
            if (other == null) return 1;
            return -Scoring.CompareTo(other.Scoring);
        }

        public override string ToString()
        {
            return "Player: " + Player + "\nMission: " + Mission + "\nScore: " + Scoring;
        }

    }
}
