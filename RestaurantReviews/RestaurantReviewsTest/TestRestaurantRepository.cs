using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviewsLibrary;
using System.Collections.Generic;
using RestaurantReviewsLibrary.Repositories;
using Moq;
using System.Data.Entity;
using System.Linq;
using RestaurantReviewsData;
using Restaurant = RestaurantReviewsData.Restaurant;

namespace RestaurantReviewsTest
{
    [TestClass]
    public class TestRestaurantRepository
    {
        //[TestMethod]
        //public void GetRestaurantsByName()
        //{
        //    mockRepo.Setup(x => x.GetRestaurantsAlphabetical()).Returns(rests.ToString);
        //    mockRepo.Object.GetRestaurantsAlphabetical();
        //}

        [TestMethod]
        public void AddRestaurant()
        {
            var mockSet = new Mock<DbSet<RestaurantReviewsData.Restaurant>>();

            var mockContext = new Mock<RestaurantReviewsEntities>();
            mockContext.Setup(m => m.Restaurants).Returns(mockSet.Object);

            var service = new RestaurantRepository(mockContext.Object);
            service.AddRestaurant("Subway", "123 That Way", "1233453423");

            mockSet.Verify(m => m.Add(It.IsAny<Restaurant>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        //[TestMethod]
        //public void AddReview()
        //{
        //    var mockSet = new Mock<DbSet<RestaurantReviewsData.Review>>();

        //    var mockContext = new Mock<RestaurantReviewsEntities>();
        //    mockContext.Setup(m => m.Reviews).Returns(mockSet.Object);

        //    var service = new RestaurantRepository(mockContext.Object);
        //    service.AddReview("Subway",5,"Ok","Bob2");

        //    mockSet.Verify(m => m.Add(It.IsAny<RestaurantReviewsData.Review>()), Times.Once());
        //    mockContext.Verify(m => m.SaveChanges(), Times.Once());
        //}

        [TestMethod]
        public void GetRestaurantsByName()
        {
            var data = new List<Restaurant>
            {
                new Restaurant {name = "Subway"},
                new Restaurant {name = "Qdoba"},
                new Restaurant {name = "Wingstop"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<RestaurantReviewsData.Restaurant>>();
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<RestaurantReviewsEntities>();
            mockContext.Setup(c => c.Restaurants).Returns(mockSet.Object);

            var service = new RestaurantRepository(mockContext.Object);
            //service.AddRestaurant("Subway", "123 That Way", "1233453423");
            var rests = service.GetRestaurantsAlphabetical();

            //mockSet.Verify(m => m.Add(It.IsAny<Restaurant>()), Times.Once());
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(3, rests.Count());
            Assert.AreEqual("Qdoba", rests.ElementAt(0).Name);
            Assert.AreEqual("Subway", rests.ElementAt(1).Name);
            Assert.AreEqual("Wingstop", rests.ElementAt(2).Name);
        }

    }
}
