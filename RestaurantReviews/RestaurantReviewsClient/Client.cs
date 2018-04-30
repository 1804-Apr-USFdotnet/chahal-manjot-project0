using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewsLibrary;
using RestaurantReviewsLibrary.Models;

namespace RestaurantReviewsClient
{
    class Client
    {
        static void Main(string[] args)
        {
            ReadInput("");
            Console.Read();
        }

        public static void ReadInput(string response)
        {
            ClientHelper helper = new ClientHelper();

            while (response != "stop")
            {
                Console.WriteLine("\nChoose an option below or quit application with 'stop'");
                Console.WriteLine("Show all restaurants sorted by name (1)");
                Console.WriteLine("Show all restaurants sorted by rating (2)");
                Console.WriteLine("Show details of a restaurant (3)");
                Console.WriteLine("Show reviews of a restaurant (4)");
                Console.WriteLine("Show top 3 restaurants (5)");
                Console.WriteLine("Search (6)");
                Console.WriteLine("Add a restaurant (7)");
                Console.WriteLine("Update a restaurant (8)");
                Console.WriteLine("Remove a restaurant (9)");
                Console.WriteLine("Add a review (10)");
                Console.WriteLine("Remove a review (11)");

                response = Console.ReadLine();
                Execute(response, helper);
            }
            Environment.Exit(1);
        }

        private static void Execute(string response, ClientHelper helper)
        {
            switch (response)
            {
                case "1":
                    Console.WriteLine();
                    helper.GetRestaurantsByName();
                    break;
                case "2":
                    Console.WriteLine();
                    helper.GetRestaurantsByRating();
                    break;
                case "3":
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the restaurant you would like details for:");
                    string name = Console.ReadLine();
                    helper.GetDetails(name);
                    break;
                case "4":
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the restaurant you would like reviews for:");
                    string namerev = Console.ReadLine();
                    helper.GetReviews(namerev);
                    break;
                case "5":
                    Console.WriteLine();
                    helper.GetTop3();
                    break;
                case "6":
                    Console.WriteLine();
                    Console.WriteLine("Enter the phrase you would like to search for:");
                    string search = Console.ReadLine();
                    helper.Search(search);
                    break;
                case "7":
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the restaurant you would like to add:");
                    string restname = Console.ReadLine();
                    Console.WriteLine("Enter restaurant address:");
                    string restaddress = Console.ReadLine();
                    Console.WriteLine("Enter restaurant phone:");
                    string restphone = Console.ReadLine();
                    helper.AddRestaurant(restname,restaddress,restphone);
                    break;
                case "8":
                    Console.WriteLine();
                    Console.WriteLine("Enter the current restaurant name:");
                    string restnameup = Console.ReadLine();
                    Console.WriteLine("Enter new restaurant name:");
                    string restnamenew = Console.ReadLine();
                    helper.UpdateRestaurant(restnameup, restnamenew);
                    break;
                case "9":
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of restaurant you would like to remove:");
                    string restdel = Console.ReadLine();
                    helper.RemoveRestaurant(restdel);
                    break;
                case "10":
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the restaurant you would like to add a review for:");
                    string restnamerev = Console.ReadLine();
                    Console.WriteLine("Enter rating:");
                    int rating = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter comment:");
                    string comment = Console.ReadLine();
                    Console.WriteLine("Enter your username:");
                    string uname = Console.ReadLine();
                    helper.AddReview(restnamerev,rating,comment,uname);
                    break;
                case "11":
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the restaurant you would like to remove a review for:");
                    string restnamerevdel = Console.ReadLine();
                    Console.WriteLine("Enter your username:");
                    string unamedel = Console.ReadLine();
                    Console.WriteLine("Enter rating given:");
                    int ratingdel = Convert.ToInt32(Console.ReadLine());
                    helper.RemoveReview(restnamerevdel,unamedel,ratingdel);
                    break;
                case "stop":
                    ReadInput(response);
                    break;
                default:
                    Console.WriteLine("Unrecognized input. Enter a valid option\n");
                    ReadInput(response);
                    break;
            }
        }
    }
}
