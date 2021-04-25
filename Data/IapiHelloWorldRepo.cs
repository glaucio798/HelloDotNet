using System.Collections.Generic;
using apiHelloWorld.Models;

namespace apiHelloWorld.Data
{
    public interface IapiHelloWorldRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}