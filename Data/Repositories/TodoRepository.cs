using Core.Model;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal class TodoRepository : ITodoRepository
    {
        private readonly MainContext _context;

        public TodoRepository(MainContext context)
        {
            _context = context ?? throw new InvalidOperationException("context cannot be null.");
        }

        public async Task<int> Add(Todo todo)
        {
            if (todo == null)
                throw new ArgumentNullException("todo cannot be null");

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                return await _context.SaveChangesAsync() > 0;
            }

            return true;
        }

        public async Task<Todo> Get(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<IEnumerable<Todo>> List()
        {
            return await _context.Todos.AsNoTracking().ToListAsync();
        }

        public async Task<bool> Update(Todo todo)
        {
            if (todo == null)
                throw new ArgumentNullException("todo cannot be null");

            _context.Todos.Update(todo);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
