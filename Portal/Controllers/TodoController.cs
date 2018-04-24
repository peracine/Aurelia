using Core.Model;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Portal.Controllers
{
    [Produces("application/json")]
    [Route("api/Todo")]
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoRepository _todoRepository;

        public TodoController(ILogger<TodoController> logger, ITodoRepository todoRepository)
        {
            _logger = logger;
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _todoRepository.List());
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogTrace("[HTTPGET] ToDo");
            var todo = await _todoRepository.Get(id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Todo todo)
        {
            if (ModelState.ValidationState == ModelValidationState.Invalid)
            {
                return BadRequest(ModelState.Values);
            }

            todo.Id = await _todoRepository.Add(todo);
            return CreatedAtRoute("Get", new { todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Todo todo)
        {
            if (ModelState.ValidationState == ModelValidationState.Invalid)
            {
                return BadRequest(ModelState.Values);
            }

            await _todoRepository.Update(todo);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _todoRepository.Delete(id);
            return new NoContentResult();
        }
    }
}