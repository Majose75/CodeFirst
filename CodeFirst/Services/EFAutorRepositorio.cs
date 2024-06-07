using CodeFirst.Controllers;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace CodeFirst.Services
{
    public class EFAutorRepositorio:IAutorRepositorio
    {
        private readonly LibreriaContext _context = new();
        public List<Autor> DameTodos()
        {
            return _context.Autores.AsNoTracking().ToList();
        }

        public Autor? DameUno(int Id)
        {
            return _context.Autores.Find(Id);
        }

        public bool EliminarElemento(int Id)
        {
            if (DameUno(Id) != null)
            {
                _context.Autores.Remove(DameUno(Id));
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AgregarElemento(Autor autor)
        {
            if (DameUno(autor.Id) != null)
            {
                return false;
            }
            else
            {
                _context.Autores.Add(autor);
                _context.SaveChanges();
                return true;
            }
        }

        public void ModificarElemento(Autor autor)
        {
            //var recupera = DameUno(Id);
            //if (recupera != null)
            //{
            //    EliminarElemento(Id);
            //}
            //AgregarElemento(autor);

            _context.Autores.Update(autor);
            _context.SaveChangesAsync();
        }
    }
}
