using CommandPattern.CommandPattern.ConcreteCommand;
using CommandPattern.CommandPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.CommandPattern.Receiver
{
    internal class ToDoManager
    {
       

        public void AddToDOMessage(ToDo pToDo)
        {
            Console.WriteLine("Adding Todo No#: " + pToDo.Id + " Title: " + pToDo.Title);
        }

        public void UpdateToDOMessage(ToDo pToDo)
        {
            Console.WriteLine("Updating Todo No#: " + pToDo.Id + " New Description: " + pToDo.Title);
        }

        public void RemoveToDoMessage() 
        {
            Console.WriteLine("Reverting Changes");
        }
    }
}
