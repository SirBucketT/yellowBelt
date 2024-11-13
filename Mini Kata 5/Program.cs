using System.Dynamic;
using System.Globalization;

namespace ConsoleApp2;

class Program
{
    // public class Attack
    // {
    //     public int Damage;
    //
    //     public Attack(int damage)
    //     {
    //         Damage = damage;
    //     }
    //
    // }

    // public void Heal()
    // {
    //     public int healAmount;
    //
    //     Console.WriteLine($"Player dealt damage!");
    //     
    // }
   
     static void Main(string[] args)
     {
        // Attack attack = new Attack(damage:15);
        // Heal heal = new Heal(healAmountx:10);
        
        Attack();
        Heal();

        //Console.WriteLine($"Player dealt {attack.Damage} damage!");
        //Console.WriteLine($"Player healed {heal.healAmount} health points!");

     }
     
     static void Heal()
     {
         int healAmount = 10;
         Console.WriteLine($"Player healed {healAmount} health points!");
     }
     static void Attack()
     {
         int damage = 15;
         Console.WriteLine($"Player healed {damage} health points!");
     }
}