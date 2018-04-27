using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewsLibrary
{
    public class Review
    {
        int id;
        internal int Rating { get;}
        string review;
        string user;
        string date;
        internal int Restaurantid { get;}

        public Review(int id, string user, string review, int rating, string date, int restaurantid)
        {
            this.id = id;
            this.user = user;
            this.review = review;
            this.Rating = rating;
            this.date = date;
            this.Restaurantid = restaurantid;
        }

        public string GetReview()
        {
            //String a = "Name: " + this.reviewer + "\nReview: " + this.review + "\nRating: " + this.rating + "\nDate: " + date;
            //string a = $"ID: {id}\nUser: {user}\nReview: {review}\nRating: {Rating}\nDate {date}\nRestaurantID: {Restaurantid}";
            string a = $"User: {user}\nReview: {review}\nRating: {Rating}\nDate {date}";
            return a;
        }
    }
}
