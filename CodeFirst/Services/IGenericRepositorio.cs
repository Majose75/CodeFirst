using CodeFirst.Models;
using System.Linq.Expressions;

namespace CodeFirst.Services
{
    public interface IGenericRepositorio<T> where T : class
    {
        List<T> DameTodos();
        T? DameUno(int Id);
        bool EliminarElemento(int Id);
        bool AgregarElemento(T elemento);
        void ModificarElemento(int Id, T elemento);
        List<T> Filtra(Expression<Func<T, bool>> predicado);
    }
}
