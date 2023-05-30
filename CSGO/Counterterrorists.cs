namespace CSGO;

public class Counterterrorists
{
    public string _name;
    public bool IsDead { get; set; }

    public Counterterrorists(string name)
    {
        _name = name;
    }


    public static List<Terrorists> KillTerrorist(List<Terrorists> terroristTeam, int chance)
    {
        var isOperationSuccessfull = Game.IsSuccessful(chance);                                                   
        if (isOperationSuccessfull)                                                                          
        {                                                                                                    
            var random = new Random();                                                                       
            var index = random.Next(0, terroristTeam.Count);
            while (terroristTeam[index].IsDead)
            {
                index = random.Next(0, terroristTeam.Count);
            }
            for (var i = 0; i < terroristTeam.Count; i++)                                             
            {                                                                                                
                if (i == index && !terroristTeam[i].IsDead)                                           
                {                                                                                            
                    terroristTeam[i].IsDead = true;                                                   
                    Console.WriteLine($"{terroristTeam[i]._name} has been killed by the counter terrorists.");
                }                                                                                            
            }                                                                                                
        }                                                                                                    
        else                                                                                                 
        {                                                                                                    
            Console.WriteLine("No terrorists could be killed by the counter terrorists in this round.");      
        }                                                                                                    
                                                                                                     
        return terroristTeam;                                                                         
    }
}