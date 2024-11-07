namespace TemplateMethodDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coffee coffee = new Coffee();
            Salad salad = new Salad();
            Shawarma shawarma = new Shawarma();

            coffee.OrderDish();

            Console.WriteLine();

            salad.OrderDish();

            Console.WriteLine();

            shawarma.OrderDish();

        }
    }
}
