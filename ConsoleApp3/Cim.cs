using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    internal class Cim
    {
        private int id;
        private string nev;
        private string utca;
        private string hsz;

        public Cim(int id, string nev, string utca, string hsz)
        {
            this.id = id;
            this.nev = nev;
            this.utca = utca;
            this.hsz = hsz;
        }

        public int Id { get => id; set => id = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Utca { get => utca; set => utca = value; }
        public string Hsz { get => hsz; set => hsz = value; }

        public override string ToString()
        {
            return $"{nev} {utca} {hsz}";
        }
    }
}
