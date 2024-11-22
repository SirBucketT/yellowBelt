namespace Exam_Kata_2;

class Merchant
{
    public string Name {get; private set;}
    public string Dialogue {get; set;}

    public Merchant(string name)
    {
        Name = name;
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: Welcome to our village");
    }
}