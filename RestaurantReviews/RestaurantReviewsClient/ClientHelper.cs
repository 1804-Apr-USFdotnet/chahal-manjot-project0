using RestaurantReviewsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewsClient
{
    public class ClientHelper
    {
        public LibraryHelper libHelper;

        public ClientHelper()
        {
            libHelper = new LibraryHelper();
        }

        public void GetRestaurantsByName()
        {
            var results = libHelper.GetRestaurantsAlphabetical();
            Console.WriteLine("Name                Rating");
            Console.WriteLine("--------------------------");
            foreach (var restuarant in results)
                Console.WriteLine(restuarant.Name + " ".PadLeft(20 - restuarant.Name.Length, ' ') + restuarant.AverageRating);
            Console.WriteLine();
        }
        public void GetRestaurantsByRating()
        {
            var results = libHelper.GetRestaurantsByRating();
            Console.WriteLine("Name                Rating");
            Console.WriteLine("--------------------------");
            foreach (var restuarant in results)
                Console.WriteLine(restuarant.Name + " ".PadLeft(20 - restuarant.Name.Length, ' ') + restuarant.AverageRating);
            Console.WriteLine();
        }
        public void GetDetails(string name)
        {
            var results = libHelper.GetDetails(name);
            if (results != null)
            {
                Console.WriteLine("Details:");
                Console.WriteLine(results.GetRestaurantInfo());
            }
            else
                Console.WriteLine("Restaurant not found");
            Console.WriteLine();
        }
        public void GetReviews(string name)
        {
            var results = libHelper.GetReviews(name);
            if (results != null)
            {
                Console.WriteLine($"Reviews of {name}:");
                foreach (var review in results)
                    Console.WriteLine(review.GetReview());
            }
            else
                Console.WriteLine("Restaurant not found");
            Console.WriteLine();
        }
        public void GetTop3()
        {
            var results = libHelper.GetTop3RestaurantsByRating();
            Console.WriteLine("Top 3 rated restaurants:");
            foreach (var restuarant in results)
                Console.WriteLine(restuarant.GetRestaurantInfo() + "\n");
        }
        public void Search(string search)
        {
            var results = libHelper.Search(search);
            Console.WriteLine($"Search results for \"{search}\":");
            foreach (var restuarant in results)
                Console.WriteLine(restuarant.GetRestaurantInfo());
            Console.WriteLine();
        }
        public void AddRestaurant(string name, string address, string phone)
        {
            libHelper.AddRestaurant(name, address, phone);
        }
        public void UpdateRestaurant(string name, string newName)
        {
            libHelper.UpdateRestaurant(name, newName);
        }
        public void RemoveRestaurant(string name)
        {
            libHelper.RemoveRestaurant(name);
        }
        public void AddReview(string name, int rating, string review, string user)
        {
            libHelper.AddReview(name, rating, review, user);
        }
        public void RemoveReview(string name, string user, int rating)
        {
            libHelper.RemoveReview(name, user, rating);
        }
    }
}
