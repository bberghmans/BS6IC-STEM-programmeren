using PrisonersDilemma;

// We laten elke strategie N-keer tegen elkaar spelen
const int N = 100;
List<Strategy> StrategyList = Bart.Strategies(N);
StrategyList.AddRange(Bartu.Strategies(N));
StrategyList.AddRange(Xander.Strategies(N));
StrategyList.AddRange(Cas.Strategies(N));

StrategyList.RemoveAll(x => x.Name.ToLower().Contains("cheat"));
StrategyList.RemoveAll(x => x.Name.ToLower().Contains("exploit"));

StrategyList = new List<Strategy> { Bart.Strategies(N)[2], Bartu.Strategies(N)[2], Xander.Strategies(N)[0], Cas.Strategies(N)[2] };

int listCount = StrategyList.Count;
List<int> Wins = new List<int>(new int[listCount]);

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

        if (strategyA.MyCoins >= strategyB.MyCoins) Wins[i]++;
        if (strategyB.MyCoins >= strategyA.MyCoins) Wins[j]++;

        strategyA.Reset();
        strategyB.Reset();
    }
}

for (int i = 0; i < listCount; i++)
{
    Console.WriteLine($"Strategy {StrategyList[i].Name} ({StrategyList[i]}) has {Wins[i]} wins.");
}



