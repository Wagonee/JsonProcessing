using System.Reflection;
using JsonLibrary;
using UiTools;

namespace HW_3_2_Ponomarev_var_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] menuPuncts = new string[] { "Сортировка по одному из полей",  "Выбор объекта для редактирования", "Ввод пути к новому файлу", "Выход из программы"};
            Console.WriteLine("От создателя AeroexpressProcessing! Добро пожаловать в WiddgetProcessing! Теперь с новым меню.");
            OutputTools.WriteHelp(); // Выводим справку для пользователя.
            List<Widget> widgets = JsonReader.DeserializeWidgets(); // Десериализируем json-файл в List объектов класса Widget.
            AutoSaver autoSaver = new(widgets, "3V.json"); // Подключаем AutoSave.
            foreach (Widget widget in widgets) { widget.SubscribeToSpecPriceEvents(); widget.Updated += delegate (object sender, EventArgs e) { }; } // Подписываемся на уведомления.
            ConsoleMenu menu = new ConsoleMenu(menuPuncts, widgets);
            menu.DisplayMenu(); // Вызов меню.
        }
    }
}