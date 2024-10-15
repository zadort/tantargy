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

            Console.Write("K�rem az aut� m�rk�j�t: ");
            brand = Console.ReadLine();
            Console.Write("K�rem az aut� t�pus�t: ");
            type = Console.ReadLine();
            Console.Write("K�rem az aut� motorsz�m�t: ");
            license = Console.ReadLine();
            Console.Write("K�rem az aut� gy�rt�si �v�t: ");
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

            Console.Write("K�rem az aut� azonos�t�j�t: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("K�rem az aut� gy�rt�si �v�t: ");
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

            Console.Write("K�rem az aut� azonos�t�j�t: ");
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
