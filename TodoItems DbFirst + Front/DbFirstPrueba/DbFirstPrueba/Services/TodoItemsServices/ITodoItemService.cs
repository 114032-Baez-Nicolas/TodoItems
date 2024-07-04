using DbFirstPrueba.Dtos;

namespace DbFirstPrueba.Services.TodoItemsServices;

public interface ITodoItemService
{
    //1) Get (Obtener Todas las Categorias)
    Task<List<CategoriaGetDto>> GetAllCategoriasAsync();

    //2) Get (Obtener Todos los "TodoItems")
    Task<List<TodoItemGetDto>> GetAllItemsAsync();

    //3) Post (Crear un "TodoItem")
    Task<TodoItemPostDto> CreateTodoItemAsync(TodoItemPostDto todoItemPostDto);

    //4) Put Actualizar un item por id
    Task<TodoItemPutDto> UpdateTodoItemAsync(TodoItemPutDto todoItemPutDto);

    //5) Delete (Eliminar un "TodoItem")
    Task DeleteTodoItemAsync(Guid id);

    //6) Muestro Tarea y Categoria (Por id)
    Task<DtoTareaCategoriaGet> GetTareaCategoriaAsync(Guid id);

    //7) Muestro Tarea y Categoria
    Task <List<DtoTareaCategoriaGet>> GetTareaCategoriaSinIdAsync();

    //8) Un get completo pero tiene id de categoria como int y se busca por guid
    Task<DtoItemPutDto> GetTodoItemCategoriaIDAsync(Guid id);

}
