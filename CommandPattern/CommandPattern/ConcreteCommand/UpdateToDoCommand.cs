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
    internal class UpdateToDoCommand : IToDoCommand
    {
        ToDo _OldToDo;
        ToDo _newToDo;
        ToDoManager _toDoManager;

        public UpdateToDoCommand(ToDoManager toDoManager , ToDo newToDo , ToDo oldToDo)
        {
            _toDoManager = toDoManager;
            _newToDo = newToDo;
            _OldToDo = oldToDo;
        }
        public void Execute(ToDo pToDo)
        {
            _OldToDo.Title = _newToDo.Title;
            _toDoManager.UpdateToDOMessage(pToDo);
        }

        public void Undo()
        {

            _OldToDo.Title = _newToDo.Title;
            _toDoManager.RemoveToDoMessage();
        }
    }
}
