namespace CSGO;

public class Game
{
    public Game()
    {
        var terroristTeam = new List<Terrorists>();
        var counterTerroristTeam = new List<Counterterrorists>();
        terroristTeam.Add(new Terrorists("Abir1"));
        terroristTeam.Add(new Terrorists("Abir2"));
        terroristTeam.Add(new Terrorists("Abir3"));
        terroristTeam.Add(new Terrorists("Abir4"));
        terroristTeam.Add(new Terrorists("Abir5"));
        counterTerroristTeam.Add(new Counterterrorists("Noah1"));
        counterTerroristTeam.Add(new Counterterrorists("Noah2"));
        counterTerroristTeam.Add(new Counterterrorists("Noah3"));
        counterTerroristTeam.Add(new Counterterrorists("Noah4"));
        counterTerroristTeam.Add(new Counterterrorists("Noah5"));
        var roundCount = 0;
        bool bombSiteFound = false;
        bool bombPlanted = false;
        bool bombExploded = false;
        bool gameRunning = true;
        int bombExplosionRound = 0;
        int bombplantSuccesRound = 0;
        var terroristActionCounter = 0;
        var bombDifusedRound = 0;
        while (gameRunning)
        {
            
            Console.WriteLine($"Game seconds : {roundCount}");
            var allCounterterroristsAreDead = AllCounterterroristsAreDead(counterTerroristTeam);
            var allTerroristsAreDead = AllTerroristsAreDead(terroristTeam);

            if (roundCount % 2 == 1)
            {
                if(allTerroristsAreDead) Console.WriteLine("All terrorists are already dead.");
                else
                {
                    Console.WriteLine("It is terrorists turn.");
                    if (terroristActionCounter % 2 == 0)
                    {
                        if (!bombSiteFound)
                        {
                            bombSiteFound = Terrorists.FindBombSite();
                            Console.WriteLine(bombSiteFound
                                ? "Bomb planting site A is found by terrorists in this round"
                                : "Bomb planting site A is not found by terrorists in this round.");
                        }

                        if (bombSiteFound)
                        {
                            if (!bombPlanted)
                            {
                                Terrorists.PlantBomb();
                                bombplantSuccesRound = roundCount + 5;
                                bombPlanted = true;

                            }
                        }
                    }

                    if (terroristActionCounter % 2 == 1 && !allCounterterroristsAreDead)
                    {
                        counterTerroristTeam = Terrorists.KillCounterTerrorist(counterTerroristTeam);
                    }

                    terroristActionCounter++;
                }

            }
            
            if (roundCount % 2 == 0)
            {
                Console.WriteLine("It is counter terrorists turn.");
                if (!allTerroristsAreDead)
                {
                    if (!bombPlanted)
                    {
                        terroristTeam = Counterterrorists.KillTerrorist(terroristTeam, 5);
                    }

                    if (bombPlanted) terroristTeam = Counterterrorists.KillTerrorist(terroristTeam, 3);
                    bombDifusedRound = roundCount + 5;
                }
            }
            
            if (bombplantSuccesRound > roundCount && bombPlanted)
                Console.WriteLine($"{bombplantSuccesRound - roundCount} seconds remaining to plant bomb.");
            if (bombplantSuccesRound == roundCount && bombPlanted)
            {
                Console.WriteLine("Bomb is planted.");
                bombExplosionRound = roundCount + 15;
            }


            if (bombPlanted && !bombExploded)
            {
                if (bombExplosionRound > roundCount)
                {
                    Console.WriteLine($"{bombExplosionRound - roundCount} seconds remaining til explosion.");
                }
                else if (bombExplosionRound == roundCount)
                {
                    Console.WriteLine("Bomb has exploded, game over. Terrorists have won.");
                    bombExploded = true;
                    break;
                }
            }

            if (allTerroristsAreDead && bombPlanted && !bombExploded)
            {
               if(bombDifusedRound > roundCount) Console.WriteLine($"All the terrorists have been killed. {bombDifusedRound - roundCount} seconds remaining to diffuse the bomb.");
               if (bombDifusedRound == roundCount)
               {
                   Console.WriteLine("Bomb has been diffused by the counter terrorists and counter terrorists have won.");
                   break;
               }
            }
            allCounterterroristsAreDead = AllCounterterroristsAreDead(counterTerroristTeam);
            if (allCounterterroristsAreDead)
            {
                Console.WriteLine("Everyone in counterterrorist team is dead, game over.");
                break;
            }
            roundCount++;
            Console.WriteLine("Press enter to go to next round.....");
            Console.Read();
        }

    }

    private static bool AllTerroristsAreDead(List<Terrorists> terroristTeam)
    {
        var allTerroristsAreDead = true;
        terroristTeam.ForEach(terrorist => { allTerroristsAreDead = allTerroristsAreDead && terrorist.IsDead; });
        return allTerroristsAreDead;
    }

    private static bool AllCounterterroristsAreDead(List<Counterterrorists> counterTerroristTeam)
    {
        var allCounterterroristsAreDead = true;
        counterTerroristTeam.ForEach(ct => { allCounterterroristsAreDead = allCounterterroristsAreDead && ct.IsDead; });
        return allCounterterroristsAreDead;
    }


    public static bool IsSuccessful(int maxValue)

    {

        Random rand = new Random();

        return rand.Next(0, maxValue) == 2;

    }
}