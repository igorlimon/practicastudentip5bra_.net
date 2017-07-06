using EventApp.Data;
using EventApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Infrastructure
{
    public class EventManager
    {
        private readonly EventAppDbContext _context;

        public EventManager(EventAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetAsync(int id)
        {
            return await _context.Events
                 .SingleOrDefaultAsync(m => m.Id == id);
        }

        internal async Task<int> SaveAsync(Event @event)
        {
            _context.Add(@event);
            return await _context.SaveChangesAsync();
        }

        internal async Task EditAsync(Event @event)
        {
            _context.Update(@event);
            await _context.SaveChangesAsync();
        }

        internal bool ExistAsync(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }

        internal async Task DeleteAsync(int id)
        {
            var @event = await GetAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
        }
    }
}
