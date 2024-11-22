namespace Exam_Kata_2;

public class RandomEncounter
{
    public bool EncounterGenerator()
    {
        bool isAlive = true;
        Random random = new Random(); 
        int EncounterNumber = random.Next(0, 3);
            
        if (EncounterNumber == 0) 
        { 
            Combat.Initialise(); 
        }

        else if (EncounterNumber == 1)
        {
            Merchant.Shop();
            isAlive = true;
        }

        else if (EncounterNumber == 2)
        {
            Events.Villager();
            isAlive = true;
        }
        return isAlive;
    }
}