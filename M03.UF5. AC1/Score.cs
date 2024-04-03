using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
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

        const int MIN = 0, MAX = 500;
        const string PatternMission = @"^(Alpha|Beta|Gamma|Delta|Epsilon|Zeta|Eta|Theta|Iota|Kappa|Lambda|Mu|Nu|Xi|Omicron|Pi|Rho|Sigma|Tau|Upsilon|Phi|Chi|Psi|Omega)-[0-9]{3}$";
        const string PatternPlayer = @"^[A-Za-z]+$";
        const string MsgPlayer = "Només pot contenir caràcters alfabètics (sense accents ni caràcters especials). Introduit predeterminat amb valor: Unknown";
        const string MsgMission = "Ha de contenir com a prefix el nom adaptat de les lletres en grec, seguit d’un guió i un número de 3 xifres. Introduit predeterminat amb valor: Delta-003";
        const string MsgScoring = "Ha de ser un valor comprès en el rang [0-500]. Introduit predeterminat amb valor: 0";
        const string DeffaultPlayer = "Unknown";
        const string DeffaultMission = "Delta-003";

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
                if (Regex.IsMatch(value.Trim(), PatternPlayer))
                {
                    player = value;
                }
                else
                {
                    Console.WriteLine(MsgPlayer);
                    player = DeffaultPlayer; //Si no se introduce bien, te pone este valor.
                }
            }
        }

        public string? Mission
        {
            get { return mission; }
            set
            {

                if (Regex.IsMatch(value.Trim(), PatternMission))
                {
                    mission = value;
                }
                else  
                {
                    Console.WriteLine(MsgMission);
                    mission = DeffaultMission; //Si no se introduce bien, te pone este valor.                
                }
            }
        }

        public int Scoring
        {
            get { return scoring; }
            set
            {
                if (value >= MIN && value <= MAX)
                {
                    scoring = value;
                }
                else 
                {
                    Console.WriteLine(MsgScoring);
                    scoring = MIN; //Si no se introduce bien, te pone este valor.
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
