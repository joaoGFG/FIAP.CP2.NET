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
    public class TransacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transacoes.ToListAsync());
        }

        // GET: Transacoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacaoModel = await _context.Transacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transacaoModel == null)
            {
                return NotFound();
            }

            return View(transacaoModel);
        }

        // GET: Transacoes/Create
        public IActionResult Create()
        {
            ViewData["ContaId"] = new SelectList(_context.Contas, "Id", "NomeTitular");
            return View();
        }

        // POST: Transacoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContaId,Tipo,Valor,DataHora,Descricao,ContaDestinoId,SaldoAnterior,SaldoPosterior")] TransacaoModel transacaoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transacaoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContaId"] = new SelectList(_context.Contas, "Id", "NomeTitular", transacaoModel.ContaId);
            return View(transacaoModel);
        }

        // GET: Transacoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacaoModel = await _context.Transacoes.FindAsync(id);
            if (transacaoModel == null)
            {
                return NotFound();
            }
            ViewData["ContaId"] = new SelectList(_context.Contas, "Id", "NomeTitular", transacaoModel.ContaId);
            return View(transacaoModel);
        }

        // POST: Transacoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,ContaId,Tipo,Valor,DataHora,Descricao,ContaDestinoId,SaldoAnterior,SaldoPosterior")] TransacaoModel transacaoModel)
        {
            if (id != transacaoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transacaoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransacaoModelExists(transacaoModel.Id))
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
            ViewData["ContaId"] = new SelectList(_context.Contas, "Id", "NomeTitular", transacaoModel.ContaId);
            return View(transacaoModel);
        }

        // GET: Transacoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacaoModel = await _context.Transacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transacaoModel == null)
            {
                return NotFound();
            }

            return View(transacaoModel);
        }

        // POST: Transacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var transacaoModel = await _context.Transacoes.FindAsync(id);
            if (transacaoModel != null)
            {
                _context.Transacoes.Remove(transacaoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransacaoModelExists(string id)
        {
            return _context.Transacoes.Any(e => e.Id == id);
        }
    }
}
