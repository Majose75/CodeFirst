namespace CodeFirst.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public required string NombreCompleto { get; set; }
        // virtual es un metodo de navegacion. Una forma para poder recuperar los libros del autor. Propiedades de Navegacion.
        public virtual ICollection<Libro> Libros { get; set; }
    }
}
