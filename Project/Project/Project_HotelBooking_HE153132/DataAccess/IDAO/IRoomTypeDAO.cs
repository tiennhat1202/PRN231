using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDAO
{
    public interface IRoomTypeDAO
    {
        List<RoomType> GetAllRoomType();
        RoomType GetRoomTypeById(int id);
        void Add(RoomType RoomType);
        void Update(RoomType RoomType);
        void Delete(int id);
    }
}
