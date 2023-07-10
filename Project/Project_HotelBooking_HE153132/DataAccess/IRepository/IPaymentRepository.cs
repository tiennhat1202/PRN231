using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IPaymentRepository
    {
        List<Payment> GetAllPayment();
        Payment GetPaymentById(int id);
        void Add(Payment Payment);
        void Update(Payment Payment);
        void Delete(int id);
    }
}
