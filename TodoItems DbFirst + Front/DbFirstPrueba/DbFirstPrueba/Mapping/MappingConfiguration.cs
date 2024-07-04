using AutoMapper;
using DbFirstPrueba.Dtos;
using DbFirstPrueba.ModelsDatabase;

namespace DbFirstPrueba.Mapping;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        //Item (Post)
        CreateMap<TodoItem, TodoItemPostDto>();
        CreateMap<TodoItemPostDto, TodoItem>();

        //Categoria (Get)
        CreateMap<Categoria, CategoriaGetDto>();
        CreateMap<CategoriaGetDto, Categoria>();

        //Todo Item (Get)
        CreateMap<TodoItem, TodoItemGetDto>();
        CreateMap<TodoItemGetDto, TodoItem>();

        //Tarea Categoria (Get)
        CreateMap<TodoItem, DtoTareaCategoriaGet>()
            .ForMember(dest => dest.CategoriaName, opt => opt.MapFrom(src => src.Categoria.Nombre));

        //Nuevo para put
        CreateMap<DtoItemPutDto, TodoItem>();
        CreateMap<TodoItem, DtoItemPutDto>();
    }
}
