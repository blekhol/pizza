using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    internal class Rendeles
    {
        private int id;
        private Pizza pizza;
        private int db;
        private Cim cim;
        private TimeSpan ido;

        public Rendeles(int id, Pizza pizza, int db, Cim cim, TimeSpan ido)
        {
            this.id = id;
            this.pizza = pizza;
            this.db = db;
            this.cim = cim;
            this.ido = ido;
        }

        public int Id { get => id; set => id = value; }
        public int Db { get => db; set => db = value; }
        public TimeSpan Ido { get => ido; set => ido = value; }
        internal Pizza Pizza { get => pizza; set => pizza = value; }
        internal Cim Cim { get => cim; set => cim = value; }

        public override string ToString()
        {
            return $"{pizza} {db} {cim} {ido}";
        }
    }
}
