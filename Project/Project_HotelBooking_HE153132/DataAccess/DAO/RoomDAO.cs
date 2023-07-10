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
    public class RoomDAO : IRoomDAO
    {
        private readonly Hotel_BookingContext _dbContext;
        public RoomDAO(Hotel_BookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Room> GetAllRoom()
        {
            var Rooms = new List<Room>();
            try
            {
                Rooms = _dbContext.Rooms.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Rooms;
        }
        public Room GetRoomById(int id)
        {
            var Room = new Room();
            try
            {
                Room = _dbContext.Rooms.SingleOrDefault(x => x.RoomId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Room;
        }

        public void Add(Room Room)
        {
            try
            {
                _dbContext.Rooms.Add(Room);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Room Room)
        {
            try
            {
                Room _Room = _dbContext.Rooms.SingleOrDefault(x => x.RoomId == Room.RoomId);
                if (_Room != null)
                {
                    _dbContext.Rooms.Update(Room);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Room not found");
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
                Room _Room = _dbContext.Rooms.SingleOrDefault(x => x.RoomId == id);
                if (_Room != null)
                {
                    _dbContext.Rooms.Remove(_Room);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Room not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
