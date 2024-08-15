using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiCrudToDo.Models;
using ApiCrudToDo.Services;

namespace ApiCrudToDo.Controllers
{
    public class TodoModelsController : Controller
    {


        private readonly JsonPlaceholderService _jsonPlaceholderService;
        public TodoModelsController(JsonPlaceholderService jsonPlaceholderService)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
        }

        // GET: TodoModels
        public async Task<IActionResult> Index()
        {
            var list = await _jsonPlaceholderService.GetTodosAsync();
            return View(list);
        }

        // GET: TodoModels/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoModel = await _jsonPlaceholderService.GetTodoAsync(id);
                
            if (todoModel == null)
            {
                return NotFound();
            }

            return View(todoModel);
        }

        // GET: TodoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,todo,completed,userId")] TodoModel todoModel)
        {
            if (ModelState.IsValid)
            {
                
               var newModel =  await _jsonPlaceholderService.CreateTodoAsync(todoModel);
                return RedirectToAction(nameof(Index));
            }
            return View(todoModel);
        }

        // GET: TodoModels/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoModel = await _jsonPlaceholderService.GetTodoAsync(id);
            if (todoModel == null)
            {
                return NotFound();
            }
            return View(todoModel);
        }

        // POST: TodoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,todo,completed,userId")] TodoModel todoModel)
        {
            if (id != todoModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _jsonPlaceholderService.UpdateTodoAsync(id,todoModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(todoModel);
        }

        // GET: TodoModels/Delete/5
       /* public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoModel = await _context.TodoModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (todoModel == null)
            {
                return NotFound();
            }

            return View(todoModel);
        }

        // POST: TodoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todoModel = await _context.TodoModel.FindAsync(id);
            if (todoModel != null)
            {
                _context.TodoModel.Remove(todoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoModelExists(int id)
        {
            return _context.TodoModel.Any(e => e.id == id);
        }*/
    }
}
