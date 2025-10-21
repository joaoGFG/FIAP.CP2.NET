using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FIAP.CP2.Data;
using FIAP.CP2.Model;

namespace FIAP.CP2.UI.Controllers
{
    public class MetodosPagamentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MetodosPagamentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MetodosPagamento
        public async Task<IActionResult> Index()
        {
            return View(await _context.MetodosPagamento.ToListAsync());
        }

        // GET: MetodosPagamento/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPagamentoModel = await _context.MetodosPagamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metodoPagamentoModel == null)
            {
                return NotFound();
            }

            return View(metodoPagamentoModel);
        }

        // GET: MetodosPagamento/Create
        public IActionResult Create()
        {
            ViewData["ContaId"] = new SelectList(_context.Contas, "Id", "NomeTitular");
            return View();
        }

        // POST: MetodosPagamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContaId,TipoMetodo,Descricao")] MetodoPagamentoModel metodoPagamentoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metodoPagamentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContaId"] = new SelectList(_context.Contas, "Id", "NomeTitular", metodoPagamentoModel.ContaId);
            return View(metodoPagamentoModel);
        }

        // GET: MetodosPagamento/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPagamentoModel = await _context.MetodosPagamento.FindAsync(id);
            if (metodoPagamentoModel == null)
            {
                return NotFound();
            }
            ViewData["ContaId"] = new SelectList(_context.Contas, "Id", "NomeTitular", metodoPagamentoModel.ContaId);
            return View(metodoPagamentoModel);
        }

        // POST: MetodosPagamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,ContaId,TipoMetodo,Descricao")] MetodoPagamentoModel metodoPagamentoModel)
        {
            if (id != metodoPagamentoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metodoPagamentoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetodoPagamentoModelExists(metodoPagamentoModel.Id))
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
            ViewData["ContaId"] = new SelectList(_context.Contas, "Id", "NomeTitular", metodoPagamentoModel.ContaId);
            return View(metodoPagamentoModel);
        }

        // GET: MetodosPagamento/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPagamentoModel = await _context.MetodosPagamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metodoPagamentoModel == null)
            {
                return NotFound();
            }

            return View(metodoPagamentoModel);
        }

        // POST: MetodosPagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var metodoPagamentoModel = await _context.MetodosPagamento.FindAsync(id);
            if (metodoPagamentoModel != null)
            {
                _context.MetodosPagamento.Remove(metodoPagamentoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetodoPagamentoModelExists(string id)
        {
            return _context.MetodosPagamento.Any(e => e.Id == id);
        }
    }
}