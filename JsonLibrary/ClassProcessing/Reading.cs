using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonLibrary
{
    /// <summary>
    /// Статический класс с методами для чтения файла.
    /// </summary>
    public static class Reading
    {
        public static string GetPath() // Пытаемся получить ссылку на открывающийся и существующий JSON файл.
        {
            string path;
            Console.Write("Введите полный путь к JSON файлу: ");
            do
            {
                path = Console.ReadLine();
                try
                {
                    using (var stream = new FileStream(path, FileMode.Open))
                    {
                        if (stream.Length == 0)
                        {
                            throw new FileNotFoundException($"Файл \"{path}\" не существует.");
                        }

                        if (!path.EndsWith(".json"))
                        {
                            throw new ArgumentException($"Файл \"{path}\" не является JSON-файлом.");
                        }
                        if (path == null)
                        {
                            throw new ArgumentNullException();
                        }
                    }
                    break;
                }
                catch (ArgumentNullException e)
                {
                    Console.Write("Передан пустой путь! Повторите попытку: ");
                }
                catch (FileNotFoundException e)
                {
                    Console.Write("Файл по данному пути не найден! Повторите попытку: ");
                }
                catch (IOException e)
                {
                    Console.Write("Ошибка в открытиии и чтении файла! Повторите попытку: ");
                }
                catch (Exception e)
                {
                    Console.Write("Непредвиденная ошибка в чтении файла! Повторите попытку: ");
                }
            } while (true);
            return path;
        }
    }
}
