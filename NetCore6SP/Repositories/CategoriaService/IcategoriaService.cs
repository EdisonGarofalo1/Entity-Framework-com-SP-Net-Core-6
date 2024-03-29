using NetCore6SP.Models;
using NetCore6SP.Models.Entity;

namespace NetCore6SP.Repositories.CategoriaService
{
    public interface IcategoriaService
    {

        public Task<List<Categoria>> GetCategoriaListAsync( );
        public Task<IEnumerable<Categoria>> GetCategoriaByIdAsync(int Id);
        public Task<int> AddCategoriaAsync(Categoria categoria);
        public Task<int> UpdateCategoriaAsync(Categoria categoria);
        public Task<int> DeleteCategoriaAsync(int Id);
    }
}
