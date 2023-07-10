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
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly IRoomTypeDAO _roomTypeDAO;

        public RoomTypeRepository(IRoomTypeDAO roomTypeDAO)
        {
            _roomTypeDAO = roomTypeDAO;
        }
        public void Add(RoomType RoomType)
        {
            _roomTypeDAO.Add(RoomType);
        }

        public void Delete(int id)
        {
            _roomTypeDAO.Delete(id);
        }

        public List<RoomType> GetAllRoomType()
        {
            return _roomTypeDAO.GetAllRoomType();
        }

        public RoomType GetRoomTypeById(int id)
        {
            return _roomTypeDAO.GetRoomTypeById(id);
        }

        public void Update(RoomType RoomType)
        {
            _roomTypeDAO.Update(RoomType);
        }
    }
}
