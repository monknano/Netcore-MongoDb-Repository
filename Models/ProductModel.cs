using System;
using Core.MongoDB.Repository;
using Core.MongoDB.Repository.Attributes;

namespace ExRepository.Models {
    [CollectionName ("Product")]
    public class ProductModel : MongoEntity {
		public ProductModel()
		{
			GuId = Guid.NewGuid().ToString();
		}

		public string GuId { get; set; }
        public string Product { get; set; }
        public string Price { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.Now;
    }
}