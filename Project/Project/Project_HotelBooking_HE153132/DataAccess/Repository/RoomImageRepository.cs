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
    public class RoomImageRepository : IRoomImageRepository
    {
        private readonly IRoomImageDAO _roomImageDAO;

        public RoomImageRepository(IRoomImageDAO roomImageDAO)
        {
            _roomImageDAO = roomImageDAO;
        }

        public void Add(RoomImage RoomImage)
        {
            _roomImageDAO.Add(RoomImage);
        }

        public void Delete(int id)
        {
            _roomImageDAO.Delete(id);
        }

        public List<RoomImage> GetAllRoomImage()
        {
            return _roomImageDAO.GetAllRoomImage();
        }

        public RoomImage GetRoomImageById(int id)
        {
            return _roomImageDAO.GetRoomImageById(id);
        }

        public void Update(RoomImage RoomImage)
        {
            _roomImageDAO.Update(RoomImage);
        }
    }
}
