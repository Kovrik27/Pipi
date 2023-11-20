using System.Text.RegularExpressions;

namespace ConsoleApp10
{
    class Program
    {
        public static void Main()
        {
            CommandManager commandManager = new CommandManager();
            CommandInvoker commandInvoker = new CommandInvoker(commandManager);
            PodarokDB podarokDB = new PodarokDB();
            commandManager.RegisterCommand("Create", "Создание", new CommandCreatePodarok(podarokDB));
            commandManager.RegisterCommand("Search", "Поиск", new CommandSearchPodarok(podarokDB));
            commandManager.RegisterCommand("Delete", "Удаление", new CommandDeletePodarok(podarokDB));
            commandManager.RegisterCommand("Edit", "Редактирование", new CommandEditPodarok(podarokDB));
            
            commandInvoker.Start();
        }

    }
}