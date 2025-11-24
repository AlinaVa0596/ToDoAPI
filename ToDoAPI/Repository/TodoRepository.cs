using System.Xml.Linq;
using ToDoAPI.Models;

namespace ToDoAPI.Repository
{
    public class TodoRepository
    {
        private readonly List<TodoItem> _items = new()
{
new TodoItem { Id = 1, Title = "Learn AWS CI/CD", IsDone = false },
new TodoItem { Id = 2, Title = "Deploy sample app", IsDone = false }
};


        public IEnumerable<TodoItem> GetAll() => _items;
        public TodoItem? Get(int id) => _items.FirstOrDefault(x => x.Id == id);


        public TodoItem Add(TodoItem item)
        {
            item.Id = _items.Max(i => i.Id) + 1;
            _items.Add(item);
            return item;
        }


        public bool Update(int id, TodoItem updated)
        {
            var existing = Get(id);
            if (existing == null) return false;


            existing.Title = updated.Title;
            existing.IsDone = updated.IsDone;
            return true;
        }


        public bool Delete(int id)
        {
            var item = Get(id);
            if (item == null) return false;
            _items.Remove(item);
            return true;
        }
    }
}
