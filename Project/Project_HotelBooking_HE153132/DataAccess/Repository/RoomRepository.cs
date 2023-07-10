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
    public class RoomRepository : IRoomRepository
    {
        private readonly IRoomDAO _roomDAO;

        public RoomRepository(IRoomDAO roomDAO)
        {
            _roomDAO = roomDAO;
        }
        public void Add(Room Room)
        {
            _roomDAO.Add(Room);
        }

        public void Delete(int id)
        {
            _roomDAO.Delete(id);
        }

        public List<Room> GetAllRoom()
        {
            return _roomDAO.GetAllRoom();
        }

        public Room GetRoomById(int id)
        {
            return _roomDAO.GetRoomById(id);
        }

        public void Update(Room Room)
        {
            _roomDAO.Update(Room);
        }
    }
}
