using EventApp.Data;
using EventApp.Infrastructure;
using EventApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EventApp.Controllers
{
    public class EventsController : Controller
    {
        private EventManager eventManager;

        public EventsController(EventAppDbContext context)
        {
            eventManager = new EventManager(context);
        }

        public async Task<IActionResult > Index()
        {
            var a = await eventManager.GetAllEventsAsync();
            return View(a);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await eventManager.GetAsync(id.Value);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,PicturePath,Location,Gps,DateTime")] Event @event)
        {
            if (ModelState.IsValid)
            {
                await eventManager.SaveAsync(@event);
               
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await eventManager.GetAsync(id.Value);                 

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,PicturePath,Location,Gps,DateTime")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await eventManager.EditAsync(@event);                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await eventManager.GetAsync(id.Value);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await eventManager.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        private bool EventExists(int id)
        {
            return eventManager.ExistAsync(id);
        }
    }
}
