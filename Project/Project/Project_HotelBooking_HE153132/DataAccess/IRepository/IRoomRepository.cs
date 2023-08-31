using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IRoomRepository
    {
        List<Room> GetAllRoom();
        List<Room> GetRoomForHomeCustomer();
        Room GetRoomById(int id);
        void Add(Room Room);
        void Update(Room Room);
        void Delete(int id);
    }
}
