using CommandPattern.CommandPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.CommandPattern.Interface
{
    internal interface IToDoCommand
    {
        void Execute(ToDo pToDo);

        void Undo();
    }
}
