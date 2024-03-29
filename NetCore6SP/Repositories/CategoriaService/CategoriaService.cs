using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCore6SP.Data;
using NetCore6SP.Exceptions;
using NetCore6SP.Models;
using NetCore6SP.Models.Entity;

namespace NetCore6SP.Repositories.CategoriaService
{
    public class CategoriaService : IcategoriaService
    {

      

        private readonly GestionCarritoContext _dbContext;
        public CategoriaService(GestionCarritoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Categoria>> GetCategoriaListAsync( )
        {
            try
            {

                return await _dbContext.Categoria
                   .FromSqlRaw<Categoria>("listaBuscarCategoria")
                   .ToListAsync();

            }
            catch (Exception ex)
            {
              
                throw new NotFoundException("Se produjo un error al obtener la lista de categorías. Por favor, inténtalo de nuevo más tarde.", ex);
            }

        }

        public async Task<IEnumerable<Categoria>> GetCategoriaByIdAsync(int Id)
        {
            
                var param = new SqlParameter("@IdCategoria", Id);
                var response = await Task.Run(() => _dbContext.Categoria
                                .FromSqlRaw(@"exec listaBuscarCategoria @IdCategoria", param).ToListAsync());

                if (response.Count==0)
                {
                    throw new NotFoundException("La categoría no se encontró.");
                }

                return response;
            
         
        }

        public async Task<int> AddCategoriaAsync(Categoria categoria)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@IdCategoria", categoria.IdCategoria));
            parameter.Add(new SqlParameter("@Nombre", categoria.Nombre));
            parameter.Add(new SqlParameter("@Activo", categoria.Activo));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec insertarModificarCategoria  @IdCategoria, @Nombre, @Activo", parameter.ToArray()));
            return result;

        }

        public async Task<int> UpdateCategoriaAsync(Categoria categoria)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@IdCategoria", categoria.IdCategoria));
            parameter.Add(new SqlParameter("@Nombre", categoria.Nombre));
            parameter.Add(new SqlParameter("@Activo", categoria.Activo));
          
            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec insertarModificarCategoria @IdCategoria, @Nombre, @Activo", parameter.ToArray()));
            return result;
        }

        public async Task<int> DeleteCategoriaAsync(int Id)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteCategoriaByID {Id}"));
        }

      

       

       
    }
}
