using CommandPattern.CommandPattern.Interface;
using CommandPattern.CommandPattern.Model;
using CommandPattern.CommandPattern.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.CommandPattern.ConcreteCommand
{
    internal class RemoveToDoCommand : IToDoCommand
    {
        List<ToDo> _toDoListDeleted;
        ToDoManager _toDoManager;
        ToDo _todoDeleted;

        public RemoveToDoCommand(ToDoManager toDoManager, List<ToDo> toDoListDeleted , ToDo toDoDeleted)
        {
            _toDoManager = toDoManager;
            _toDoListDeleted = toDoListDeleted;
            _todoDeleted = toDoDeleted;
        }

        public void Execute(ToDo pToDo)
        {
            _toDoListDeleted.Remove(pToDo);
            _toDoManager.RemoveToDoMessage();
        }

        public void Undo()
        {
            _toDoListDeleted.Add(_todoDeleted);
            _toDoManager.RemoveToDoMessage();
        }
    }
}
