using CellPhonesAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CellPhonesAPI.Service
{
    public class CellPhoneService
    {
        private readonly IMongoCollection<CellPhone> _cellPhones;

        public CellPhoneService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("CellPhonesGalleryDB"));
            IMongoDatabase database = client.GetDatabase("CellPhonesGalleryDB");
            _cellPhones = database.GetCollection<CellPhone>("CellPhones");
        }

        public List<CellPhone> Get()
        {
            return _cellPhones.Find(cellphone => true).ToList();
        }

        public CellPhone Get(string id)
        {
            return _cellPhones.Find<CellPhone>(cellphone => cellphone.Id == id).FirstOrDefault();
        }

        public CellPhone Create(CellPhone cellPhone)
        {
            _cellPhones.InsertOne(cellPhone);
            return cellPhone;
        }

        public void Update(string id, CellPhone cellPhoneIn)
        {
            _cellPhones.ReplaceOne(cellPhone => cellPhone.Id == id, cellPhoneIn);
        }

        public void Remove(CellPhone cellPhoneIn)
        {
            _cellPhones.DeleteOne(cellPhone => cellPhone.Id == cellPhoneIn.Id);
        }

        public void Remove(string id)
        {
            _cellPhones.DeleteOne(cellPhone => cellPhone.Id == id);
        }
    }
}