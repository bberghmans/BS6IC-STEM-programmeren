using System;

namespace PrisonersDilemma
{
    public class StrategyBart0 : Strategy
    {
        private Random random = new Random();

        public StrategyBart0(int numberOfMoves) : base(numberOfMoves)
        {
            Name = "Random";
        }

        public override Move PlayNext()
        {
            if (random.Next(2) == 0)
                return Move.Defect;
            else
                return Move.Cooperate;
        }
    }
    public class StrategyBart1 : Strategy
    {
        public StrategyBart1(int numberOfMoves) : base(numberOfMoves)
        {
            Name = "Cooperate";
        }

        public override Move PlayNext()
        {
            // I will always cooperate
            return Move.Cooperate;
        }
    }

    public class StrategyBart2 : Strategy
    {
        public StrategyBart2(int numberOfMoves) : base(numberOfMoves)
        {
            Name = "Defect";
        }

        public override Move PlayNext()
        {
            // I will always defect
            return Move.Defect;
        }
    }

    public class StrategyBart3 : Strategy
    {
        public StrategyBart3(int numberOfMoves) : base(numberOfMoves)
        {
            Name = "TitForTat";
        }
        public override Move PlayNext()
        {
            if (OtherPreviousMove == Move.Defect) return Move.Defect;
            else return Move.Cooperate;
        }
    }
}
