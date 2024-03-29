using System.ComponentModel.DataAnnotations;

namespace NetCore6SP.Models.Entity
{
    public class Categoria
    {
        [Key] 
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }
        public int Activo { get; set; }
    }
}
