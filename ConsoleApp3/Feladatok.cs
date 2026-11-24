using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    internal class Feladatok
    {
        List<Rendeles> lista = [];

        public Feladatok()
        {
            Adatbazis db = new Adatbazis();
            lista = db.Feltolt();
        }

        private void El()
        {
            Console.WriteLine("============================");
        }

        public void f3()
        {
            var asd = lista.Select(a => a.Pizza).Distinct().Where(p => p.Ar < 1500).OrderByDescending(p => p.Meret).ThenBy(p => p.Nev);
            foreach (var p in asd)
            {
                Console.WriteLine($"{p.Nev}: {p.Meret} - {p.Ar}");
            }
            El();
        }

        public void f4()
        {
            var asd = lista.GroupBy(r => r.Pizza);
            int max = 0;
            Pizza maxPizza;
            foreach (var rendelesek in asd)
            {
                if (rendelesek.Sum(r => r.Db) > max)
                {
                    max = rendelesek.Sum(r => r.Db);
                }
            }
        }
    }
}