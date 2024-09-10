using PrisonersDilemma;

// We laten elke strategie N-keer tegen elkaar spelen
const int N = 100;
List<Strategy> StrategyList = Bart.Strategies(N);
int listCount = StrategyList.Count;

// Dubbele lus om elke combinatie aan tegenstanders te bepalen
for (int i = 0; i < listCount; i++)
{
    for (int j = i + 1; j < listCount; j++)
    {
        // kopieer een referentie naar de twee strategieen
        Strategy strategyA = StrategyList[i];
        Strategy strategyB = StrategyList[j];

        for (int k = 0; k < N; k++)
        {
            // vraag aan elke strategie wat de volgende zet gaat zijn
            Strategy.Move moveA = strategyA.PlayNext();
            Strategy.Move moveB = strategyB.PlayNext();

            // laat Game.Play de outkomst bepalen en sla deze op in coinA en coinB
            int coinA = 0;
            int coinB = 0;
            Game.Play(moveA, moveB, out coinA, out coinB);

            // laat aan de strategieen weten wat de andere gespeeld heeft, en wat de uitkomsten waren
            strategyA.RegisterMove(moveB, coinA, coinB);
            strategyB.RegisterMove(moveA, coinB, coinA);
        }
        Console.WriteLine($"Game Results -> {strategyA.Name}:{strategyA.MyCoins} - {strategyB.Name}:{strategyB.MyCoins}");
        strategyA.Reset();
        strategyB.Reset();
    }
}
