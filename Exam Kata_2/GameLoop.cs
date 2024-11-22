namespace Exam_Kata_2;

public class GameLoop
{
    public static void GameRunner()
    {
        bool isAlive = true; 
        while (isAlive) 
        { 
            RandomEncounter randomEncounter = new();
            isAlive = randomEncounter.EncounterGenerator(); 
        }
    } 
}