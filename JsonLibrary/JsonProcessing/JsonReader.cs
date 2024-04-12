using System.Text.Json;
using JsonLibrary;

namespace JsonLibrary
{
    public class JsonReader
    {
        /// <summary>
        /// Статических метод для получения List объектов Widget.
        /// </summary>
        /// <returns></returns>
        public static List<Widget> DeserializeWidgets()
        {
            List<Widget> widgets = new List<Widget>();
            while (true)
            {
                try
                {
                    string fPath = Reading.GetPath(); // Получаем ссылку на файл и пробуем его открыть.
                    string json = File.ReadAllText(fPath);
                    widgets = JsonSerializer.Deserialize<List<Widget>>(json);
                    if (widgets == null) { throw new Exception(); }
                    foreach (Widget w in widgets)
                    {
                        if (w.widgetId == null || w == null) { throw new ArgumentException(); }
                    }
                    break;
                }
                catch (JsonException ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка при десериализации JSON!");
                    Console.ResetColor();
                }
                catch (ArgumentException ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Неверный формат json-файла!");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Неизвестная ошибка!");
                    Console.ResetColor();
                }
            }
            return widgets;
        }
    }
}
