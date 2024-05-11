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
    internal class AddToDoCommand : IToDoCommand
    {
        List<ToDo> _toDoListAdd;
        ToDoManager _toDoManager;

        public AddToDoCommand(ToDoManager toDoManager, List<ToDo> listToDos )
        { 
            _toDoManager = toDoManager;
            _toDoListAdd = listToDos;
        }
        public void Execute(ToDo pToDo)
        {
            _toDoListAdd.Add( pToDo );
            _toDoManager.AddToDOMessage(pToDo);
        }

        public void Undo()
        {
            _toDoListAdd.RemoveAt(_toDoListAdd.Count - 1);
            _toDoManager.RemoveToDoMessage();
        }
    }
}
