using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace Shneyder.scripts
{
    class NewServer
    {
        static public string serverName, UserName, DataBase, Password,TableName, connection;
        static public DataTable dt=new DataTable();
        static public string path =Environment.CurrentDirectory + @"\Servers\";

        static public void server()
        {
            Console.Clear();
           
        Arbah:
            Console.WriteLine("Добавление сервера.");

            Console.WriteLine(""+"\r\n");

            Console.Write("Имя или IP сервера:");

        
            serverName = Console.ReadLine()+"; ";
            Console.WriteLine("");
            Console.Write("Имя пользователя:");
            UserName = Console.ReadLine() + "; ";
            Console.WriteLine("");
            Console.Write("Имя Базы данных:");
            DataBase = Console.ReadLine() + "; ";
            Console.WriteLine("");
            Console.Write("Пароль:");
            Password = Console.ReadLine() + "; ";
            Console.WriteLine("");
            Console.Write("Имя таблицы:");
            TableName = Console.ReadLine() ;


            Console.WriteLine("");

            connection = @"server="+serverName+"user="+UserName+"database="+DataBase+"password="+Password+"charset=utf8";

            string sql = "SELECT * FROM " + TableName;
            try
            {
                dt.Clear();
                using (MySqlConnection connecting = new MySqlConnection(connection))
                {
                    connecting.Open();
                    MySqlDataAdapter adap = new MySqlDataAdapter(sql, connecting);
                    adap.Fill(dt);

                    connecting.Close();
                }

                Console.WriteLine("ЕСТЬ подключение.");
                AddFiles();
            }
            catch
            {
                Console.WriteLine("Проверьте соеденение с интернетом или введенные данные");
                goto Arbah;
            }

        }

        static public void AddFiles()
        {
            string pathANDname = path + serverName+".txt";
            string nameFolder = "Servers";

            bool ex = Directory.Exists(path);
            DirectoryInfo DI = new DirectoryInfo(path);
            if (ex == false)
            {
                DI.CreateSubdirectory(nameFolder);
                File.AppendAllText(pathANDname, connection);
            }
            else {
                File.AppendAllText(pathANDname, connection);
            }
          
        }

    }
}
