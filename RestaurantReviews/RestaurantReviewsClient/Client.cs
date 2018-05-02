using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewsLibrary;
using NLog;

namespace RestaurantReviewsClient
{
    class Client
    {
        public static Logger logger;

        static void Main(string[] args)
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
            ReadInput("", logger);
            Console.Read();
        }

        public static void ReadInput(string response, Logger logger)
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
                logger.Info(response);
                Execute(response, helper, logger);
            }
            Environment.Exit(1);
        }

        private static void Execute(string response, ClientHelper helper, Logger logger)
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
                    logger.Info(name);
                    helper.GetDetails(name);
                    break;
                case "4":
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the restaurant you would like reviews for:");
                    string namerev = Console.ReadLine();
                    logger.Info(namerev);
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
                    logger.Info(search);
                    helper.Search(search);
                    break;
                case "7":
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the restaurant you would like to add:");
                    string restname = Console.ReadLine();
                    logger.Info(restname);
                    Console.WriteLine("Enter restaurant address:");
                    string restaddress = Console.ReadLine();
                    logger.Info(restaddress);
                    Console.WriteLine("Enter restaurant phone:");
                    string restphone = Console.ReadLine();
                    logger.Info(restphone);
                    helper.AddRestaurant(restname,restaddress,restphone);
                    break;
                case "8":
                    Console.WriteLine();
                    Console.WriteLine("Enter the current restaurant name:");
                    string restnameup = Console.ReadLine();
                    logger.Info(restnameup);
                    Console.WriteLine("Enter new restaurant name:");
                    string restnamenew = Console.ReadLine();
                    logger.Info(restnamenew);
                    helper.UpdateRestaurant(restnameup, restnamenew);
                    break;
                case "9":
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of restaurant you would like to remove:");
                    string restdel = Console.ReadLine();
                    logger.Info(restdel);
                    helper.RemoveRestaurant(restdel);
                    break;
                case "10":
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the restaurant you would like to add a review for:");
                    string restnamerev = Console.ReadLine();
                    logger.Info(restnamerev);
                    Console.WriteLine("Enter rating:");
                    int rating = Convert.ToInt32(Console.ReadLine());
                    logger.Info(rating);
                    Console.WriteLine("Enter comment:");
                    string comment = Console.ReadLine();
                    logger.Info(comment);
                    Console.WriteLine("Enter your username:");
                    string uname = Console.ReadLine();
                    logger.Info(uname);
                    helper.AddReview(restnamerev,rating,comment,uname);
                    break;
                case "11":
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the restaurant you would like to remove a review for:");
                    string restnamerevdel = Console.ReadLine();
                    logger.Info(restnamerevdel);
                    Console.WriteLine("Enter your username:");
                    string unamedel = Console.ReadLine();
                    logger.Info(unamedel);
                    Console.WriteLine("Enter rating given:");
                    int ratingdel = Convert.ToInt32(Console.ReadLine());
                    logger.Info(ratingdel);
                    helper.RemoveReview(restnamerevdel,unamedel,ratingdel);
                    break;
                case "stop":
                    ReadInput(response, logger);
                    break;
                default:
                    Console.WriteLine("Unrecognized input. Enter a valid option\n");
                    ReadInput(response, logger);
                    break;
            }
        }
    }
}
