using PrisonersDilemma;
using PrisonersDilemmaTournement;

const int N = 100;

Strategy bart0 = new StrategyBart0(N);
Strategy bart1 = new StrategyBart1(N);
Strategy bart2 = new StrategyBart2(N);
Strategy bart3 = new StrategyBart3(N);

List<Strategy> StrategyList = new List<Strategy> { bart0, bart1, bart2, bart3 };
int listCount = StrategyList.Count;

for (int i = 0; i < listCount; i++)
{
    for (int j = i + 1; j < listCount; j++)
    {
        Strategy strategy1 = StrategyList[i];
        Strategy strategy2 = StrategyList[j];

        for (int k = 0; k < N; k++)
        {
            Strategy.Move move1 = strategy1.PlayNext();
            Strategy.Move move2 = strategy2.PlayNext();

            int coin1 = 0;
            int coin2 = 0;

            Game.Play(move1, move2, out coin1, out coin2);

            strategy1.RegisterMove(move2, coin1, coin2);
            strategy2.RegisterMove(move1, coin2, coin1);
        }
        Console.WriteLine($"Game Results -> {strategy1.Name}:{strategy1.MyCoins} - {strategy2.Name}:{strategy2.MyCoins}");
        strategy1.Reset();
        strategy2.Reset();
    }
}
