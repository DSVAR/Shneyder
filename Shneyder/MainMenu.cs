using MySql.Data.MySqlClient;
using Shneyder.Sscripts;
using System;
using System.Collections.Generic;
using System.Text;


namespace Shneyder
{
    class MainMenu
    {
       
        static public int Answer;
        static public string server = @"server=server197.hosting.reg.ru; user=u1027450_reo; database=u1027450_neo; password=kawabanga1; charset=utf8";

        static public void maiMenu()
        {

            using (MySqlConnection connection=new MySqlConnection(server))
            {
                connection.Open();
                connection.Close();
            }
            Console.Clear();

            Console.WriteLine("Тестовое задание" + "\r\n");

            Console.WriteLine("1. Задание");
            Console.WriteLine("2. Добавить слова ");
            Console.WriteLine("3. Очистить базу" + "\r\n");
        Begin:
            Console.Write("Ведите число:");
            try
            {
                Answer = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Строка имела не правильный вод");
                goto Begin;
            }

            if (Answer > 3 || Answer < 1)
            {
                Console.WriteLine("Нету таких пунктов");
                goto Begin;
            }


            switch (Answer)
            {

                case 1:
                    {
                        task.words();
                        break;
                    }

                case 2:
                    {
                        AddItem.add();
                        break;
                    }

                case 3:
                    {
                        ClearBD.delet();
                        break;
                    }

        

            }

        }
    }
}
