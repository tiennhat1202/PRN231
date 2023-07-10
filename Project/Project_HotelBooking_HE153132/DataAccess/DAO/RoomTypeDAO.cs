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
    public class RoomTypeDAO : IRoomTypeDAO
    {
        private readonly Hotel_BookingContext _dbContext;
        public RoomTypeDAO(Hotel_BookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<RoomType> GetAllRoomType()
        {
            var RoomTypes = new List<RoomType>();
            try
            {
                RoomTypes = _dbContext.RoomTypes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RoomTypes;
        }
        public RoomType GetRoomTypeById(int id)
        {
            var RoomType = new RoomType();
            try
            {
                RoomType = _dbContext.RoomTypes.SingleOrDefault(x => x.RoomTypeId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RoomType;
        }

        public void Add(RoomType RoomType)
        {
            try
            {
                _dbContext.RoomTypes.Add(RoomType);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(RoomType RoomType)
        {
            try
            {
                RoomType _RoomType = _dbContext.RoomTypes.SingleOrDefault(x => x.RoomTypeId == RoomType.RoomTypeId);
                if (_RoomType != null)
                {
                    _dbContext.RoomTypes.Update(RoomType);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("RoomType not found");
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
                RoomType _RoomType = _dbContext.RoomTypes.SingleOrDefault(x => x.RoomTypeId == id);
                if (_RoomType != null)
                {
                    _dbContext.RoomTypes.Remove(_RoomType);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("RoomType not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
