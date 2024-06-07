using CodeFirst.Controllers;
using CodeFirst.Models;

namespace CodeFirst.Services
{
    public interface IAutorRepositorio
    {
        List<Autor> DameTodos();
        Autor? DameUno(int Id);
        bool EliminarElemento(int Id);
        bool AgregarElemento(Autor autor);
        void ModificarElemento(/*int Id,*/ Autor autor);
    }
}
