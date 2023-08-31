using BussinessObject.DTO.StatisticalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IStatisticalRepository
    {
        List<Statistical> GetStatistical(int month);
    }
}
