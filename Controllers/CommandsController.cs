using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using apiHelloWorld.Models;
using apiHelloWorld.Data;
using AutoMapper;
using apiHelloWorld.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace apiHelloWorld.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IapiHelloWorldRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(IapiHelloWorldRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if (commandItem != null)
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandCreateDto> CreateCommand(CommandCreateDto cmd)
        {
            var commandModel = _mapper.Map<Command>(cmd);

            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var CommandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { id = CommandReadDto.Id }, CommandReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto cmd)
        {
            var commandItem = _repository.GetCommandById(id);

            if (commandItem == null)
                return NotFound();

            _mapper.Map(cmd, commandItem);

            _repository.UpdateCommand(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var commandItem = _repository.GetCommandById(id);

            if (commandItem == null)
                return NotFound();

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandItem);
            patchDocument.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(commandToPatch, commandItem);

            _repository.UpdateCommand(commandItem);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult commandDelete(int id)
        {
            var commandToDelete = _repository.GetCommandById(id);

            if (commandToDelete == null)
                return NotFound();

            _repository.DeleteCommand(commandToDelete);

            _repository.SaveChanges();

            return NoContent();

        }
    }
}