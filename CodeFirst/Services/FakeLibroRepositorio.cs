using CodeFirst.Models;

namespace CodeFirst.Services
{
    public class FakeLibroRepositorio:ILibroRepositorio
    {
        private List<Libro> LibrosLista = new();

        public FakeLibroRepositorio()
        {
            Libro miLibro = new()
            {
                Id = 1,
                NumPaginas = 100,
                Titulo = "Titulo Libro Fake 1",
                AutorId = 5
            };
            LibrosLista.Add(miLibro);
            miLibro = new()
            {
                Id = 2,
                NumPaginas = 200,
                Titulo = "Titulo Libro Fake 2",
                AutorId = 4
            };
            LibrosLista.Add(miLibro);
            miLibro = new()
            {
                Id = 3,
                NumPaginas = 300,
                Titulo = "Titulo Libro Fake 3",
                AutorId = 2
            };
            LibrosLista.Add(miLibro);
            miLibro = new()
            {
                Id = 4,
                NumPaginas = 200,
                Titulo = "Titulo Libro Fake 4",
                AutorId = 1
            };
            LibrosLista.Add(miLibro);
            miLibro = new()
            {
                Id = 5,
                NumPaginas = 500,
                Titulo = "Titulo Libro Fake 5",
                AutorId = 2
            };
            LibrosLista.Add(miLibro);
        }

        public List<Libro> DameTodos()
        {
            return this.LibrosLista;
        }

        public Libro? DameUno(int Id)
        {
            return this.LibrosLista.FirstOrDefault(x=>x.Id==Id);
        }

        public bool EliminarElemento(int Id)
        {
            return LibrosLista.Remove(DameUno(Id));
        }

        public bool AgregarElemento(Libro libro)
        {
            this.LibrosLista.Add(libro);
            return true;
        }

        public void ModificarElemento(Libro libro)
        {
            EliminarElemento(libro.Id);
            AgregarElemento(libro);
        }
    }
}
