using Core.MongoDB.Repository;
using Core.MongoDB.Repository.Interfaces;
using ExRepository.Models;

namespace ExRepository.Repositorys {
    public class ProductRepository : MongoRepository<ProductModel>, IProductRepository {
        public ProductRepository (IMongoContext mongoContext) : base (mongoContext) {

        }
    }
}