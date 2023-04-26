using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        //declaring the global variables

       // static int[] Steps = new int[3];
        // static String[] unitm = new String[3];

        static Ingredient objingre = new Ingredient();

        static Steps objsteps = new Steps();

        static Ingredient[] arrIngredient;
        static Steps[] arsteps;

        static string[] arrIngredientName;
        static double[] arrQuantiyy;
        static string[] arrUnitM;
        static string[] arrDescription;
        static void Main(string[] args)
        {

            // prompt the user to enter the number of ingredients
            Console.WriteLine("Please enter the number of ingredients");
            int numofing = Convert.ToInt32(Console.ReadLine());
            arrIngredient = new Ingredient[numofing];


            //ingredients details
            arrIngredientName = new string[numofing];
            arrQuantiyy = new double[numofing];
            arrUnitM = new string[numofing];

            for (int i = 0; i < numofing; i++)
            {


                Console.WriteLine("Enter the name of ingredient :" + (i + 1));
                string IngName = Console.ReadLine();
                Console.WriteLine("Enter the quantity of the ingredient" + " ");
                double Quantity = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the unit of measurement of" + " ");
                string UnitM = Console.ReadLine();


                objingre.IngName = IngName;
                objingre.Quantity = Quantity;
                objingre.UnitM = UnitM;


                arrIngredientName[i] = objingre.IngName;
                arrQuantiyy[i] = objingre.Quantity;
                arrUnitM[i] = objingre.UnitM;
                Console.WriteLine(arrIngredientName[i] + ":" + "Sucessfully saved!");
            }


            // prompt the user to enter number of steps
            Console.WriteLine("\n");
            Console.WriteLine("Please enter the number of steps");
            objsteps.NumOfsteps = Convert.ToInt32(Console.ReadLine());

            arsteps = new Steps[objsteps.NumOfsteps];
            arrDescription = new string[objsteps.NumOfsteps];
            //steps details
            for (int k = 0; k < arsteps.Length; k++)
            {

                Console.WriteLine("Enter the description" + (k + 1));
                string Description = Console.ReadLine();
                objsteps.Description = Description;

                arrDescription[k] = objsteps.Description;

            }
            // output of the ingredient
            Console.WriteLine("\n");
            for (int p = 0; p < arrIngredient.Length; p++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("******INGREDIENTS user output******* \n" +
                    "The ingredient name is :" + arrIngredientName[p] + "\n" +
                    "The quantity is :" + arrQuantiyy[p] + "\n" +
                    "The unit of measurement is :" + arrUnitM[p]);

            }
            //output of the steps
            Console.WriteLine("\n");
            for (int j = 0; j < arrDescription.Length; j++)
            {
                Console.WriteLine("********STEPS user output************\n" +
                    "The description is : " + arrDescription[j]);

            }
            Console.ResetColor();
            //reset
            Console.WriteLine("\n");

            Menu();
        }
        public static void Menu()
        {
            int myMenu = 0;
            while (myMenu != 3)
            {
                Console.WriteLine("MY MENU" +
                    "\n1. Scale and Reset" +
                    "\n2. Clear" +
                    "\n3. Exit or Add new Recipe");

                myMenu = Convert.ToInt32(Console.ReadLine());

                if (myMenu == 1)
                {
                    Console.WriteLine("Choose from scale " +
                        "\n1 Scale by Factor 0.5(half)" +
                        "\n2. Scale by Factor 2 (double) " +
                        "\n3. Scale by factor 3 (tripple)");
                    int ScaleOptions = Convert.ToInt32(Console.ReadLine());
                    if (ScaleOptions == 1)
                    {
                        for (int i = 0; i < arrIngredient.Length; i++)
                        {
                            objingre.ScaleQuantityyy = arrQuantiyy[i] * 0.5;
                            Console.WriteLine(arrIngredientName[i] + " :" + arrQuantiyy[i] + ":" + " Scaled to " + objingre.ScaleQuantityyy);
                        }

                    }
                    else if (ScaleOptions == 2)
                    {
                        for (int i = 0; i < arrIngredient.Length; i++)
                        {
                            objingre.ScaleQuantityyy = arrQuantiyy[i] * 2;
                            Console.WriteLine(arrIngredientName[i] + " :" + arrQuantiyy[i] + ":" + " Scaled to " + objingre.ScaleQuantityyy);
                        }

                    }
                    else if (ScaleOptions == 3)
                    {
                        for (int i = 0; i < arrIngredient.Length; i++)
                        {
                            objingre.ScaleQuantityyy = arrQuantiyy[i] * 3;
                            Console.WriteLine(arrIngredientName[i] + " :" + arrQuantiyy[i] + ":" + " Scaled to " + objingre.ScaleQuantityyy);
                        }

                    }
                    else { }

                    Console.WriteLine("do you want to reset : yes/no");
                    string reset = Console.ReadLine();
                    if (reset == "yes" || reset == "Yes")
                    {
                        Console.WriteLine("enter the last quantity you entered");
                        double lastScaleQUnatity = Convert.ToDouble(Console.ReadLine());

                        for (int p = 0; p < arrIngredient.Length; p++)
                        {
                            if (lastScaleQUnatity == objingre.ScaleQuantityyy)
                            {
                                Console.WriteLine("The original quantity are: ");
                                Console.WriteLine("Ingredient Name : " + arrIngredientName[p] + "\n" + "Original Quantity :" + arrQuantiyy[p]);
                            }
                            else if (lastScaleQUnatity != objingre.ScaleQuantityyy)
                            {
                                Console.WriteLine("scale quantity could not br found .Make sure to enter last Scale Quantity");
                            }

                        }
                    }
                    else if (reset == "no" || reset == "No")
                    {
                        for (int p = 0; p < arrIngredient.Length; p++)
                        {
                            Console.WriteLine("Scaled Quantity");
                            Console.WriteLine("Ingredient Name : " + arrIngredientName[p] + "\n" + "Scaled Quantity :" + objingre.ScaleQuantityyy);

                        }
                    }
                }
                else if (myMenu == 2)
                {
                    Console.WriteLine("Do you to clear :yes/no");
                    string clear = Console.ReadLine();

                    if (clear == "yes" || clear == "Yes")
                    {
                        for (int k = 0; k < arrIngredient.Length; k++)
                        {
                            for (int j = 0; j < arsteps.Length; j++)
                            {
                                //methods to clear my data

                                Array.Clear(arrIngredientName, 0, arrIngredientName.Length);
                                Array.Clear(arrQuantiyy, 0, arrQuantiyy.Length);
                                Array.Clear(arrUnitM, 0, arrUnitM.Length);

                                Array.Clear(arrDescription, 0, arrDescription.Length);
                                Console.Clear();
                                Console.WriteLine("Data Deleted!!");
                                Console.WriteLine("ingredient Name : " +arrIngredientName[k]+ "\n");
                                Console.WriteLine("Quntity :" + arrQuantiyy[k]+ "\n");
                                Console.WriteLine("Unit Measurement : " + arrUnitM[k] + "\n");
                                Console.WriteLine("Description : " + arrDescription[j] + "\n");

                            }

                        }
                    }

                }
                else if (myMenu == 3) {

                    Console.WriteLine("Press 1 to addNewRecipe Or Press 2 to Exit");
                    int exit =Convert.ToInt32(Console.ReadLine());


                    if(exit == 1) {
                        for (int k = 0; k < arrIngredient.Length; k++)
                        {
                            for (int j = 0; j < arsteps.Length; j++)
                            {
                                //methods to clear my data

                                Array.Clear(arrIngredientName, 0, arrIngredientName.Length);
                                Array.Clear(arrQuantiyy, 0, arrQuantiyy.Length);
                                Array.Clear(arrUnitM, 0, arrUnitM.Length);

                                Array.Clear(arrDescription, 0, arrDescription.Length);
                                Console.Clear();


                            }

                        }
                        ///this will be for adding new Recipe
                        // prompt the user to enter the number of ingredients
                        Console.WriteLine("Please enter the number of ingredients");
                        int numofing = Convert.ToInt32(Console.ReadLine());
                        arrIngredient = new Ingredient[numofing];


                        //ingredients details
                        arrIngredientName = new string[numofing];
                        arrQuantiyy = new double[numofing];
                        arrUnitM = new string[numofing];

                        for (int i = 0; i < numofing; i++)
                        {


                            Console.WriteLine("Enter the name of ingredient :" + (i + 1));
                            string IngName = Console.ReadLine();
                            Console.WriteLine("Enter the quantity of the ingredient" + " ");
                            double Quantity = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter the unit of measurement of" + " ");
                            string UnitM = Console.ReadLine();


                            objingre.IngName = IngName;
                            objingre.Quantity = Quantity;
                            objingre.UnitM = UnitM;


                            arrIngredientName[i] = objingre.IngName;
                            arrQuantiyy[i] = objingre.Quantity;
                            arrUnitM[i] = objingre.UnitM;
                            Console.WriteLine(arrIngredientName[i] + ":" + "Sucessfully saved!");
                        }


                        // prompt the user to enter number of steps
                        Console.WriteLine("\n");
                        Console.WriteLine("Please enter the number of steps");
                        objsteps.NumOfsteps = Convert.ToInt32(Console.ReadLine());

                        arsteps = new Steps[objsteps.NumOfsteps];
                        arrDescription = new string[objsteps.NumOfsteps];
                        //steps details
                        for (int k = 0; k < arsteps.Length; k++)
                        {

                            Console.WriteLine("Enter the description" + (k + 1));
                            string Description = Console.ReadLine();
                            objsteps.Description = Description;

                            arrDescription[k] = objsteps.Description;

                        }
                        // output of the ingredient
                        Console.WriteLine("\n");
                        for (int p = 0; p < arrIngredient.Length; p++)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("******INGREDIENTS user output******* \n" +
                                "The ingredient name is :" + arrIngredientName[p] + "\n" +
                                "The quantity is :" + arrQuantiyy[p] + "\n" +
                                "The unit of measurement is :" + arrUnitM[p]);

                        }
                        //output of the steps
                        Console.WriteLine("\n");
                        for (int j = 0; j < arrDescription.Length; j++)
                        {
                            Console.WriteLine("********STEPS user output************\n" +
                                "The description is : " + arrDescription[j]);

                        }
                        Console.ResetColor();
                        Program.Menu();

                    } 
                }

            }//closing my while loop 

        }//closing my Menu
    }
}
 