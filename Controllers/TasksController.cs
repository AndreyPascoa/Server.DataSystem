using Microsoft.AspNetCore.Mvc;
using Servidor.Application.DTOs;
using Servidor.Application.Interfaces;

namespace Servidor.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _service.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _service.GetByIdAsync(id);
            if (task == null)
                return NotFound("Task não encontrada");

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTaskDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.CreateAsync(dto);
                return Created("", null);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateTaskDto dto)
        {
            try
            {
                var updated = await _service.UpdateAsync(id, dto);
                return updated ? NoContent() : NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound("Task não encontrada");

            return NoContent();
        }
    }
}
