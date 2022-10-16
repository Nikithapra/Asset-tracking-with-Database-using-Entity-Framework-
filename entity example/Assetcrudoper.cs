using entity_example;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

public class Assetcrudoper
{
    ////creating list items for class Asset
    private List<Asset> items = new List<Asset>();

    //CURD OPREATIONS IN DATABASE AND DISPLAYING IN CONSOLE
    public void CurdOper()
    {
        Console.WriteLine("PERFORM CRUD OPERATIONS IN DATABASE");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Pick a option");
        Console.WriteLine("(1).Create Assets in Database");
        Console.WriteLine("(2).Read Assets from Database ");
        Console.WriteLine("(3).Update Assets");
        Console.WriteLine("(4).Delete Asset in Database");
      
        string s = Console.ReadLine();
        int input = int.Parse(s);

    //CREATING ASSETS AND ADDING TO DATABASE
      if (input == 1)
       {  
        while (true)
        {
            //creating object for class
            Asset item = new Asset();

            Console.Write("Enter  Asset Type: ");
            item.Ptype = Console.ReadLine();

            Console.Write("Enter Asset Brand: ");
            item.PBrand = Console.ReadLine();

            Console.Write("Enter Asset Model: ");
            item.PModel = Console.ReadLine();

            Console.WriteLine("Enter the Asset office:(India/Sweden/Germany/Norway) ");
            item.POffices = Console.ReadLine();

            Console.WriteLine("Enter Asset Price in USD: ");
            string pri = Console.ReadLine();
            bool isprice = int.TryParse(pri, out int val);
            if (isprice)
            {
                item.PPrice = val;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input!Enter valid number!");
                break;
            }

            //calculating local price based on Currency
            string PCurrency = null;
            float locPrice = 0;

            if (item.POffices == "India")
            {
                item.PCurrency = "RUPEE";
                item.locPrice = (float)(item.PPrice * 79.5);
            }

            if (item.POffices == "Germany" || item.POffices == "Spain")
            {
                item.PCurrency = "EUR";
                item.locPrice = (float)(item.PPrice * 1.003);
            }
            if (item.POffices == "Sweden")
            {
                item.PCurrency = "SEK";
                item.locPrice = (float)(item.PPrice * 10.68);
            }
            if (item.POffices == "Norway")
            {
                item.PCurrency = "NOK";
                item.locPrice = (float)(item.PPrice * 10.17);
            }

            Console.WriteLine("Enter Asset Purchase date(YYYY-MM-DD): ");
            string date = Console.ReadLine();
            DateTime dt = Convert.ToDateTime(date);//converting to dateformat
            item.PPurcdate = dt;

            //adding to list items
            items.Add(item);

            // Creating object for mydbcontext to refer table in database
            MyDBContext Context = new MyDBContext();

            //Adding Assets to Database
            Context.Assetnew1.Add(item);
            Context.SaveChanges();
            Console.WriteLine("ASSET CREATED AND ADDED TO DATABASE..!!CHECK THE DATABASE(Assetnew1)");

            Console.WriteLine("Do you want to  Add Another assets(y/exit)");
            string q = Console.ReadLine();
            if (q == "exit") { break; }
        }

        //sorting list by Producttype,Offices,purchasedate 
        List<Asset> sortitems = items.OrderBy(it => it.Ptype)
                                     .ThenBy(it => it.POffices)
                                     .ThenBy(it => it.PPurcdate)
                                     .ToList();

        //displaying list
        Console.WriteLine("-----------------------------------------------------------------------------------------");
        Console.WriteLine("ID".PadRight(9) + "Type".PadRight(9) + "Brand".PadRight(7) + "Model".PadRight(8) +
                "Office".PadRight(10) + "PDate".PadRight(13) + "Price($)".PadRight(10) +
                "Currency".PadRight(10) + "LocPrice tdy".PadRight(10));

        Console.WriteLine("------------------------------------------------------------------------------------------");

        foreach (Asset t in sortitems)
        {
            var purchasedate = t.PPurcdate;
            var todaydate = DateTime.Now;
            var diffdate = todaydate - purchasedate;

            //checking condition for 3 years
            if (diffdate.TotalDays >= 915 && diffdate.TotalDays <= 1005) //less than 6months
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (diffdate.TotalDays >= 1005 && diffdate.TotalDays <= 1095)
            {
                Console.ForegroundColor = ConsoleColor.Red;//less than 3 months
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine(t.Id.ToString().PadRight(10) + t.Ptype.PadRight(10) + t.PBrand.PadRight(7) +
                 t.PModel.PadRight(7) + t.POffices.PadRight(10) + t.PPurcdate.ToString("yyyy-MM-dd").PadRight(14) +
                 t.PPrice.ToString().PadRight(10) + t.PCurrency.PadRight(10) +
                 t.locPrice.ToString().PadRight(7));
        }
        Console.ResetColor();

    }


        if (input == 2)
        {
            // READ(Get) Data from Database Asset1-R
            Console.WriteLine("Reading Assets from Database");

            MyDBContext Context = new MyDBContext();

            //getting values from Database
            List<Asset> items = Context.Assetnew1.ToList();
            List<Asset> sortitems = items.OrderBy(it => it.Ptype)
                                     .ThenBy(it => it.POffices)
                                     .ThenBy(it => it.PPurcdate)
                                     .ToList();

            //displaying list
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("ID".PadRight(9) + "Type".PadRight(9) + "Brand".PadRight(9) + "Model".PadRight(8) +
                      "Office".PadRight(10) + "PDate".PadRight(13) + "Price($)".PadRight(10) +
                      "Currency".PadRight(10) + "LocPrice tdy".PadRight(10));

            Console.WriteLine("------------------------------------------------------------------------------------------");
            foreach (var t1 in sortitems)
            {
                var purchasedate = t1.PPurcdate;
                var todaydate = DateTime.Now;
                var diffdate = todaydate - purchasedate;

                //checking condition for 3 years
                if (diffdate.TotalDays >= 915 && diffdate.TotalDays <= 1005) //less than 6months
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if (diffdate.TotalDays >= 1005 && diffdate.TotalDays <= 1095)
                {
                    Console.ForegroundColor = ConsoleColor.Red;//less than 3 months
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(t1.Id.ToString().PadRight(10) + t1.Ptype.PadRight(10) + t1.PBrand.PadRight(10) +
                     t1.PModel.PadRight(7) + t1.POffices.PadRight(10) + t1.PPurcdate.ToString("yyyy-MM-dd").PadRight(14) +
                     t1.PPrice.ToString().PadRight(10) + t1.PCurrency.PadRight(10) +
                     t1.locPrice.ToString().PadRight(7));
            }
            Console.ResetColor();
        }


        if (input == 3)
        {
            ////Console.WriteLine("------------------------------------");
            //UPDATE data in Database -U
            //Console.WriteLine("------------------------------------");
            // Creating object for mydbcontext to refer table in database
            MyDBContext Context = new MyDBContext();

            Console.WriteLine("Enter ID you  want to Update");
            int i = int.Parse(Console.ReadLine());
            //updating record i in database
            var user = Context.Assetnew1.SingleOrDefault(x => x.Id == i);

            Console.Write("Enter Updated Asset Type: ");
            user.Ptype = Console.ReadLine();

            Console.Write("Enter updated Asset Brand: ");
            user.PBrand = Console.ReadLine();

            Console.Write("Enter updated Asset Model: ");
            user.PModel = Console.ReadLine();

            Console.WriteLine("Enter the  updated Asset office:(India/Sweden/Germany/Norway) ");
            user.POffices = Console.ReadLine();

            Console.WriteLine("Enter updated Asset Purchase date(YYYY-MM-DD): ");
            string date = Console.ReadLine();
            DateTime dt = Convert.ToDateTime(date);//converting to dateformat
            user.PPurcdate = dt;


            Console.WriteLine("Enter updated Asset Price in USD: ");
            string pri = Console.ReadLine();
            bool isprice = int.TryParse(pri, out int val);
            if (isprice)
            {
                user.PPrice = val;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input!Enter valid number!");
                
            }

            //calculating local price based on Currency
            string PCurrency = null;
            float locPrice = 0;

            if (user.POffices == "India")
            {
                user.PCurrency = "RUPEE";
                user.locPrice = (float)(user.PPrice * 79.5);
            }

            if (user.POffices == "Germany" || user.POffices == "Spain")
            {
                user.PCurrency = "EUR";
                user.locPrice = (float)(user.PPrice * 1.003);
            }
            if (user.POffices == "Sweden")
            {
                user.PCurrency = "SEK";
                user.locPrice = (float)(user.PPrice * 10.68);
            }
            if (user.POffices == "Norway")
            {
                user.PCurrency = "NOK";
                user.locPrice = (float)(user.PPrice * 10.17);
            }
            Context.SaveChanges();
            Console.WriteLine("Asset Updated in Database!Please check the Database Assetnew1");
        }
       
        if (input == 4)
        {
            ////Console.WriteLine("------------------------------------");
            ////DELETE Data in Database Asset1-D
            // Console.WriteLine("------------------------------------");
            MyDBContext Context = new MyDBContext();
            Console.WriteLine("Enter ID you  want to Remove");
            int i = int.Parse(Console.ReadLine());

            var users = Context.Assetnew1.SingleOrDefault(x => x.Id == i);
            Context.Assetnew1.Remove(users);
            Context.SaveChanges();
           Console.WriteLine("Asset with ID  is Removed from Database!Please Check DB Assetnew1");
        }
    }

    public void display()
    {

        // READ(Get) Data from Database Asset1-R
        Console.WriteLine("Reading Assets from Database");

        MyDBContext Context = new MyDBContext();

        //getting values from Database
        List<Asset> items = Context.Assetnew1.ToList();
        List<Asset> sortitems = items.OrderBy(it => it.Ptype)
                                 .ThenBy(it => it.POffices)
                                 .ThenBy(it => it.PPurcdate)
                                 .ToList();

       
           
        //displaying list
        Console.WriteLine("-----------------------------------------------------------------------------------------");
        Console.WriteLine("ID".PadRight(9) + "Type".PadRight(9) + "Brand".PadRight(9) + "Model".PadRight(8) +
                  "Office".PadRight(10) + "PDate".PadRight(13) + "Price($)".PadRight(10) +
                  "Currency".PadRight(10) + "LocPrice tdy".PadRight(10));

        Console.WriteLine("------------------------------------------------------------------------------------------");
        foreach (var t1 in sortitems)
        {
            var purchasedate = t1.PPurcdate;
            var todaydate = DateTime.Now;
            var diffdate = todaydate - purchasedate;
           
            //checking condition for 3 years
            if (diffdate.TotalDays >= 915 && diffdate.TotalDays <= 1005) //less than 6months
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
           
            else if (diffdate.TotalDays >= 1005 && diffdate.TotalDays <= 1095)
            {
                Console.ForegroundColor = ConsoleColor.Red;//less than 3 months
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine(t1.Id.ToString().PadRight(10) + t1.Ptype.PadRight(10) + t1.PBrand.PadRight(10) +
                 t1.PModel.PadRight(7) + t1.POffices.PadRight(10) + t1.PPurcdate.ToString("yyyy-MM-dd").PadRight(14) +
                 t1.PPrice.ToString().PadRight(10) + t1.PCurrency.PadRight(10) +
                 t1.locPrice.ToString().PadRight(7));
        }
        Console.ResetColor();

        Console.WriteLine("\n");
        Console.WriteLine("TOTAL ASSETS IN DB :" +items.Count);

    }

    public void assetreport()
    {
        Console.WriteLine("Choose an Option");
        Console.WriteLine("(1)Show all Assets\n" + "(2)Show only Computer Assets \n" + "(3) Show only Mobile Assets");      
        string option1 = Console.ReadLine();
        if (option1 == "1")
        {

            MyDBContext Context = new MyDBContext();
            //getting values from Database
            List<Asset> items = Context.Assetnew1.ToList();
            List<Asset> sortitems = items.OrderBy(it => it.Ptype)
                                .ThenBy(it => it.POffices)
                                .ThenBy(it => it.PPurcdate)
                                .ToList();


            
            //displaying list
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("ID".PadRight(9) + "Type".PadRight(9) + "Brand".PadRight(9) + "Model".PadRight(8) +
                      "Office".PadRight(10) + "PDate".PadRight(13) + "Price($)".PadRight(10) +
                      "Currency".PadRight(10) + "LocPrice tdy".PadRight(10));

            Console.WriteLine("------------------------------------------------------------------------------------------");
            foreach (var t1 in sortitems)
            {
                var purchasedate = t1.PPurcdate;
                var todaydate = DateTime.Now;
                var diffdate = todaydate - purchasedate;

                //checking condition for 3 years
                if (diffdate.TotalDays >= 915 && diffdate.TotalDays <= 1005) //less than 6months
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }

                else if (diffdate.TotalDays >= 1005 && diffdate.TotalDays <= 1095)
                {
                    Console.ForegroundColor = ConsoleColor.Red;//less than 3 months
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(t1.Id.ToString().PadRight(8) + t1.Ptype.PadRight(10) + t1.PBrand.PadRight(10) +
                     t1.PModel.PadRight(7) + t1.POffices.PadRight(10) + t1.PPurcdate.ToString("yyyy-MM-dd").PadRight(14) +
                     t1.PPrice.ToString().PadRight(10) + t1.PCurrency.PadRight(10) +
                     t1.locPrice.ToString().PadRight(7));
            }
            Console.ResetColor();

            Console.WriteLine("\n");
            Console.WriteLine("TOTAL NO.OF ASSETS ARE :" + items.Count);


        }


         if (option1 == "2")
         {

            MyDBContext Context = new MyDBContext();
            //getting values from Database
            List<Asset> items = Context.Assetnew1.ToList();
            Console.WriteLine("Display Computer Assets :");
       
            List<Asset> displaycomp = items.Where(Asset => Asset.Ptype.Equals("Computer")).ToList();


            //displaying list
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("ID".PadRight(9) + "Type".PadRight(9) + "Brand".PadRight(9) + "Model".PadRight(8) +
                      "Office".PadRight(10) + "PDate".PadRight(13) + "Price($)".PadRight(10) +
                      "Currency".PadRight(10) + "LocPrice tdy".PadRight(10));

            Console.WriteLine("------------------------------------------------------------------------------------------");

            foreach (Asset t1 in displaycomp)
            {
                Console.WriteLine(t1.Id.ToString().PadRight(8) + t1.Ptype.PadRight(10) + t1.PBrand.PadRight(10) +
                t1.PModel.PadRight(7) + t1.POffices.PadRight(10) + t1.PPurcdate.ToString("yyyy-MM-dd").PadRight(14) +
                t1.PPrice.ToString().PadRight(10) + t1.PCurrency.PadRight(10) + t1.locPrice.ToString().PadRight(7));
            }
            Console.ResetColor();

            Console.WriteLine("\n");
            Console.WriteLine("TOTAL NO.OF  COMPUTER ASSETS ARE :" + displaycomp.Count);
        }
         
        if (option1 == "3")
        {

            MyDBContext Context = new MyDBContext();
            //getting values from Database
            List<Asset> items = Context.Assetnew1.ToList();
            Console.WriteLine("Display Mobile Assets :");
            
            List<Asset> displaymob = items.Where(Asset => Asset.Ptype.Equals("Mobile")).ToList();

            Console.ForegroundColor = ConsoleColor.Magenta;
            //displaying list
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("ID".PadRight(9) + "Type".PadRight(9) + "Brand".PadRight(9) + "Model".PadRight(8) +
                      "Office".PadRight(10) + "PDate".PadRight(13) + "Price($)".PadRight(10) +
                      "Currency".PadRight(10) + "LocPrice tdy".PadRight(10));

            Console.WriteLine("------------------------------------------------------------------------------------------");

            foreach (Asset t1 in displaymob)
            {
                Console.WriteLine(t1.Id.ToString().PadRight(8) + t1.Ptype.PadRight(10) + t1.PBrand.PadRight(10) +
                t1.PModel.PadRight(7) + t1.POffices.PadRight(10) + t1.PPurcdate.ToString("yyyy-MM-dd").PadRight(14) +
                t1.PPrice.ToString().PadRight(10) + t1.PCurrency.PadRight(10) + t1.locPrice.ToString().PadRight(7));
            }
            Console.ResetColor();

            Console.WriteLine("\n");
            Console.WriteLine("TOTAL NO.OF  MOBILE ASSETS ARE :" + displaymob.Count);
        }

    }

}




































