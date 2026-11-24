using System;
using System.Collections.Generic;
using System.Text;
using MySql;
using MySql.Data.MySqlClient;

namespace ConsoleApp3
{
    internal class Adatbazis
    {
        private readonly string connectionstring;

        public Adatbazis()
        {
            connectionstring = "server=localhost;database=pizzafutár;uid=root;pwd=";
        }

        public List<Rendeles> Feltolt()
        {
            List<Rendeles> lista = [];
            Dictionary<int, Pizza> pizzak = [];
            Dictionary<int, Cim> cimek = [];
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionstring))
                {
                    conn.Open();
                    string query = "SELECT * FROM pizza";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Pizza p = new Pizza(
                                    reader.GetInt32("id"),
                                    reader.GetString("nev"),
                                    reader.GetInt32("meret"),
                                    reader.GetInt32("ar")
                                );
                                pizzak[p.Id] = p;
                            }
                        }
                    }
                    query = "SELECT * FROM cim";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Cim c = new Cim(
                                    reader.GetInt32("id"),
                                    reader.GetString("nev"),
                                    reader.GetString("utca"),
                                    reader.GetString("hsz")
                                );
                                cimek[c.Id] = c;
                            }
                        }
                    }
                    query = "SELECT * FROM rendeles";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Rendeles r = new Rendeles(
                                    reader.GetInt32("id"),
                                    pizzak[reader.GetInt32("pizzaid")],
                                    reader.GetInt32("darab"),
                                    cimek[reader.GetInt32("cimid")],
                                    reader.GetTimeSpan("szallitas")
                                );

                                lista.Add(r);
                            }
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

            return lista;
        }
    }
}
