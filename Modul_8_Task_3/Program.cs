using System;
using System.IO;


namespace Modul_8_Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите полный адрес для папки");
            string sourceDirectory = Console.ReadLine();
            if (Directory.Exists(sourceDirectory))
            {
                var di = new DirectoryInfo(sourceDirectory);
                Console.WriteLine("Исходный размер папки :" + DirSize(di));
                foreach (FileInfo file in di.GetFiles())
                {
                    if ((DateTime.Now - file.LastAccessTime) > TimeSpan.FromMinutes(30))
                    {
                        file.Delete();
                        Console.WriteLine("Файл {0} удалён", file.Name);
                    }
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    if ((DateTime.Now - dir.LastAccessTime) > TimeSpan.FromMinutes(30))
                    {
                        dir.Delete(true);
                        Console.WriteLine("Папка {0} удалена", dir.Name);
                    }
                }
                Console.WriteLine("Размер папки после очистки :" + DirSize(di));
            }
            else
            {
                Console.WriteLine("Папка не найдена. \nВведите корректный адрес папки");
            }
        }
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }

            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }
    }
}