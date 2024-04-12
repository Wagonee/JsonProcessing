using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonLibrary
{
    /// <summary>
    /// Класс, отвечающий за сохранение в файл в течение 15 секунд 
    /// </summary>
    public class AutoSaver
    {
        List<Widget> _widgets;
        DateTime _lastUpdateTime;
        string _filePath;
        public AutoSaver(List<Widget> widgets, string filePath)
        {
            _widgets = widgets;
            _filePath = filePath;
            foreach (Widget widget in widgets)
            {
                widget.Updated += WidgetUpdated; // Подписываемся на уведомления (жмём колокольчик).
            }
        }
        void WidgetUpdated(object? sender, EventArgs e) // Метод обработчик события.
        {
            {
                if (_lastUpdateTime != null && (DateTime.Now - _lastUpdateTime).TotalSeconds <= 15)
                {
                    SaveToFile();
                }
                _lastUpdateTime = DateTime.Now;
            }
        }
        void SaveToFile() // Метод, сохраняющий JSON-файл.
        {
            try
            {
                string tmpFilePath = Path.GetFileNameWithoutExtension(_filePath) + "_tmp.json";
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string json = JsonSerializer.Serialize(_widgets, options);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Сохранение прошло успешно! Путь к файлу: {Path.GetFullPath(tmpFilePath)}");
                Console.ResetColor();
                File.WriteAllText(tmpFilePath, json);
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); } 
        }
    }
}
