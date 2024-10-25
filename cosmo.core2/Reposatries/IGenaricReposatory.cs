using cosmo.core2.Entities;
using cosmo.core2.spesification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cosmo.core2.Reposatries
{
    public interface IGenericRepository<T> where T : Entities.BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task GetAllWithSpecAsync(BaseSpecifications<product> spec);
        Task GetAllWithSpecAsync(BaseSpecifications<cosmo.repro.Product> spec);
        Task GetAllWithSpecAsync(BaseSpecifications<cosmo.repro.Product> spec);
        Task<T> GetByIdAsync(int id);
        Task GetByIdWithSpecAsync();
    }
}
