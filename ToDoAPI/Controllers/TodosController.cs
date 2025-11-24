using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Repository;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly TodoRepository _repo;


        public TodosController(TodoRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());


        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var item = _repo.Get(id);
            return item is null ? NotFound() : Ok(item);
        }


        [HttpPost]
        public IActionResult Create(TodoItem item)
        {
            var created = _repo.Add(item);
            return Created($"api/todos/{created.Id}", created);
        }


        [HttpPut("{id:int}")]
        public IActionResult Update(int id, TodoItem update)
        {
            return _repo.Update(id, update) ? Ok(update) : NotFound();
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return _repo.Delete(id) ? Ok() : NotFound();
        }
    }
}
