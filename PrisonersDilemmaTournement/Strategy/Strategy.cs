using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemma
{
    public abstract class Strategy
    {
        public string Name { get; protected set; } = "";
        public string Description { get; protected set; } = "";

        public int MyCoins { get; protected set; } = 0;
        protected int OtherCoins { get; set; } = 0;
        protected Move? OtherPreviousMove = null;

        private int totalMoves;

        public Strategy(int numberOfMoves)
        {
            totalMoves = numberOfMoves;
        }

        public enum Move { Cooperate, Defect };

        public abstract Move PlayNext();

        // Sla het resultaat van de vorige spelronde op
        public void RegisterMove(Move othersMove, int coinWon, int otherCoinsWon)
        {
            MyCoins += coinWon;
            OtherCoins += otherCoinsWon;
            OtherPreviousMove = othersMove;
        }

        // Reset alle tellers
        public void Reset()
        { 
            MyCoins = 0;
            OtherCoins = 0;
            OtherPreviousMove = null;
        }
    }
}
