using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDAO
{
    public interface IPaymentDAO
    {
        List<Payment> GetAllPayment();
        Payment GetPaymentById(int id);
        void Add(Payment Payment);
        void Update(Payment Payment);
        void Delete(int id);
    }
}
