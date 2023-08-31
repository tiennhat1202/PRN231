using BussinessObject.DTO.StatisticalDTO;
using DataAccess.IDAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class StatisticalRepository : IStatisticalRepository
    {

        private readonly IStatisticalDAO _statisticalDAO;

        public StatisticalRepository(IStatisticalDAO statisticalDAODAO)
        {
            _statisticalDAO = statisticalDAODAO;

        }

        public List<Statistical> GetStatistical(int month)
        {
            return _statisticalDAO.GetStatistical(month);
        }
    }
}
