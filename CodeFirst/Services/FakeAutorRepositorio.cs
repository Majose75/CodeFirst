using System.Linq.Expressions;
using CodeFirst.Models;
using System.Text.RegularExpressions;

namespace CodeFirst.Services
{
    public class FakeAutorRepositorio: IGenericRepositorio<Autor>
    {
        private List<Autor> AutoresLista=new();
        public FakeAutorRepositorio() 
        {
            Autor miAutor = new()
            {
                Id = 1,
                NombreCompleto = "Gracilaso de la Vega Fake 1"
            };
            AutoresLista.Add(miAutor);
            miAutor = new() { 
                Id = 2,
                NombreCompleto="Stephen King Fake2"
            };
            AutoresLista.Add(miAutor);
            miAutor = new()
            {
                Id = 3,
                NombreCompleto = "Autor Fake 3"
            };
            AutoresLista.Add(miAutor);
            miAutor = new()
            {
                Id = 4,
                NombreCompleto = "Autor Fake 4 King"
            };
            AutoresLista.Add(miAutor);
            miAutor = new()
            {
                Id = 5,
                NombreCompleto = "Stephen Autor Fake 5"
            };
            AutoresLista.Add(miAutor);
        }

        public List<Autor> DameTodos()
        {
            return this.AutoresLista;
        }

        public Autor? DameUno(int Id)
        {
            return this.AutoresLista.FirstOrDefault(x => x.Id == Id);
        }

        public bool EliminarElemento(int Id)
        {
            return AutoresLista.Remove(DameUno(Id));
        }

        public bool AgregarElemento(Autor autor)
        {
            this.AutoresLista.Add(autor);
            return true;
        }

        public void ModificarElemento(int Id, Autor elemento)
        {
            EliminarElemento(Id);
            AgregarElemento(elemento);
        }

        public List<Autor> Filtra(Expression<Func<Autor, bool>> predicado)
        {
            return AutoresLista;
        }

    }
}
