using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data.Abstract
{
    public interface ICarRepository : IRepository<Arac>
    {
        Task<IEnumerable<Arac>> GetCarAndBrandList();
        Task<List<Arac>> GetCarAndBrandList(Expression<Func<Arac,bool>>expression);
        Task<Arac> getCarAndBrandSingle(int id);
    }
}
