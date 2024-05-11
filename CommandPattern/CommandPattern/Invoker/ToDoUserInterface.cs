using CommandPattern.CommandPattern.Interface;
using CommandPattern.CommandPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.CommandPattern.Invoker
{
    internal class ToDoUserInterface
    {

        Stack<IToDoCommand> _historyCommandToDo = new  Stack<IToDoCommand>();
        IToDoCommand _toDoCommand;

       
        public void setCommand(IToDoCommand toDoCommand)
        {
            _toDoCommand = toDoCommand;
        }

 
 
        public void Execute(ToDo pToDo)
        {  

                _toDoCommand.Execute(pToDo);
                _historyCommandToDo.Push(_toDoCommand);
            
       
        }

        public void Undo() 
        {
            IToDoCommand lastCommandExecuted = _historyCommandToDo.Pop();
            lastCommandExecuted.Undo();
        
        }
            
   
            
    }
}
