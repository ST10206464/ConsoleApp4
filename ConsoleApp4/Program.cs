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
        static List<string> ListofNameRecipe = new List<string>();
        static List<string> ListofNameIngredient = new List<string>();
        static List<double> ListQuantity = new List<double>();
        static List<string> ListUnitMeasurement = new List<string>();
        static List<double> ListCalories = new List<double>();
        static List<int> ListFoodGroup = new List<int>();
        static List<int> Listofsteps = new List<int>();
        static List<string> ListDescription = new List<string>();
        static List<double> ListofScaleQuantityyy = new List<double>();
        static List <string> FoodDescRIPTION= new List<string>();

        delegate bool CheckNum(double num);

        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Enter the number of recipes:");
                int numofRecipe = Convert.ToInt32(Console.ReadLine());

                for (int t = 0; t < numofRecipe; t++)
                {
                    Console.WriteLine("Enter the recipe name #" + (t + 1));
                    string nameRecipe = Console.ReadLine();
                    ListofNameRecipe.Add(nameRecipe);

                    Console.WriteLine("Enter the number of ingredients for this recipe:");
                    int numofIngredients = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < numofIngredients; i++)
                    {
                        Console.WriteLine("Enter the name of ingredient #" + (i + 1));
                        string ingName = Console.ReadLine();
                        ListofNameIngredient.Add(ingName);

                        Console.WriteLine("Enter the quantity of ingredient #" + (i + 1));
                        double quantity = Convert.ToDouble(Console.ReadLine());
                        ListQuantity.Add(quantity);

                        Console.WriteLine("Enter the unit measurement of ingredient #" + (i + 1));
                        string unitM = Console.ReadLine();
                        ListUnitMeasurement.Add(unitM);

                        Console.WriteLine("Choose the food group for ingredient #" + (i + 1) +
                            "\n1. Fruit and Vegetables" +
                            "\n2. Starchy food" +
                            "\n3. Dairy" +
                            "\n4. Protein" +
                            "\n5. Fat");
                        int foodGroup = Convert.ToInt32(Console.ReadLine());
                        ListFoodGroup.Add(foodGroup);

                        Console.WriteLine("Enter the number of calories for ingredient #" + (i + 1));
                        double calories = Convert.ToDouble(Console.ReadLine());
                        ListCalories.Add(calories);
                    }

                    Console.WriteLine("Enter the number of steps for this recipe:");
                    int numofSteps = Convert.ToInt32(Console.ReadLine());

                    for (int k = 0; k < numofSteps; k++)
                    {
                        Console.WriteLine("Enter the description for step #" + (k + 1));
                        string description = Console.ReadLine();
                        ListDescription.Add(description);
                    }

                    double totalCalories = CalculateTotalCalories(ListCalories);
                    if (totalCalories > 300)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Warning: Total calories for recipe \"" + nameRecipe + "\" exceed 300.");
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine("==== Recipe Information ====");
                for (int j = 0; j < ListofNameRecipe.Count; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("******** Recipe ********");
                    Console.WriteLine("Name: " + ListofNameRecipe[j]);

                    Console.WriteLine("****** Ingredients ******");
                    for (int i = 0; i < numofRecipe; i++)
                    {
                        int ingredientIndex = j * numofRecipe + i;
                        Console.WriteLine("Ingredient #" + (i + 1));
                        Console.WriteLine("Name: " + ListofNameIngredient[ingredientIndex]);
                        Console.WriteLine("Quantity: " + ListQuantity[ingredientIndex]);
                        Console.WriteLine("Unit Measurement: " + ListUnitMeasurement[ingredientIndex]);
                        Console.WriteLine("Calories: " + ListCalories[ingredientIndex]);
                        Console.WriteLine("Food Group: " + GetFoodGroupName(ListFoodGroup[ingredientIndex]));
                    }

                    Console.WriteLine("******* Preparation *******");
                    for (int k = 0; k < numofRecipe; k++)
                    {
                        int stepIndex = j * numofRecipe + k;
                        Console.WriteLine("Step #" + (k + 1));
                        Console.WriteLine(ListDescription[stepIndex]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                Console.ResetColor();
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

        static string GetFoodGroupName(int foodGroup)
        {
            switch (foodGroup)
            {
                case 1:
                    return "Fruit and Vegetables";
                case 2:
                    return "Starchy food";
                case 3:
                    return "Dairy";
                case 4:
                    return "Protein";
                case 5:
                    return "Fat";
                default:
                    return "Unknown";
            }
        }

        static double CalculateTotalCalories(List<double> calories)
        {
            double total = 0;
            foreach (double cal in calories)
            {
                total += cal;
            }
            return total;
        }
    }
}
