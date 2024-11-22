namespace Exam_Kata_2;

public class win_loss_messages
{
    public static void WinCondition()
    {
        Console.WriteLine($"Goblin defeated. Congratulations! \n Press anything to play again? ");
    }

    public static void LoseCondition()
    {
        Console.WriteLine($"You lost! \n Press anything to play again? ");
       
    }
}