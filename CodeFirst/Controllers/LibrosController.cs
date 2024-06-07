using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Models;
using CodeFirst.Services;

namespace CodeFirst.Controllers
{
    public class LibrosController : Controller
    {
        //private readonly LibreriaContext _context;
        private readonly IAutorRepositorio _autorContext;
        private readonly ILibroRepositorio _context; 

        public LibrosController(ILibroRepositorio context,IAutorRepositorio autorContext)
        {
            _context = context;
            _autorContext = autorContext;
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
           var elemento= _context.DameTodos();
            return View(elemento);
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var libro = _context.DameUno((int)id);
                
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_autorContext.DameTodos(), "Id", "NombreCompleto"); //Para que ponga los autores en el campo en forma de lista
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,NumPaginas,AutorId")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.AgregarElemento(libro);
               
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)

        {
            ViewData["AutorId"] = new SelectList(_autorContext.DameTodos(), "Id", "NombreCompleto");
            if (id == null)
            {
                return NotFound();
            }

            var libro =  _context.DameUno((int)id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,NumPaginas,AutorId")] Libro libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.ModificarElemento(libro);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            _context.EliminarElemento((int)id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.EliminarElemento((int)id);
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            if (_context.DameUno((int)id) == null)
                return false;
            else
            {
                return true;
            }
        }
    }
}
