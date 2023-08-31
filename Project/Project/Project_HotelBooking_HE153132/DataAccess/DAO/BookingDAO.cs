using BussinessObject.DBContext;
using BussinessObject.Models;
using DataAccess.IDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookingDAO : IBookingDAO
    {
        private readonly Hotel_BookingContext _dbContext;

        public BookingDAO(Hotel_BookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Booking> GetAllBooking()
        {
            try
            {
                using (var context = new Hotel_BookingContext())
                {
                    var bookings = context.Bookings
                        .Include( x=> x.User)
                        .Include(x=> x.Room)
                        .ToList();
                    return bookings;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Booking GetBookingById(int id)
        {
            var Booking = new Booking();
            try
            {
                Booking = _dbContext.Bookings
                    //.Include(b => b.User)
                    //.Include(b => b.Room)
                    //.Include(b => b.Payments)
                    .SingleOrDefault(x => x.BookingId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Booking;
        }

        public void Add(Booking booking)
        {
            try
            {
                _dbContext.Bookings.Add(booking);
                Room room = _dbContext.Rooms.SingleOrDefault(x=> x.RoomId == booking.RoomId);
                if(room != null)
                {
                    room.Status = "Booked";
                    _dbContext.Rooms.Update(room);
                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Booking booking)
        {
            try
            {
                Booking _booking = _dbContext.Bookings.SingleOrDefault(x => x.BookingId == booking.BookingId);
                if (_booking != null)
                {
                    _dbContext.Bookings.Update(booking);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Booking not found");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                Booking _booking = _dbContext.Bookings.SingleOrDefault(x => x.BookingId == id);
                if (_booking != null)
                {
                    _dbContext.Bookings.Remove(_booking);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Booking not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
