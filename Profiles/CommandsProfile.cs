using apiHelloWorld.Dtos;
using apiHelloWorld.Models;
using AutoMapper;

namespace apiHelloWorld.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // origem -> destino
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}