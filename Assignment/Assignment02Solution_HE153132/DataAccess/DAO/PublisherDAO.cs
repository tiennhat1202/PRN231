using BusinessObject.DBContext;
using BusinessObject.Models;
using DataAccess.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class PublisherDAO : IPublisherDAO
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public PublisherDAO(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public List<Publisher> Get()
        {
            var publishers = new List<Publisher>();
            try
            {
                publishers = _applicationDBContext.Publishers.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return publishers;
        }

        public Publisher GetPublisherById(int id)
        {
            var publisher = new Publisher();
            try
            {
                publisher = _applicationDBContext.Publishers.SingleOrDefault(p => p.PubId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return publisher;
        }

        public void Add(Publisher publisher)
        {
            try
            {
                _applicationDBContext.Publishers.Add(publisher);
                _applicationDBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Publisher publisher)
        {
            try
            {

                Publisher _publisher = _applicationDBContext.Publishers.SingleOrDefault(c => c.PubId == publisher.PubId);
                if (_publisher != null)
                {
                    _applicationDBContext.Publishers.Update(publisher);
                    _applicationDBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Publisher Not Found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                Publisher _publisher = _applicationDBContext.Publishers.SingleOrDefault(c => c.PubId == id);
                if (_publisher != null)
                {
                    _applicationDBContext.Publishers.Remove(_publisher);
                    _applicationDBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Publisher Not Found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
