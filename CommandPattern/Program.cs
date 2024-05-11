
using CommandPattern.CommandPattern.ConcreteCommand;
using CommandPattern.CommandPattern.Interface;
using CommandPattern.CommandPattern.Invoker;
using CommandPattern.CommandPattern.Model;
using CommandPattern.CommandPattern.Receiver;
using System.Runtime.CompilerServices;
using System.Windows.Input;

List<ToDo> toDos = new List<ToDo>();
ToDoManager toDoManager = new ToDoManager();

ToDoUserInterface toDoUserInterface = new ToDoUserInterface();



MainApp();




void MainApp ()
{

    int optionChoosed = 0;
  
  
     while (optionChoosed != 4)
    {
        Menu();
        optionChoosed = int.Parse(Console.ReadLine());
        switch (optionChoosed)
        {
            case 1:
                createNewToDo();
        
                break;
            case 2:
                updateToDo();
                break;

            case 3:
                deleteToDo();
                break;
            case 4:
                Console.Write("GoodBye !!!");
                break;
            case 5:
                undoLastChanged();
                break;
        }
    }

    
    

}



void updateToDo()
{
    
    Console.WriteLine("Please wrirte ToDo's Id that you want to edit:  \n");
    int id = int.Parse(Console.ReadLine().ToString().Trim());
 
    ToDo CurrentToDo = toDos.FirstOrDefault(toDo => toDo.Id == id);
   
    if (CurrentToDo is not null)
    {
        var newToDo = CurrentToDo;
        Console.WriteLine("Please wrirte the new ToDo title:  \n");
        string newTitle = Console.ReadLine().ToString().Trim();
        newToDo.Title = newTitle;
        IToDoCommand updateToDoCommand = new UpdateToDoCommand(toDoManager, newToDo, CurrentToDo);
        toDoUserInterface.setCommand(updateToDoCommand);


        toDoUserInterface.Execute(newToDo);
    }
    else
    {
        Console.WriteLine("ToDo doesn't exists , please verify your ToDo Id");
    }
}
void deleteToDo()
{
    Console.WriteLine("Please wrirte Task's Id that you want to delete:  \n");
    int id = int.Parse(Console.ReadLine().ToString().Trim());
    
    ToDo toDo = toDos.FirstOrDefault(toDo => toDo.Id == id);
    if(toDo is not null)
    {
        IToDoCommand removeToDoCommand = new RemoveToDoCommand(toDoManager, toDos , toDo);
        toDoUserInterface.setCommand(removeToDoCommand);
        toDoUserInterface.Execute(toDo);
    }else
    {
        Console.WriteLine("ToDo doesn't exists , please verify your ToDo Id");
    }
}
void createNewToDo(){

    Console.WriteLine("Please write a subject to your new Task:  ");
    string title = Console.ReadLine();
   
    int lenghtToDos = toDos.Count;
    if (!string.IsNullOrEmpty(title)) {

        IToDoCommand addToDoCommand = new AddToDoCommand(toDoManager, toDos);
        toDoUserInterface.setCommand(addToDoCommand);
        toDoUserInterface.Execute(new ToDo() { Id = lenghtToDos += 1, Title = title });
    
    }

}

void undoLastChanged()
{
    toDoUserInterface.Undo();
}
void Menu()
{
    Console.WriteLine("------------------------------ToDo App---------------------------------\n");
    showMyCurrentTasks();
    Console.WriteLine("What Do you want to Do? \n 1-Create new Task \n 2-Update one Task \n 3-Delete One Task \n 4-Exit \n 5-Undo Last Changed");
    Console.WriteLine("Please select one...");

}
void showMyCurrentTasks()
{
    if(toDos.Count() == 0)
    {
        Console.WriteLine($"-------------------- YOU DON'T HAVE TASK :( ------------------------ \n");
    }
    else
    {
        Console.WriteLine($"-------------------- MY TASKS :) ------------------------");
        foreach (var toDo in toDos)
        {
            Console.WriteLine($"Todo '{toDo.Id}'  Description : '{toDo.Title}'\n");
        }

    }
}
