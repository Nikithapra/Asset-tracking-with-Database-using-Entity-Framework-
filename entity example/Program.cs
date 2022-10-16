
using entity_example;
public class Program
{
    private static void Main(string[] args)
    {
        //Mini Project -Asset Tracking
       
        //creating obj for class Assetcrud operations
        Assetcrudoper t = new Assetcrudoper();

        MyDBContext db = new MyDBContext();
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n");
            Console.WriteLine("Welcome to AssetTracking using Entity Framework and Database");
            Console.WriteLine("-------------------------------------------------------------");
            Console.ResetColor();

            Console.WriteLine("Pick an option");
            Console.WriteLine("(1) Perform CRUD operations in Database ");
            Console.WriteLine("(2) Display Total Assets in Database");
            Console.WriteLine("(3) Assets Report");
            Console.WriteLine("(4) Quit ");

            string s = Console.ReadLine();
            int option = int.Parse(s);

           
            if (option == 1)
            {
                t.CurdOper();
            }
            if (option == 2)
            {
                t.display();
            }
            if (option == 3)
            {
                t.assetreport();
            }
            if (option == 4)
            {
                break;
            }
        }
    }
}

