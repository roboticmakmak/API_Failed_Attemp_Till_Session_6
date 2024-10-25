using cosmo.core2.Entities;
using cosmo.core2.spesification;

namespace cosmo.repro
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        #region withoutSpesification

        Task<IEnumerable<T>> GetAllAsync();
        Task <T> GetByIdAsync(int id);
        #endregion

        #region with spec
        Task<T> GetAllBySpecAsync(ISpecifications<T> Spec);
       Task <T> GetByIdWithSpecAsync(ISpecifications<T> Spec);
        #endregion
    }
}