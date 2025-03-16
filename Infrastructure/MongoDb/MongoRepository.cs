using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.MongoDb
{
    public class MongoRepository<T> : IMongoRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;
        //private readonly IMongoDatabase database;

        public MongoRepository(IMongoDatabase database)
        {
            string collectionName = typeof(T).Name.ToLowerInvariant(); // Use class name as collection name
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<T> GetByIdAsync(int id) =>
            await _collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();


        public async Task AddAsync(T entity) => await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(int id, T entity) =>
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entity);

        public async Task DeleteAsync(int id) =>
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
    }
}
