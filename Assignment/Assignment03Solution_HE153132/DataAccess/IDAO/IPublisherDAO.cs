using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDAO
{
    public interface IPublisherDAO
    {
        List<Publisher> Get();
        Publisher GetPublisherById(int id);
        void Add(Publisher publisher);
        void Update(Publisher publisher);
        void Delete(int id);

    }
}
