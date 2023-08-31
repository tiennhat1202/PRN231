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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IPaymentDAO _paymentDAO;

        public PaymentRepository(IPaymentDAO paymentDAO)
        {
            _paymentDAO = paymentDAO;
        }

        public void Add(Payment Payment)
        {
            _paymentDAO.Add(Payment);
        }

        public void Delete(int id)
        {
            _paymentDAO.Delete(id);
        }

        public List<Payment> GetAllPayment()
        {
            return _paymentDAO.GetAllPayment();
        }

        public Payment GetPaymentById(int id)
        {
            return _paymentDAO.GetPaymentById(id);
        }

        public void Update(Payment Payment)
        {
            _paymentDAO.Update(Payment);
        }
    }
}
