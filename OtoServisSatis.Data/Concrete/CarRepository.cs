using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Data.Abstract;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data.Concrete
{
    public class CarRepository : Repository<Arac>, ICarRepository
    {
        public CarRepository(OtoDatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Arac>> GetCarAndBrandList()
        {
            return await _dbset.AsNoTracking().Include(x => x.Marka).ToListAsync();
        }

        public async Task<List<Arac>> GetCarAndBrandList(Expression<Func<Arac, bool>> expression)
        {
            return await _dbset.Where(expression).AsNoTracking().Include(x => x.Marka).ToListAsync();
        }

        public async Task<Arac> getCarAndBrandSingle(int id)
        {
            return await _dbset.AsNoTracking().Include(x => x.Marka).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
