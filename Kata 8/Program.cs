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
        private int Health;

        public int level
        {
            get { return Level; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Level cannot be negative.");
                }
                
                Level = value;
            }
        }
        
        public int experience
        {
            get { return Experience; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Exp cannot be negative.");
                }
                
                Experience = value;
            }
        }
    }
}