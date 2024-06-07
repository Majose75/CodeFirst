using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace CodeFirst.Services
{
    public class EFLibroRepositorio:ILibroRepositorio
    {
        private readonly LibreriaContext _context = new();
        public List<Libro> DameTodos()
        {
            return _context.Libros.AsNoTracking().ToList();
        }

        public Libro? DameUno(int Id)
        {
            return _context.Libros.Find(Id);
        }

        public bool EliminarElemento(int Id)
        {
            if (DameUno(Id) != null)
            {
                _context.Libros.Remove(DameUno(Id));
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AgregarElemento(Libro libro)
        {
            if (DameUno(libro.Id) != null)
            {
                return false;
            }
            else
            {
                _context.Libros.Add(libro);
                _context.SaveChanges();
                return true;
            }
        }

        public void ModificarElemento(Libro libro)
        {
            //var recupera = DameUno(Id);
            //if (recupera != null)
            //{
            //    EliminarElemento(Id);
            //}
            //AgregarElemento(libro);

            _context.Libros.Update(libro);
            _context.SaveChangesAsync();
        }
    }
}
