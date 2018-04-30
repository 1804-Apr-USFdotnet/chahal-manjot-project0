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
            var libHelper = new LibraryHelper();

            var results = libHelper.GetRestaurants();
            //Console.WriteLine("All restaurants:");
            //foreach (var restuarant in results)
            //    Console.WriteLine(restuarant.GetRestaurantInfo());
            //    Console.WriteLine(restuarant.Name);
            //Console.WriteLine();

            //var results2 = libHelper.GetReviews("Subway");
            //foreach (var review in results2)
            //    Console.WriteLine(review.GetReview());

            //libHelper.AddRestaurant("Chipotles", "2576 East Fowler Avenue", "123-456-1234");
            //libHelper.RemoveRestaurant("Chipotle");
            //libHelper.UpdateRestaurant("Chipotles", "Chipotle");

            results = libHelper.Search("in");
            Console.WriteLine("Search results for \"in\":");
            foreach (var restuarant in results)
                Console.WriteLine(restuarant.Name);
            Console.WriteLine();

            results = libHelper.GetRestaurantsAlphabetical();
            Console.WriteLine("Name                Rating");
            Console.WriteLine("--------------------------");
            foreach (var restuarant in results)
                Console.WriteLine(restuarant.Name + " ".PadLeft(20 - restuarant.Name.Length, ' ') + restuarant.AverageRating);
            Console.WriteLine();

            results = libHelper.GetRestaurantsByRating();
            Console.WriteLine("Name                Rating");
            Console.WriteLine("--------------------------");
            foreach (var restuarant in results)
                Console.WriteLine(restuarant.Name+" ".PadLeft(20-restuarant.Name.Length,' ')+restuarant.AverageRating);
            Console.WriteLine();

            results = libHelper.GetTop3RestaurantsByRating();
            Console.WriteLine("Top 3 rated restaurants:");
            foreach (var restuarant in results)
                Console.WriteLine(restuarant.GetRestaurantInfo()+"\n");
            Console.WriteLine();

            var results3 = libHelper.GetDetails("Chipotle");
            Console.WriteLine("Details:");
            Console.WriteLine(results3.GetRestaurantInfo());
            Console.WriteLine();

            //libHelper.AddReview("Chipotle", 2, "This place still sucks", "Gordon Ramsay");
            libHelper.RemoveReview("Chipotle", "Gordon Ramsey", 1);

            results3 = libHelper.GetDetails("Chipotle");
            Console.WriteLine("Details:");
            Console.WriteLine(results3.GetRestaurantInfo());
            Console.WriteLine();

            var results2 = libHelper.GetReviews("Chipotle");
            Console.WriteLine("Reviews:");
            foreach (var review in results2)
                Console.WriteLine(review.GetReview());
            Console.WriteLine();

            //results = libHelper.GetRestaurants();
            //foreach (var restuarant in results)
            //    Console.WriteLine(restuarant.Name);

            Console.Read();
        }
    }
}
