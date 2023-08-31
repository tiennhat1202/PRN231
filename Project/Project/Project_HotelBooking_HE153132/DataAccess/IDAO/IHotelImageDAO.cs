using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDAO
{
    public interface IHotelImageDAO
    {
        List<HotelImage> GetAllHotelImg();
        HotelImage GetHotelImgById(int id);
        void Add(HotelImage hotelImage);
        void Update(HotelImage hotelImage);
        void Delete(int id);
    }
}
