using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IRoomImageRepository
    {
        List<RoomImage> GetAllRoomImage();
        RoomImage GetRoomImageById(int id);
        void Add(RoomImage RoomImage);
        void Update(RoomImage RoomImage);
        void Delete(int id);
    }
}
