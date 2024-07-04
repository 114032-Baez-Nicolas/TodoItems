using DbFirstPrueba.Dtos;
using DbFirstPrueba.Services.TodoItemsServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpPost("CreateTodoItem")]
        public async Task<IActionResult> CreateTodoItem([FromBody] TodoItemPostDto todoItemPostDto)
        {
            var result = await _todoItemService.CreateTodoItemAsync(todoItemPostDto);

            return Ok(result);

        }

        [HttpGet("GetAllCategorias")]
        public async Task<IActionResult> GetAllCategorias()
        {
            var result = await _todoItemService.GetAllCategoriasAsync();

            return Ok(result);
        }

        [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            var result = await _todoItemService.GetAllItemsAsync();

            return Ok(result);
        }

        [HttpDelete("DeleteTodoItem/{id}")]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            await _todoItemService.DeleteTodoItemAsync(id);

            return Ok();
        }

        [HttpPut("UpdateTodoItem")]
        public async Task<IActionResult> UpdateTodoItem([FromBody] TodoItemPutDto todoItemPutDto)
        {
            var result = await _todoItemService.UpdateTodoItemAsync(todoItemPutDto);

            return Ok(result);
        }

        [HttpGet("GetTareaCategoria/{id}")]
        public async Task<IActionResult> GetTareaCategoriaDto(Guid id)
        {
            var result = await _todoItemService.GetTareaCategoriaAsync(id);

            return Ok(result);
        }

        [HttpGet("GetTareaCategoriaSinId")]
        public async Task<IActionResult> GetTareaCategoriaSinId()
        {
            var result = await _todoItemService.GetTareaCategoriaSinIdAsync();

            return Ok(result);
        }

        [HttpGet("CategoriaXId/{id}")]
        public async Task<IActionResult> GetTodoItemCategoriaID(Guid id)
        {
            var result = await _todoItemService.GetTodoItemCategoriaIDAsync(id);

            return Ok(result);
        }
    }
}
