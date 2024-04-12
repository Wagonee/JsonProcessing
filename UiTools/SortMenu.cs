using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonLibrary;

namespace UiTools
{
    /// <summary>
    /// Класс меню аналогичный ConsoleMenu.
    /// </summary>
    public class SortMenu
    {
        int _selectedIndex;
        string[] _options;
        List<Widget> _widgets;
        string[] _mainMenuOption = new string[] { "Сортировка по одному из полей", "Выбор объекта для редактирования", "Ввод пути к новому файлу", "Выход из программы" };
        public SortMenu(string[] options, List<Widget> widgets)
        {
            _options = options;
            _widgets = widgets;
        }
        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите поле для сортировки:");
                for (int i = 0; i < _options.Length; i++)
                {
                    if (i == _selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(_options[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

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
        void HandleMenuOption(int selectedIndex)
        {
          
            switch (selectedIndex)
            {
                case 0:
                    _widgets = Sorting.SortingByWidgetId(_widgets, true);
                    OutputTools.Output(_widgets);
                    Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                    Console.ReadKey();
                    ConsoleMenu menu = new(_mainMenuOption, _widgets);
                    menu.DisplayMenu();
                    break;
                case 1:
                    _widgets = Sorting.SortingByName(_widgets, true);
                    OutputTools.Output(_widgets);
                    Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                    Console.ReadKey();
                    menu = new(_mainMenuOption, _widgets);
                    menu.DisplayMenu();
                    break;
                case 2:
                    _widgets = Sorting.SortingByQuantity(_widgets, true);
                    OutputTools.Output(_widgets);
                    Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                    Console.ReadKey();
                    menu = new(_mainMenuOption, _widgets);
                    menu.DisplayMenu();
                    break;
                case 3:
                    _widgets = Sorting.SortingByPrice(_widgets, true);
                    OutputTools.Output(_widgets);
                    Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                    Console.ReadKey();
                    menu = new(_mainMenuOption, _widgets);
                    menu.DisplayMenu();
                    break;
                case 4:
                    _widgets = Sorting.SortingByAvailable(_widgets, true);
                    OutputTools.Output(_widgets);
                    Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                    Console.ReadKey();
                    menu = new(_mainMenuOption, _widgets);
                    menu.DisplayMenu();
                    break;
                case 5:
                    _widgets = Sorting.SortingByManufactureDate(_widgets, true);
                    OutputTools.Output(_widgets);
                    Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                    Console.ReadKey();
                    menu = new(_mainMenuOption, _widgets);
                    menu.DisplayMenu();
                    break;
            }
        }
    }
}
