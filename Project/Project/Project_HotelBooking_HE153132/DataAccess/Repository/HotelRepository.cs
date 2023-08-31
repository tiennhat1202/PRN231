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
    public class HotelRepository : IHotelRepository
    {
        private readonly IHotelDAO _hotelDAO;
        public HotelRepository(IHotelDAO hotelDAO)
        {
            _hotelDAO = hotelDAO;
        }

        public void Add(Hotel hotel)
        {
            _hotelDAO.Add(hotel);
        }

        public void Delete(int id)
        {
            _hotelDAO.Delete(id);
        }

        public List<Hotel> GetAllHotels()
        {
            return _hotelDAO.GetAllHotels();
        }

        public Hotel GetHotelById(int id)
        {
            return _hotelDAO.GetHotelById(id);
        }

        public void Update(Hotel hotel)
        {
            _hotelDAO.Update(hotel);
        }
    }
}
