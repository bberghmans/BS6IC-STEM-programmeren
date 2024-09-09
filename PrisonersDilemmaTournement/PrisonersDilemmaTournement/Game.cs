using PrisonersDilemma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaTournement
{
    internal static class Game
    {
        public static void Play(Strategy.Move? moveA, Strategy.Move? moveB, out int CoinA, out int CoinB)
        {
            if (moveA == null || moveB == null)
                throw new ArgumentNullException();

            if (moveA == Strategy.Move.Cooperate)
                if (moveB == Strategy.Move.Cooperate)
                {
                    CoinA = CoinB = 3;
                }
                else
                {
                    CoinA = 0;
                    CoinB = 5;
                }
            else
                if (moveB == Strategy.Move.Cooperate)
                {
                    CoinB = 0;
                    CoinA = 5;
                }
                else
                {
                    CoinA = CoinB = 1;
                }
        }
    }
}
