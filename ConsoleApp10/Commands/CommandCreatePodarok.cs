using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CommandCreatePodarok : UserCommand
{
    private PodarokDB podarokDB;

    public CommandCreatePodarok(PodarokDB podarokDB)
    {
        this.podarokDB = podarokDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Создание подарка...");
        Podarok newPodarok = podarokDB.Create();
        Console.WriteLine("Укажите раздел...");
        newPodarok.Razdel = Console.ReadLine();
        Console.WriteLine("Укажите название...");
        newPodarok.Name = Console.ReadLine();
        Console.WriteLine("Укажите цену...");
        newPodarok.Price = Console.ReadLine();
        
        if (podarokDB.Update(newPodarok))
            Console.WriteLine("Подарок создан!!");
        else
            Console.WriteLine("ПОДАРКА НЕТ В НАЛИЧИИ. ТЫ ИДИОТ!>:(");
    }
}


