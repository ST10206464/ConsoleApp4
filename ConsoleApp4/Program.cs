using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        //declaring the global variables
        
        static int[] Steps = new int[3];
        // static String[] unitm = new String[3];

        static Ingredient objingre = new Ingredient();
        
        static Steps objsteps = new Steps();

        static Ingredient[] aringre;
        static Steps[] arsteps;
        static void Main(string[] args)
        {

            // prompt the user to enter the number of ingredients
            Console.WriteLine("Please enter the number of ingredients");
            int ing = Convert.ToInt32(Console.ReadLine());

            aringre = new Ingredient[ing];


            //ingredients details
            for (int i = 0; i < ing; i++)
            {
              

                Console.WriteLine("Enter the name of ingredient :"+(i+1));
                objingre.IngName= Console.ReadLine();
                Console.WriteLine("Enter the quantity of the ingredient"+" ");
                objingre.Quantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the unit of measurement of"+" " );
                objingre.UnitM = Console.ReadLine();

                aringre[i] = objingre;
            }


            // prompt the user to enter number of steps
            Console.WriteLine("\n");
            Console.WriteLine("Please enter the number of steps");
            int stp = Convert.ToInt32(Console.ReadLine());

            arsteps= new Steps[stp];

            //steps details
            for (int k = 0; k < arsteps.Length;k++)
            {

                Console.WriteLine("Enter the description" +(k+1));
                objsteps.Description = Console.ReadLine();
                arsteps[k] =  objsteps;

            }
            // output of the ingredient
            Console.WriteLine("\n");
            for (int p = 0; p < aringre.Length; p++)
            {
                Console.WriteLine("******INGREDIENTS user output******* \n" +
                    "The ingredient name is :" + aringre[p].IngName + "\n" +
                    "The quantity is :" + aringre[p].Quantity + "\n" +
                    "The unit of measurement is :" + aringre[p].UnitM);
                    
            }
            Console.WriteLine("\n");
            for (int j = 0; j < arsteps.Length; j++)
            {
                Console.WriteLine("********STEPS user output************\n" +
                    "The description is : " + arsteps[j].Description);
            }

            Console.WriteLine("\n");

            Console.WriteLine("choose from the following \n" +
                "1.Factor of 0,5(half)"+"\n" +
                "2.Factor of 2(double)"+"\n" +
                "3.Factor of 3(trible)");
            int scale = Convert.ToInt32(Console.ReadLine());

            for (int p = 0; p < aringre.Length; p++)
            {

                if (scale == 1)
                {
                    Console.WriteLine(objingre.Quantity * 0.5);
                    Console.WriteLine("Do you want scale your quantity? : yes/no");
                    string yesNo = Console.ReadLine();
                    if (yesNo == "yes")
                    {
                        Console.WriteLine("Enter the quantity you want change");
                        int qu =Convert.ToInt32(Console.ReadLine());

                        
                       Console.WriteLine("Enter a new quantity");
                        int q = Convert.ToInt32(Console.ReadLine());
                        

                        Console.WriteLine("********New Details" + "\n" +
                            "The ingredient name is :" + aringre[p].IngName +"\n" +
                            "The quantity :"+aringre[p].Quantity + "\n" +
                            "The unit of the measurement is :" + aringre[p].UnitM);
                    }
                    else if (yesNo == "no")
                    {
                        Console.WriteLine();
                    }
                }
                else if (scale == 2)
                {
                    Console.WriteLine(objingre.Quantity * 2);
                    Console.WriteLine();
                }
                else if (scale == 3)
                {
                    Console.WriteLine(objingre.Quantity * 3);
                    Console.WriteLine();

                }
            }

            


            Console.ReadKey();
        }
    }
}
 