using System;
using System.IO;
using System.Text;

namespace Lab_8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path_d = "D:\\Lab_8_1";
            void Copy(string path1, string path2)
            {
                try
                {
                    if ((!Directory.Exists(path1) || !Directory.Exists(path2)) || (!Directory.Exists(path1) && !Directory.Exists(path2)))
                    {
                        Console.WriteLine($"Не iснує потрiбних каталогів!!!");
                    }
                    else
                    {
                        DirectoryInfo dirinf1 = new DirectoryInfo(path1);
                        DirectoryInfo dirinf2 = new DirectoryInfo(path2);
                        string name = dirinf1.Name;
                        Directory.CreateDirectory(path2 + $"\\{name}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            void Moving(string path1, string path2)
            {
                try
                {
                    if (!Directory.Exists(path1))
                    {
                        Console.WriteLine($"Не iснує потрiбних каталогів!!!");
                    }
                    else
                    {
                        DirectoryInfo dirinf = new DirectoryInfo(path2);

                        if (dirinf.Exists)
                        {
                            dirinf.Delete(true);
                        }
                        new DirectoryInfo(path1).MoveTo(path2);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            try
            {
                Directory.CreateDirectory(path_d);
                Directory.CreateDirectory(path_d + "\\KN1-B20");
                Directory.CreateDirectory(path_d + "\\Matraieva");
                Directory.CreateDirectory(path_d + "\\Sources");
                Directory.CreateDirectory(path_d + "\\Reports");
                Directory.CreateDirectory(path_d + "\\Texts");
                Copy(path_d + "\\Texts", path_d + "\\Matraieva");
                Copy(path_d + "\\Sources", path_d + "\\Matraieva");
                Copy(path_d + "\\Reports", path_d + "\\Matraieva");
                Moving(path_d + "\\Matraieva", path_d + "\\KN1-B20");
                if (!File.Exists(path_d + "\\Texts\\dirinfo.txt"))
                {
                    File.Create(path_d + "\\Texts\\dirinfo.txt");
                }
                if (File.Exists(path_d + "\\Texts\\dirinfo.txt") == true)
                {
                    string dirName = "path_d" + "\\Texts";
                    DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                    string text = $"Назва каталогу: {dirInfo.Name}\nРозташування каталогу: {dirInfo.FullName}\nЧас створення каталогу: {dirInfo.CreationTimeUtc}\nКореневий каталог: {dirInfo.Root}";
                    using (FileStream fstream = new FileStream(path_d + "\\Texts\\dirinfo.txt", FileMode.Create))
                    {
                        byte[] array = Encoding.Default.GetBytes(text);
                        fstream.Write(array, 0, array.Length);
                    }
                    using (FileStream fstream = File.OpenRead(path_d + "\\Texts\\dirinfo.txt"))
                    {
                        byte[] array = new byte[fstream.Length];
                        fstream.Read(array, 0, array.Length);
                        text = Encoding.Default.GetString(array);
                    }
                    Console.WriteLine($"У файлi dirinfo.txt записано таке:\n{text}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
