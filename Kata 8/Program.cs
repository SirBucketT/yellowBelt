namespace Kata_8;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Player player = new Player();
        player.GainExperience(50);
        Console.WriteLine("pLAYER GAINED 60 EXP");
        player.GainExperience(60);
        
        
        if (player.Experience >= 100)
        {
            Console.WriteLine($"Congratulations! You leveled up to Level {player.Level}.");
        }
    }

    class Player
    {
        private int _level;
        private int _experience;
        private int Health;
        
        public int health { get; private set; }

        public int GainExperience(int exp)
        {
            _experience += exp;
            
            if (_experience >= 100)
            {
                LevelUp();
            }
            else
            {
                Console.WriteLine($"{_experience} experience points.");
            }

            return _experience;
        }

        private void LevelUp()
        {
            Level++;
            Experience = 0;
            Console.WriteLine($"Congratulations! You level {Level}.");
        }

        public int Level
        {
            get { return _level; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Level cannot be negative.");
                }
                
                _level = value;
            }
        }
        
        public int Experience
        {
            get { return _experience; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Exp cannot be negative.");
                }
                
                _experience = value;
            }
        }
    }
}