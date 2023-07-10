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
    public class RoomImageDAO : IRoomImageDAO
    {
        private readonly Hotel_BookingContext _dbContext;
        public RoomImageDAO(Hotel_BookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<RoomImage> GetAllRoomImage()
        {
            var RoomImages = new List<RoomImage>();
            try
            {
                RoomImages = _dbContext.RoomImages.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RoomImages;
        }
        public RoomImage GetRoomImageById(int id)
        {
            var RoomImage = new RoomImage();
            try
            {
                RoomImage = _dbContext.RoomImages.SingleOrDefault(x => x.ImageId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RoomImage;
        }

        public void Add(RoomImage RoomImage)
        {
            try
            {
                _dbContext.RoomImages.Add(RoomImage);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(RoomImage RoomImage)
        {
            try
            {
                RoomImage _RoomImage = _dbContext.RoomImages.SingleOrDefault(x => x.ImageId == RoomImage.ImageId);
                if (_RoomImage != null)
                {
                    _dbContext.RoomImages.Update(RoomImage);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("RoomImage not found");
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
                RoomImage _RoomImage = _dbContext.RoomImages.SingleOrDefault(x => x.ImageId == id);
                if (_RoomImage != null)
                {
                    _dbContext.RoomImages.Remove(_RoomImage);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("RoomImage not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
