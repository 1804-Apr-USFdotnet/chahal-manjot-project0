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
            Console.WriteLine("All restaurants:");
            foreach (var restuarant in results)
                //Console.WriteLine(restuarant.GetRestaurantInfo());
                Console.WriteLine(restuarant.Name);
            Console.WriteLine();

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
            Console.WriteLine("All restaurants sorted by name:");
            foreach (var restuarant in results)
                Console.WriteLine(restuarant.Name);

            //results = libHelper.GetRestaurants();
            //foreach (var restuarant in results)
            //    Console.WriteLine(restuarant.Name);

            Console.Read();
        }
    }
}
