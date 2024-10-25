using cosmo.core2.Entities;
using cosmo.core2.Reposatries;
using cosmo.core2.spesification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cosmo.repro
{
    public class GenaricReprository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbContext;

        public GenaricReprository()
        {
        }

        public GenaricReprository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
     =>   await _dbContext.Set<T>().ToListAsync();


        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
       }


        public async Task<List<T> >GetAllBySpecAsync(ISpecifications<T> Spec)
        {
            return await ApplySpecification(Spec).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecAsync(ISpecifications<T> Spec)
        {
            return await ApplySpecification(Spec).FirstOrDefaultAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecifications<T> Spec)
        {
            return IspesificationEvalutor<T>.GetQuery(_dbContext.Set<T>(), Spec);
        }
    }
}
