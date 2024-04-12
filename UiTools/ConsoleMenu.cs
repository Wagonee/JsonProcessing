using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonLibrary;

namespace UiTools
{
    /// <summary>
    /// Класс, обеспечивающий поддержку главного меню.
    /// </summary>
    public class ConsoleMenu
    {
        int _selectedIndex;
        string[] _options;
        List<Widget> _widgets;
        string[] _sortMenu = new string[] { "1) widgetId", "2) name", "3) quantity", "4) price", "5) isAvailable", "6) manufactureDate" };
        string[] _mainMenu = new string[] { "Сортировка по одному из полей", "Выбор объекта для редактирования", "Ввод пути к новому файлу", "Выход из программы" };
        string[] _changeMenu = new string[] { "1) name", "2) quantity", "3) isAvailable", "4) manufactureDate", "5) specifications (изменение поля SpecPrice)" };

        public ConsoleMenu(string[] options, List<Widget> widgets)
        {
            _options = options;
            _widgets = widgets;
        }
        /// <summary>
        /// Метод вызывающий меню и обеспечивающий перемещение по пунктам.
        /// </summary>
        public void DisplayMenu()
        {
            while (true)
            {
                Console.Write("\u001b[2J\u001b[3J");
                Console.Clear();
                Console.WriteLine("Выберите функцию из списка ниже, для перемещения по меню используйте стрелки, для выбора нажмите Enter:\n");
                // Вывод меню.
                for (int i = 0; i < _options.Length; i++)
                {
                    // Отображение выбранного пункта.
                    if (i == _selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    // Вывод пункта меню.
                    Console.WriteLine(_options[i]);
                    Console.ResetColor();
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                // Обработчик нажатия клавиш.
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        _selectedIndex = (_selectedIndex - 1 + _options.Length) % _options.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        _selectedIndex = (_selectedIndex + 1) % _options.Length;
                        break;
                    case ConsoleKey.Enter:
                        HandleMenuOption(_selectedIndex);
                        return;
                }
            }
        }
        /// <summary>
        /// Метод обработчик нажатия клавиши Enter.
        /// </summary>
        /// <param name="selectedIndex"></param>
        void HandleMenuOption(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    Console.Write("\u001b[2J\u001b[3J");
                    Console.Clear();
                    SortMenu menuSort = new SortMenu(_sortMenu, _widgets);
                    menuSort.DisplayMenu();
                    break;
                case 1:
                    Console.Write("\u001b[2J\u001b[3J");
                    Console.Clear();
                    Console.Write("Введите ID объекта: ");
                    string searchingField = Console.ReadLine();
                    int index = Sorting.FetchById(_widgets, searchingField);
                    if (index == -1) { Console.WriteLine("Не удалось найти значение поля! Для возвращения в главное меню, нажмите любую клавишу..."); Console.ReadKey(); ConsoleMenu menuMain = new ConsoleMenu(_mainMenu, _widgets); menuMain.DisplayMenu(); }
                    else
                    {
                        ChangeFieldMenu fieldMenu = new ChangeFieldMenu(_changeMenu, _widgets, index);
                        fieldMenu.DisplayMenu();
                    }
                    break;
                case 2:
                    Console.Write("\u001b[2J\u001b[3J");
                    Console.Clear();
                    List<Widget> widgets = JsonReader.DeserializeWidgets();
                    ConsoleMenu menu = new ConsoleMenu(_mainMenu, widgets);
                    AutoSaver autoSaver = new(widgets, "original.json");
                    menu.DisplayMenu();
                    break;
                case 3:
                    break;
            }
        }
    }
}
