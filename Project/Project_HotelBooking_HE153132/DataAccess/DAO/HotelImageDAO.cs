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
    public class HotelImageDAO : IHotelImageDAO
    {
        private readonly Hotel_BookingContext _dbContext;
        public HotelImageDAO(Hotel_BookingContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<HotelImage> GetAllHotelImg()
        {
            var HotelImgs = new List<HotelImage>();
            try
            {
                HotelImgs = _dbContext.HotelImages.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HotelImgs;
        }
        public HotelImage GetHotelImgById(int id)
        {
            var HotelImg = new HotelImage();
            try
            {
                HotelImg = _dbContext.HotelImages.SingleOrDefault(x => x.ImageId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HotelImg;
        }
        public void Add(HotelImage hotelImage)
        {
            try
            {
                _dbContext.HotelImages.Add(hotelImage);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(HotelImage hotelImage)
        {
            try
            {
                HotelImage _hotel = _dbContext.HotelImages.SingleOrDefault(x => x.ImageId == hotelImage.ImageId);
                if (_hotel != null)
                {
                    _dbContext.HotelImages.Update(hotelImage);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Hotel_IMG not found!");
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
                HotelImage _hotelIMG = _dbContext.HotelImages.SingleOrDefault(x => x.ImageId == id);
                if (_hotelIMG != null)
                {
                    _dbContext.HotelImages.Remove(_hotelIMG);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("HotelIMG not found!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
