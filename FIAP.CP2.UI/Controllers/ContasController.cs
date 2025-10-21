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
    public class ContasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contas.ToListAsync());
        }

        // GET: Contas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaModel = await _context.Contas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contaModel == null)
            {
                return NotFound();
            }

            return View(contaModel);
        }

        // GET: Contas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeTitular,CPF,TipoConta,Saldo,DataAbertura,Ativa,NumeroConta")] ContaModel contaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contaModel);
        }

        // GET: Contas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaModel = await _context.Contas.FindAsync(id);
            if (contaModel == null)
            {
                return NotFound();
            }
            return View(contaModel);
        }

        // POST: Contas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,NomeTitular,CPF,TipoConta,Saldo,DataAbertura,Ativa,NumeroConta")] ContaModel contaModel)
        {
            if (id != contaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaModelExists(contaModel.Id))
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
            return View(contaModel);
        }

        // GET: Contas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaModel = await _context.Contas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contaModel == null)
            {
                return NotFound();
            }

            return View(contaModel);
        }

        // POST: Contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var contaModel = await _context.Contas.FindAsync(id);
            if (contaModel != null)
            {
                _context.Contas.Remove(contaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaModelExists(string id)
        {
            return _context.Contas.Any(e => e.Id == id);
        }
    }
}
