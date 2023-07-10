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
    public class BookingRepository : IBookingRepository
    {
        private readonly IBookingDAO _bookingDAO;
        public BookingRepository(IBookingDAO bookingDAO)
        {
            _bookingDAO = bookingDAO;
        }
        public void Add(Booking booking)
        {
            _bookingDAO.Add(booking);
        }

        public void Delete(int id)
        {
            _bookingDAO.Delete(id);
        }

        public List<Booking> GetAllBooking()
        {
            return _bookingDAO.GetAllBooking();
        }

        public Booking GetBookingById(int id)
        {
            return _bookingDAO.GetBookingById(id);
        }

        public void Update(Booking booking)
        {
            _bookingDAO.Update(booking);
        }
    }
}
