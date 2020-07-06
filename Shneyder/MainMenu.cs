using System;
using System.Collections.Generic;
using System.Text;
using Shneyder.scripts;

namespace Shneyder
{
    class MainMenu
    {
        static public string name;
        static public int Answer;


        static public void maiMenu()
        {
            Console.Clear();

            Console.WriteLine("Тестовое задание" + "\r\n");

            Console.WriteLine("1. Подключиться к серверу" + name);
            Console.WriteLine("2. Изменить сервер");
            Console.WriteLine("3. Новый сервер");
            Console.WriteLine("4. Удалить сервер" + "\r\n");
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

            if (Answer > 4 || Answer < 1)
            {
                Console.WriteLine("Нету таких пунктов");
                goto Begin;
            }


            switch (Answer)
            {

                case 1:
                    {

                        break;
                    }

                case 2:
                    {

                        break;
                    }

                case 3:
                    {
                        NewServer.server();
                        break;
                    }

                case 4:
                    {

                        break;
                    }

            }

        }
    }
}
