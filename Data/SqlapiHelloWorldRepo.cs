using System;
using System.Collections.Generic;
using System.Linq;
using apiHelloWorld.Models;

namespace apiHelloWorld.Data
{
    public class SqlapiHelloWorldRepo : IapiHelloWorldRepo
    {
        private readonly apiHelloWorldContext _context;

        public SqlapiHelloWorldRepo(apiHelloWorldContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            _context.Commands.Add(cmd);
        }

        public void UpdateCommand(Command cmd)
        {
            _context.Commands.Update(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            _context.Commands.Remove(cmd);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}