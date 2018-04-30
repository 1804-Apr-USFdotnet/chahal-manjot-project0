using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewsData;

namespace RestaurantReviewsLibrary.Models
{
    public class LibraryHelper
    {
        public IEnumerable<Restaurant> GetRestaurants()
        {
            IEnumerable<Restaurant> result;
            using (var db = new RestaurantReviewsEntities())
            {
                var dataList = db.Restaurants.ToList();
                result = dataList.Select(x => DataToLibrary(x)).ToList();
            }
            return result;
        }

        public IEnumerable<Restaurant> GetRestaurantsAlphabetical()
        {
            IEnumerable<Restaurant> result;
            using (var db = new RestaurantReviewsEntities())
            {
                var dataList = db.Restaurants.OrderBy(x => x.name).ToList();
                result = dataList.Select(x => DataToLibrary(x)).ToList();
            }
            return result;
        }

        public IEnumerable<Restaurant> GetRestaurantsByRating()
        {
            IEnumerable<Restaurant> result;
            using (var db = new RestaurantReviewsEntities())
            {
                var dataList = db.Restaurants.ToList();
                result = dataList.Select(x => DataToLibrary(x)).OrderByDescending(x => x.AverageRating).ToList();
            }
            return result;
        }

        public IEnumerable<Restaurant> GetTop3RestaurantsByRating()
        {
            IEnumerable<Restaurant> result;
            using (var db = new RestaurantReviewsEntities())
            {
                var dataList = db.Restaurants.ToList();
                result = dataList.Select(x => DataToLibrary(x)).OrderByDescending(x => x.AverageRating).Take(3).ToList();
            }
            return result;
        }

        public Restaurant GetDetails(string a)
        {
            Restaurant result;
            using (var db = new RestaurantReviewsEntities())
            {
                var rest = db.Restaurants.SingleOrDefault(x => x.name == a);
                result = DataToLibrary(rest);
                return result;
            }
        }

        public IEnumerable<Review> GetReviews(string a)
        {
            IEnumerable<Review> result;
            using (var db = new RestaurantReviewsEntities())
            {
                var rest = db.Restaurants.SingleOrDefault(x => x.name == a);
                var rev = rest.Reviews.ToList();
                result = rev.Select(x => DataToLibrary(x)).ToList();
                return result;
            }
        }

        public void AddRestaurant(string name, string address, string phone)
        {
            using (var db = new RestaurantReviewsEntities())
            {
                var rest = new Restaurant()
                {
                    Name = name,
                    Address = address,
                    Phone = phone
                };

                db.Restaurants.Add(LibraryToData(rest));
                db.SaveChanges();
            }
        }

        public void RemoveRestaurant(string name)
        {
            using (var db = new RestaurantReviewsEntities())
            {
                var rest = db.Restaurants.SingleOrDefault(x => x.name == name);
                int id = rest.id;
                if (rest != null)
                {
                    db.Reviews.RemoveRange(db.Reviews.Where(x => x.restaurantid == id));
                    db.Restaurants.Remove(rest);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateRestaurant(string name, string update)
        {
            using (var db = new RestaurantReviewsEntities())
            {
                var rest = db.Restaurants.SingleOrDefault(x => x.name == name);
                if (rest != null)
                {
                    rest.name = update;
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<Restaurant> Search(string search)
        {
            IEnumerable<Restaurant> result;
            using (var db = new RestaurantReviewsEntities())
            {
                var dataList = db.Restaurants.Where(x => x.name.Contains(search) || x.address.Contains(search) || x.phone.Contains(search)).ToList();
                result = dataList.Select(x => DataToLibrary(x)).ToList();
            }
            return result;
        }

        public static Restaurant DataToLibrary(RestaurantReviewsData.Restaurant dataModel)
        {
            double rating = 0;
            using (var db = new RestaurantReviewsEntities())
            {
                var reviews = db.Reviews.Where(r => r.restaurantid == dataModel.id);
                if (reviews.Count() != 0)
                    rating = reviews.Average(r => r.rating);
            }

            var libModel = new Restaurant()
            {
                ID = dataModel.id,
                Name = dataModel.name,
                Address = dataModel.address,
                Phone = dataModel.phone,
                AverageRating = rating
                //reviews = (List<Review>) dataModel.Reviews
            };
            return libModel;
        }

        public static RestaurantReviewsData.Restaurant LibraryToData(Restaurant libModel)
        {
            var dataModel = new RestaurantReviewsData.Restaurant()
            {
                name = libModel.Name,
                address = libModel.Address,
                phone = libModel.Phone
            };
            return dataModel;
        }

        public static Review DataToLibrary(RestaurantReviewsData.Review dataModel)
        {
            var libModel = new Review()
            {
                id = dataModel.id,
                Rating = dataModel.rating,
                review = dataModel.review,
                user = dataModel.user,
                date = dataModel.date,
                Restaurantid = dataModel.restaurantid
            };
            return libModel;
        }
    }
}
