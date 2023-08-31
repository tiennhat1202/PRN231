using BussinessObject.Models;
using DataAccess.IDAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class HotelImageRepository : IHotelImageRepository
    {
        private readonly IHotelImageDAO _hotelImageDAO;
        public HotelImageRepository(IHotelImageDAO hotelImageDAO)
        {
            _hotelImageDAO = hotelImageDAO;
        }

        public void Add(HotelImage hotelImage)
        {
           _hotelImageDAO.Add(hotelImage);
        }

        public void Delete(int id)
        {
           _hotelImageDAO.Delete(id);
        }

        public List<HotelImage> GetAllHotelImg()
        {
            return _hotelImageDAO.GetAllHotelImg();
        }

        public HotelImage GetHotelImgById(int id)
        {
            return _hotelImageDAO.GetHotelImgById(id);
        }

        public void Update(HotelImage hotelImage)
        {
            _hotelImageDAO.Update(hotelImage);
        }
    }
}
