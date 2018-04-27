using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewsLibrary
{
    public class RestaurantCollection
    {
        List<Restaurant> list;

        public RestaurantCollection()
        {
            list = new List<Restaurant>();
        }

        public void DeserializeRestaurantData()
        {
            list = DeserializeRestaurants.Deserialize();
        }

        public void DeserializeReviewData()
        {
            List<Review> revlist = DeserializeReviews.Deserialize();

            foreach (Review abc in revlist)
            {
                list[abc.Restaurantid - 1].PopulateReviews(abc);
            }
        }

        //public void addReview(String restaurantName, String reviewer, String review, int rating, String date)
        //{
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i].getName() == restaurantName)
        //        {
        //            list[i].addReview(reviewer, review, rating, date);
        //            break;
        //        }
        //    }
        //}

        public void GetRestaurants()
        {
            Console.WriteLine("All restaurants:");
            foreach (Restaurant r in list)
            {
                Console.WriteLine(r.GetRestaurantInfo() + "\n");
            }
        }

        public void GetReviews(String restaurantName)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == restaurantName)
                {
                    Console.WriteLine("Reviews for " + restaurantName + ":\n" + list[i].GetReviews());
                    break;
                }
            }
        }

        public void Search(String query)
        {
            Console.WriteLine("Restaurants containing query \"" + query + "\":");

            //var a = list.Where(s => s.getInfo().ToLower().Contains(query.ToLower()));
            List<Restaurant> sublist = new List<Restaurant>();
            foreach (Restaurant r in list)
            {
                if (r.SearchInfo().ToLower().Contains(query.ToLower()))
                {
                    sublist.Add(r);
                }

                //boolean/print method
                //if (r.getInfo().ToLower().Contains(query.ToLower()))
                //{
                //    Console.WriteLine(r.getInfo() + "\n");
                //}
            }

            //have sublist. can either return it or print.
            foreach (Restaurant r in sublist)
            {
                Console.WriteLine(r.GetRestaurantInfo() + "\n");
            }
        }
    }
}
