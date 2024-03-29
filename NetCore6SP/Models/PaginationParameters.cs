namespace NetCore6SP.Models
{
    public class PaginationParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationParameters()
        {
            // Valores predeterminados
            PageNumber = 1; // Página 1 por defecto
            PageSize = 10; // Tamaño de página 10 por defecto
        }
    }
}
