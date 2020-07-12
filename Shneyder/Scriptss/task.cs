using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Shneyder.Sscripts
{
    class task
    {
        static public Thread th = new Thread(close);
        static public string dictionary,db;
        static public DataTable dt = new DataTable();
        static public string key;
        static public void words()
        {
            th.Start();
            key = null;
            Console.Clear();
            Console.WriteLine("Тестовое задание \r\n");
            Here:
            Console.WriteLine("Введите '3' чтобы выйти в главное меню или ESС для закрытия \r\n");
            Console.Write("Введите слова от 3-х до 15 символов:");
         
            dictionary = Console.ReadLine();
            
            dictionary = dictionary.Split(" ")[0];
            if (dictionary == "3" || dictionary==null )
               MainMenu.maiMenu();

            if (dictionary.Length >= 3 && dictionary.Length<15) 
            { 

                if (Regex.IsMatch(dictionary, "^[А-Яа-я]+$"))
                {
                    db = "try";
                    RU_EN();

                    goto Here;
                }
                else
                {
                    db = "tryEN";
                    RU_EN();
                    goto Here;
                }


                   
            }
            else
            {
                Console.WriteLine("Вы вели меньше 3 или больше 15 букв ");
                goto Here;
            }
        }



        static public void RU_EN()
        {
            dt.Clear();
            string g,s;
            string sqlRU = "SELECT TOP (5) * FROM "+db+" where Words LIKE '"+dictionary+"%'";
            int y=0;

            using (MySqlConnection connection = new MySqlConnection(MainMenu.server))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlRU, connection);
                adapter.Fill(dt);
                connection.Close();
            }
       


            if (dt.Rows.Count==0)
            {
                Console.WriteLine("Слова не найдены, попробуйте добавить больше слов.");
            }

            else 
            {
                if (db == "try")
                { 
                    for(y = 0; y < dt.Rows.Count; y++)
                    {
                        g = dt.Rows[y][0].ToString();
                        y++;
                        Console.Write(y+".");
                        y--;
                        Console.WriteLine(g);
                    }
                    if (y < 5)
                    {
                        for( y = dt.Rows.Count; y < 5; y++ )
                        {
                            Console.WriteLine(y + ". Количество найденых слов не равно 5 добавьте больше слов.");
                        }
                    }
                }
                else
                {
                    for (y = 0; y < dt.Rows.Count; y++)
                    {
                        g = dt.Rows[y][0].ToString();
                        s = dt.Rows[y][1].ToString();
                        y++;
                        Console.Write(y + ".");
                        y--;
                        Console.WriteLine(g+" "+s );
                    }
                    if (y < 5)
                    {
                        for (y = dt.Rows.Count; y < 5; y++)
                        {
                            Console.WriteLine(y + ". Количество найденых слов не равно 5 добавьте больше слов.");
                        }
                    }
                }
            }



        }

      static public void close()
        {
            while(true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
              
                    Environment.Exit(0);
                    break;
                }
              
            }
        }
        

    }
}
