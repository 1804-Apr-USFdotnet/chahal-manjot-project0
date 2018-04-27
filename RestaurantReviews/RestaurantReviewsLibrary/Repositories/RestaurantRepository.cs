using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace RestaurantReviewsLibrary.Repositories
{
    class RestaurantRepository : IRestaurantRepository
    {
        //private readonly JSON
        //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Restaurant));
        //read here after deserialization?

        public void Add(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Restaurant GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Restaurant entity)
        {
            throw new NotImplementedException();
        }
    }
}
