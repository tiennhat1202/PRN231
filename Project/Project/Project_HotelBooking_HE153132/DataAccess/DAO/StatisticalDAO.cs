using BussinessObject.DBContext;
using BussinessObject.DTO.StatisticalDTO;
using BussinessObject.Models;
using DataAccess.IDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class StatisticalDAO : IStatisticalDAO
    {
        private readonly Hotel_BookingContext _dbContext;

        public StatisticalDAO(Hotel_BookingContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Statistical> GetStatistical(int month)
        {
            try
            {
                List<Statistical> statisticals = new List<Statistical>();
                using (var context = new Hotel_BookingContext())
                {
                    var statistical = (from b in context.Bookings
                                       join r in context.Rooms on b.RoomId equals r.RoomId
                                       where b.CheckOutDate.Value.Month == month && b.Status == "Completed"
                                       orderby b.RoomId
                                       select new
                                       {
                                           RoomId = r.RoomId
                                       }).ToList();


                    foreach (var item in statistical.Distinct())
                    {
                        statisticals.Add(new Statistical
                        {
                            RoomName = context.Rooms.FirstOrDefault(x => x.RoomId == item.RoomId).RoomName,
                            CountBooking = context.Bookings.Count(x => x.RoomId == item.RoomId),
                            Total = context.Bookings.Where(x => x.RoomId == item.RoomId).Sum(x => x.TotalPrice)
                        });
                    }
                    return statisticals;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
