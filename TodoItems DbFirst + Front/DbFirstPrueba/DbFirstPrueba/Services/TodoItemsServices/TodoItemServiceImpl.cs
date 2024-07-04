using AutoMapper;
using AutoMapper.QueryableExtensions;
using DbFirstPrueba.Dtos;
using DbFirstPrueba.ModelsDatabase;
using Microsoft.EntityFrameworkCore;
using System;

namespace DbFirstPrueba.Services.TodoItemsServices;

public class TodoItemServiceImpl : ITodoItemService
{
    //Inyeccion de dependencias
    private readonly ClubNauticoContext _context;
    private readonly IMapper _mapper;

    public TodoItemServiceImpl(ClubNauticoContext clubNauticoContext, IMapper mapper)
    {
        _context = clubNauticoContext;
        _mapper = mapper;
    }

    //Crear un Item
    public async Task<TodoItemPostDto> CreateTodoItemAsync(TodoItemPostDto lItem)
    {
        try
        {
            var todoItem = _mapper.Map<TodoItem>(lItem);
            todoItem.Id = Guid.NewGuid();

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return lItem;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    //Eliminar Item
    public async Task DeleteTodoItemAsync(Guid id)
    {
        try
        {
            var todoItem = _context.TodoItems.Find(id);

            if (todoItem == null)
            {
                throw new Exception("No se encontro el item");
            }

            _context.TodoItems.Remove(todoItem);
            _context.SaveChanges();

        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    //Obtener todas las Categorias
    public Task<List<CategoriaGetDto>> GetAllCategoriasAsync()
    {
       return _context.Categorias
            .ProjectTo<CategoriaGetDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    //Obtener todos los Items
    public Task<List<TodoItemGetDto>> GetAllItemsAsync()
    {
        return _context.TodoItems.Select(x => new TodoItemGetDto
        {
            Id = x.Id,
            NombreTarea = x.NombreTarea,
            EstaCompleta = x.EstaCompleta,
            Categoria = x.Categoria.Nombre


        }).ToListAsync(); 
    }

    public Task<DtoTareaCategoriaGet> GetTareaCategoriaAsync(Guid id)
    {
        return _context.TodoItems
            .Where(x => x.Id == id)
            .ProjectTo<DtoTareaCategoriaGet>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public Task<List<DtoTareaCategoriaGet>> GetTareaCategoriaSinIdAsync()
    {
        return _context.TodoItems
            .ProjectTo<DtoTareaCategoriaGet>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public Task<DtoItemPutDto> GetTodoItemCategoriaIDAsync(Guid id)
    {
        return _context.TodoItems
            .Where(x => x.Id == id)
            .ProjectTo<DtoItemPutDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    //Put (Actualizar un Item)
    public async Task<TodoItemPutDto> UpdateTodoItemAsync(TodoItemPutDto todoItemPutDto)
    {
        try
        {
            var todoItem = _context.TodoItems.Find(todoItemPutDto.Id);

            if (todoItem == null)
            {
                throw new Exception("No se encontro el item");
            }

            todoItem.NombreTarea = todoItemPutDto.NombreTarea;
            todoItem.EstaCompleta = todoItemPutDto.EstaCompleta;
            todoItem.CategoriaId = todoItemPutDto.CategoriaId;

            await _context.SaveChangesAsync();

            return todoItemPutDto;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
