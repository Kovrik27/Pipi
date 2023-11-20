using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CommandEditPodarok : UserCommand
{
    private PodarokDB podarokDB;

    public CommandEditPodarok(PodarokDB podarokDB)
    {
        this.podarokDB = podarokDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск подарка...");
        List<Podarok> podarki = podarokDB.Search("");
        for (int i = 0; i < podarki.Count; i++)
        {
            Console.WriteLine($"{i + 1}).{podarki[i].Razdel} {podarki[i].Name} {podarki[i].Price}");

            Console.WriteLine("Укажите порядковый номер...");
            int.TryParse(Console.ReadLine(), out int edit);
            if (podarki.Count > edit - 1)
            {
                Console.WriteLine("Измените раздел...");
                podarki[i].Razdel = Console.ReadLine();
                Console.WriteLine("Измените название...");
                podarki[i].Name = Console.ReadLine();
                Console.WriteLine("Измените цену...");
                podarki[i].Price = Console.ReadLine();
                if (podarokDB.Update(podarki[i]))
                    Console.WriteLine("Подарок отредачен!");
                else
                    Console.WriteLine("Подарок НЕ отредачен >:(");
            }
        }


    }
}
