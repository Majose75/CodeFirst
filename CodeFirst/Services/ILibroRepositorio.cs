using CodeFirst.Models;

namespace CodeFirst.Services
{
    public interface ILibroRepositorio
    {
        List<Libro> DameTodos();
        Libro? DameUno(int Id);
        bool EliminarElemento(int Id);
        bool AgregarElemento(Libro grupo);
        void ModificarElemento(/*int Id,*/ Libro libro);
    }
}
