using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonLibrary;

namespace UiTools
{
    /// <summary>
    /// Статический класс с методами для человеко-читаемого вывода информации об объектах.
    /// </summary>
    public static class OutputTools
    {
        /// <summary>
        /// Метод выводящий объекты SpeakingEvents в табличном, человеко-читаемом виде.
        /// </summary>
        /// <param name="events"></param>
        public static void Output(List<Widget> widgets)
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            string stick = "_______________________________________________________________________________________________________________________________";
            sb.Append($"{"ID",-42}||{"Name",-25}||{"Quantity",-20}||{"Price",-20}||{"Man-d date"}||\n");
            foreach (Widget w in widgets)
            {
                sb.Append(stick + '\n');
                sb.Append($"||{w.widgetId,-40}||{w.name,-25}||{w.quantity,-20}||{w.price,-20:0.00}||{w.manufactureDate:d}||\n");
            }
            Console.WriteLine(sb.ToString());
        }
        /// <summary>
        /// Метод, выводящий справку на экран.
        /// </summary>
        public static void WriteHelp() 
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Сохранения работают в режиме AutoSave (т. е. при изменении какого либо поля в течение 15 секунд) в папку с исполнимым файлом.");
            Console.ResetColor();
        }
    }
}
