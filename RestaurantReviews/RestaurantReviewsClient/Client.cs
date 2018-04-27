using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewsLibrary;

namespace RestaurantReviewsClient
{
    class Client
    {
        static void Main(string[] args)
        {
            ////////////////////////////////////////////////////////////////////////
            //Deserialization of JSON data

            RestaurantCollection myCollection2 = new RestaurantCollection();

            myCollection2.DeserializeRestaurantData();
            myCollection2.DeserializeReviewData();

            myCollection2.GetRestaurants();

            myCollection2.GetReviews("Subway");
            myCollection2.GetReviews("Wingstop");
            myCollection2.GetReviews("Qdoba");

            myCollection2.Search("Wingstop");
            myCollection2.Search("in");

            Console.Read();
        }
    }
}
