using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDAO
{
    public interface IBookingDAO
    {
        List<Booking> GetAllBooking();
        Booking GetBookingById(int id);
        void Add(Booking booking);
        void Update(Booking booking);
        void Delete(int id);

    }
}
