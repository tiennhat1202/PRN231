using BussinessObject.DBContext;
using BussinessObject.Models;
using DataAccess.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class HotelDAO : IHotelDAO
    {
        private readonly Hotel_BookingContext _dbContext;

        public HotelDAO(Hotel_BookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Hotel> GetAllHotels()
        {
            var Hotels = new List<Hotel>();
            try
            {
                Hotels = _dbContext.Hotels.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Hotels;
        }
        public Hotel GetHotelById(int id)
        {
            var Hotel = new Hotel();
            try
            {
                Hotel = _dbContext.Hotels.SingleOrDefault(x => x.HotelId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Hotel;
        }
        public void Add(Hotel hotel)
        {
            try
            {
                _dbContext.Hotels.Add(hotel);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Hotel hotel)
        {
            try
            {
                Hotel _hotel = _dbContext.Hotels.SingleOrDefault(x => x.HotelId == hotel.HotelId);
                if (_hotel != null)
                {
                    _dbContext.Hotels.Update(hotel);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Hotel not found!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                Hotel _hotel = _dbContext.Hotels.SingleOrDefault(x => x.HotelId == id);
                if (_hotel != null)
                {
                    _dbContext.Hotels.Remove(_hotel);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Hotel not found!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
