using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CommandSearchPodarok : UserCommand
{
    private PodarokDB podarokDB;

    public CommandSearchPodarok(PodarokDB podarokDB)
    {
        this.podarokDB = podarokDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск подарка...");
        List<Podarok> podarki = podarokDB.Search(Console.ReadLine());
        for (int i = 0; i < podarki.Count; i++)
            Console.WriteLine($"{i + 1}).{podarki[i].Razdel} {podarki[i].Name} {podarki[i].Price}");


    }
}
