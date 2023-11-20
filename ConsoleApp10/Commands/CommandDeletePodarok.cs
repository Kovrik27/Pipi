using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

{
    class CommandDeletePodarok : UserCommand
    {
        private PodarokDB podarokDB;

        public CommandDeletePodarok(PodarokDB podarokDB)
        {
            this.podarokDB = podarokDB;
        }

        public override void Execute()
        {
            Console.WriteLine("Поиск подарка...");
            List<Podarok> podarki = podarokDB.Search("");
            for (int i = 0; i < podarki.Count; i++)
                Console.WriteLine($"{i + 1}).{podarki[i].Razdel} {podarki[i].Name} {podarki[i].Price}");

            Console.WriteLine("Укажите порядковый номер...");
            int.TryParse(Console.ReadLine(), out int nomer);
            if (podarki.Count > nomer - 1 && podarokDB.Delete(podarki[nomer - 1]))
                Console.WriteLine("Подарок успешно выкинут!");
            else
                Console.WriteLine("Не удалось выкинуть подарок:(");

        }
    }
}
