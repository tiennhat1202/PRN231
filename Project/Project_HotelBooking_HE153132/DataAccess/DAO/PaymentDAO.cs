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
    public class PaymentDAO : IPaymentDAO
    {
        private readonly Hotel_BookingContext _dbContext;
        public PaymentDAO(Hotel_BookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Payment> GetAllPayment()
        {
            var Payments = new List<Payment>();
            try
            {
                Payments = _dbContext.Payments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Payments;
        }
        public Payment GetPaymentById(int id)
        {
            var Payment = new Payment();
            try
            {
                Payment = _dbContext.Payments.SingleOrDefault(x => x.PaymentId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Payment;
        }

        public void Add(Payment Payment)
        {
            try
            {
                _dbContext.Payments.Add(Payment);

                Booking booking = _dbContext.Bookings.SingleOrDefault(x => x.BookingId == Payment.BookingId);
                if (booking != null)
                {
                    booking.Status = "Completed";
                    _dbContext.Bookings.Update(booking);
                }

                Room room = _dbContext.Rooms.SingleOrDefault(x => x.RoomId == booking.RoomId);
                if (room != null)
                {
                    room.Status = "Available";
                    _dbContext.Rooms.Update(room);
                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Payment Payment)
        {
            try
            {
                Payment _Payment = _dbContext.Payments.SingleOrDefault(x => x.PaymentId == Payment.PaymentId);
                if (_Payment != null)
                {
                    _dbContext.Payments.Update(Payment);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Payment not found");
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
                Payment _Payment = _dbContext.Payments.SingleOrDefault(x => x.PaymentId == id);
                if (_Payment != null)
                {
                    _dbContext.Payments.Remove(_Payment);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Payment not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
