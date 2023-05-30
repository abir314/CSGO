namespace CSGO;

public class Terrorists
{
    public string _name;
    public bool IsDead { get; set; }

    public Terrorists(string name)
    {
        _name = name;
    }

    public static bool FindBombSite()
    {
        return Game.IsSuccessful(10);
    }


    public static List<Counterterrorists> KillCounterTerrorist(List<Counterterrorists> counterTerroristTeam)
    {
        var isOperationSuccessfull = Game.IsSuccessful(7);
        if (isOperationSuccessfull)
        {
            var random = new Random();
            var index = random.Next(0, counterTerroristTeam.Count);
            for (var i = 0; i < counterTerroristTeam.Count; i++)
            {
                if (i == index && !counterTerroristTeam[i].IsDead)
                {
                    counterTerroristTeam[i].IsDead = true;
                    Console.WriteLine($"{counterTerroristTeam[i]._name} has been killed by the terrorists.");
                }
            }
        }
        else
        {
            Console.WriteLine("No counterterrorists could be killed by the terrorists in this round.");
        }

        return counterTerroristTeam;
    }

    public static void PlantBomb()
    {
        for (int i = 5; i > 0; i--)
        {
            
        }
    }
}