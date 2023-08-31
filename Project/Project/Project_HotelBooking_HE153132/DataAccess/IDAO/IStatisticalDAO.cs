using BussinessObject.DTO.StatisticalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDAO
{
    public interface IStatisticalDAO
    {
        List<Statistical> GetStatistical(int month);
    }
}
