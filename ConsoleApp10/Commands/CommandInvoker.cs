using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

class CommandInvoker
{ 
    CommandManager commandManager;

    public CommandInvoker(CommandManager commandManager)
    {
        this.commandManager = commandManager;
    }
    public void Start()
    {
        string descr;
        do
        {
            Console.WriteLine("Введите команду");
            descr = Console.ReadLine();
            if (descr == "help")
                commandManager.ListCommand();
            else
                commandManager.Execute(descr);
        }
        while (descr != "exit");

    }
}
