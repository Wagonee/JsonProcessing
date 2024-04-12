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
    internal class ChangeFieldMenu
    {
            int _selectedIndex;
            int _indexObj;
            string[] _options;
            List<Widget> _widgets;
            string[] _mainMenuOption = new string[] { "Сортировка по одному из полей", "Выбор объекта для редактирования", "Ввод пути к новому файлу", "Выход из программы" };
            public ChangeFieldMenu(string[] options, List<Widget> widgets, int indexObj)
            {
                _options = options;
                _widgets = widgets;
                _indexObj = indexObj;
               
            }
            string[] GenerateOption()
            {
                List<string> strings = new List<string>();
                foreach (Specification w in _widgets[_indexObj].specifications)
                {
                    strings.Add(w.specName);
                }
                return strings.ToArray();
            }
            public void DisplayMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Выберите поле для изменения: ");
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
                        Console.Write("Введите новое значение поля name: ");
                        string field = JsonLibrary.ClassProcessing.CorrectInputField.InputString();
                        _widgets[_indexObj].name = field;
                        Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                        Console.ReadKey();
                        ConsoleMenu menu = new(_mainMenuOption, _widgets);
                        menu.DisplayMenu();
                        break;
                    case 1:
                         Console.Write("Введите новое значение поля quantity: ");
                         int number = JsonLibrary.ClassProcessing.CorrectInputField.InputInt();
                        _widgets[_indexObj].quantity = number;
                        Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                        Console.ReadKey();
                        menu = new(_mainMenuOption, _widgets);
                        menu.DisplayMenu();
                        break;
                    case 2:
                        Console.Write("Введите новое значение поля isAvailable: ");
                        bool boo = JsonLibrary.ClassProcessing.CorrectInputField.InputBool();
                        _widgets[_indexObj].isAvailable = boo;
                        Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                        Console.ReadKey();
                        menu = new(_mainMenuOption, _widgets);
                        menu.DisplayMenu();
                        break;
                    case 3:
                        Console.Write("Введите новое значение поля manufactureDate: ");
                        DateTime time = JsonLibrary.ClassProcessing.CorrectInputField.InputDateTime();
                        _widgets[_indexObj].manufactureDate = time;
                        Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                        Console.ReadKey();
                        menu = new(_mainMenuOption, _widgets);
                        menu.DisplayMenu();
                        break;
                    case 4:
                        ChangeNestedObjectMenu chMenu = new(GenerateOption(), _widgets, _indexObj);
                        chMenu.DisplayMenu();
                        break;
                }
            }
    }
}
