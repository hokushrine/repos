namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            var jack = new Human("Jack");
            var zar = new Human("Zar");

            jack.Attack(zar);
            zar.GetHealth();
        }
    }
}
