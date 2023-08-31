using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDAO
{
    public interface IHotelDAO
    {
        List<Hotel> GetAllHotels();
        Hotel GetHotelById(int id);
        void Add(Hotel hotel);
        void Update(Hotel hotel);
        void Delete(int id);

    }
}
