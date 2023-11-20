using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class PodarokDB
{
    List<Podarok> podarki;

    public PodarokDB()
    {
        //load file (json)
        if (!File.Exists("podarok.json"))
            podarki = new List<Podarok>();
        else
            using (FileStream fs = new FileStream("podarki.json", FileMode.OpenOrCreate))
            {
                podarki = JsonSerializer.Deserialize<List<Podarok>>(fs);
            }

    }

    public List<Podarok> Search(string text)
    {
        List<Podarok> result = new();
        foreach (var podarok in podarki)
        {
            if (podarok.Name.Contains(text))

                result.Add(podarok);
        }
        return result;
    }

    public bool Update(Podarok podarok)
    {
        if (podarki.Contains(podarok))
            Save();
        else
            return false;
        return true;
    }

    public Podarok Create()
    {
        Podarok newPodarok = new Podarok { };
        podarki.Add(newPodarok);
        return newPodarok;
    }

    public bool Delete(Podarok podarok)
    {
        podarki.Remove(podarok);
        Save();
        return true;
    }

    void Save()
    {
        //save file (json)
        using (FileStream fs = new FileStream("podarok.json", FileMode.Open))
        {
            JsonSerializer.Serialize(fs, podarki);
        }
    }
}
