using Tantargy.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Tantargy
{
    public class Program
    {
        public static Connect conn = new Connect();
        public static List<Tantargy> tantargyak = new List<Tantargy>();

        static void feltolt()
        {
            conn.Connection.Open();
            string sql = "SELECT * FROM `cars`";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            do
            {
                Tantargy car = new Tantargy();
                car.Id = reader.GetInt32(0);
                car.Brand = reader.GetString(1);
                car.Type = reader.GetString(2);
                car.License = reader.GetString(3);
                car.Date = reader.GetInt32(4);
                tantargyak.Add(Tantargy);
            } while (reader.Read());


            conn.Connection.Close();
        }

        public static void addNewCar()
        {
            conn.Connection.Open();
            string brand, type, license;
            int date;

            Console.Write("Kérem az autó márkáját: ");
            brand = Console.ReadLine();
            Console.Write("Kérem az autó típusát: ");
            type = Console.ReadLine();
            Console.Write("Kérem az autó motorszámát: ");
            license = Console.ReadLine();
            Console.Write("Kérem az autó gyártási évét: ");
            date = int.Parse(Console.ReadLine());

            string sql = $"INSERT INTO `cars`(`Brand`, `Type`, `License`, `Date`) VALUES ('{brand}','{type}','{license}',{date})";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.ExecuteNonQuery();

            conn.Connection.Close();

        }

        public static void upDateCar()
        {
            conn.Connection.Open();

            int id, date;

            Console.Write("Kérem az autó azonosítóját: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Kérem az autó gyártási évét: ");
            date = int.Parse(Console.ReadLine());

            string sql = $"UPDATE `cars` SET `Date`={date} WHERE Id={id}";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.ExecuteNonQuery();

            conn.Connection.Close();
        }

        public static void deleteCar()
        {
            conn.Connection.Open();

            int id;

            Console.Write("Kérem az autó azonosítóját: ");
            id = int.Parse(Console.ReadLine());

            string sql = $"DELETE FROM `cars` WHERE `Id`={id}";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.ExecuteNonQuery();

            conn.Connection.Close();
        }

        public static void Main(string[] args)
        {
            deleteCar();
        }
    }
}
