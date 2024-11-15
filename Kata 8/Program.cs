namespace Kata_8;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    class Player
    {
        private int Level;
        private int Experience;

        public int Health {get; private set;}

        public int Level
        {
            get { return Level; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Level cannot be negative.");
                    level = value;
                }
            }
        }
    }
}