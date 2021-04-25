using System.Collections.Generic;
using apiHelloWorld.Models;

namespace apiHelloWorld.Data
{
    public class MockapiHelloWorldRepo : IapiHelloWorldRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
            new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Plataform = "Panelinha" },
            new Command { Id = 1, HowTo = "Cut bread", Line = "Get a knife", Plataform = "Table" },
            new Command { Id = 2, HowTo = "Eat", Line = "Bite", Plataform = "Mouth" }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = id, HowTo = "Boil2 an egg", Line = "Boil water", Plataform = "Panelinha" };
        }

        public void UpdateCommand(Command cmd)
        {

        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}