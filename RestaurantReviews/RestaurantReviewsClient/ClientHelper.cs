using RestaurantReviewsLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewsClient
{
    public class ClientHelper
    {
        //public LibraryHelper repo;
        public RestaurantRepository repo;

        public ClientHelper()
        {
            //repo = new LibraryHelper();
            repo = new RestaurantRepository();
        }

        public void GetRestaurantsByName()
        {
            var results = repo.GetRestaurantsAlphabetical();
            Console.WriteLine("Name                Rating");
            Console.WriteLine("--------------------------");
            foreach (var restuarant in results)
                Console.WriteLine(restuarant.Name + " ".PadLeft(20 - restuarant.Name.Length, ' ') + restuarant.AverageRating.ToString("0.##"));
            Console.WriteLine();
        }
        public void GetRestaurantsByRating()
        {
            var results = repo.GetRestaurantsByRating();
            Console.WriteLine("Name                Rating");
            Console.WriteLine("--------------------------");
            foreach (var restuarant in results)
                Console.WriteLine(restuarant.Name + " ".PadLeft(20 - restuarant.Name.Length, ' ') + restuarant.AverageRating.ToString("0.##"));
            Console.WriteLine();
        }
        public void GetDetails(string name)
        {
            var results = repo.GetDetails(name);
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
            var results = repo.GetReviews(name);
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
            var results = repo.GetTop3RestaurantsByRating();
            Console.WriteLine("Top 3 rated restaurants:");
            foreach (var restuarant in results)
                Console.WriteLine(restuarant.GetRestaurantInfo() + "\n");
        }
        public void Search(string search)
        {
            var results = repo.Search(search);
            Console.WriteLine($"Search results for \"{search}\":");
            foreach (var restuarant in results)
                Console.WriteLine(restuarant.GetRestaurantInfo());
            Console.WriteLine();
        }
        public void AddRestaurant(string name, string address, string phone)
        {
            repo.AddRestaurant(name, address, phone);
        }
        public void UpdateRestaurant(string name, string newName)
        {
            repo.UpdateRestaurant(name, newName);
        }
        public void RemoveRestaurant(string name)
        {
            repo.RemoveRestaurant(name);
        }
        public void AddReview(string name, int rating, string review, string user)
        {
            repo.AddReview(name, rating, review, user);
        }
        public void RemoveReview(string name, string user, int rating)
        {
            repo.RemoveReview(name, user, rating);
        }
    }
}
