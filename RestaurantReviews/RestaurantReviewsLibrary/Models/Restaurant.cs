﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewsLibrary
{
    public class Restaurant
    {
        [JsonProperty (PropertyName = "id")]
        internal int ID { get;}
        [JsonProperty(PropertyName = "name")]
        internal string Name { get;}
        [JsonProperty(PropertyName = "address")]
        internal string Address {get;}
        [JsonProperty(PropertyName = "phone")]
        internal string Phone { get;}

        List<Review> reviews;
        int reviewCount;
        internal decimal AverageRating { get; set; }

        public Restaurant(int id, string name, string address, string phone)
        {
            this.ID = id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            reviews = new List<Review>();
            reviewCount = 0;
            AverageRating = 0;
        }

        public void PopulateReviews(Review review)
        {
            reviews.Add(review);
            AverageRating = (AverageRating * reviewCount + review.Rating) / (reviewCount + 1);
            reviewCount++;
        }

        //public void addReview(String reviewer, String review, int rating, String date)
        //{
        //    //reviews[reviewCount] = new Review(reviewer, review, rating, date);
        //    reviews.Add(new Review(reviewer, review, rating, date));
        //    averageRating = (averageRating * reviewCount + rating) / (reviewCount + 1);
        //    reviewCount++;
        //}

        public string SearchInfo()
        {
            //string a = $"{id}\n{Name}\n{address}\n{phone}\n{AverageRating}";
            string a = $"{Name}\n{Address}\n{Phone}\n{AverageRating}";
            return a;
        }

        public string GetRestaurantInfo()
        {
            //string a = "Name: " + this.name + "\nAddress: " + this.address + "\nPhone: " + this.phone + "\nRating: " + averageRating;
            //string a = $"Name: {name}\nAddress: {address}\nPhone: {phone}\nRating: {averageRating}";
            //string a = $"ID: {id}\nname: {name}\nAddress: {address}\nPhone: {phone}\nRating: {AverageRating}";
            string a = $"Name: {Name}\nAddress: {Address}\nPhone: {Phone}\nRating: {AverageRating}";
            return a;
        }

        public string GetReviews()
        {
            String a = "";
            foreach (Review r in reviews)
            {
                a += r.GetReview() + "\n\n";
            }
            return a;
        }
    }
}
