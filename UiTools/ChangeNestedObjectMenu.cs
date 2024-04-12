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
    internal class ChangeNestedObjectMenu
    {
        int _selectedIndex;
        int _indexObj;
        string[] _options;
        List<Widget> _widgets;
        string[] _mainMenuOption = new string[] { "Сортировка по одному из полей", "Выбор объекта для редактирования", "Ввод пути к новому файлу", "Выход из программы" };
        public ChangeNestedObjectMenu(string[] options, List<Widget> widgets, int indexObj)
        {
            _indexObj = indexObj;
            _options = options;
            _widgets = widgets;
        }
        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите объект в котором хотите поменять поле specPrice:");
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
                    double number = JsonLibrary.ClassProcessing.CorrectInputField.InputDouble();
                    _widgets[_indexObj].specifications[0].specPrice = number;
                    Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                    Console.ReadKey();
                    ConsoleMenu menu = new(_mainMenuOption, _widgets);
                    menu.DisplayMenu();
                    break;
                case 1:
                    number = JsonLibrary.ClassProcessing.CorrectInputField.InputDouble();
                    _widgets[_indexObj].specifications[1].specPrice = number;


                    Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                    Console.ReadKey();
                    menu = new(_mainMenuOption, _widgets);
                    menu.DisplayMenu();
                    break;
                case 2:
                    number = JsonLibrary.ClassProcessing.CorrectInputField.InputDouble();
                    _widgets[_indexObj].specifications[2].specPrice = number;


                    Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                    Console.ReadKey();
                    menu = new(_mainMenuOption, _widgets);
                    menu.DisplayMenu();
                    break;
                case 3:
                    number = JsonLibrary.ClassProcessing.CorrectInputField.InputDouble();
                    _widgets[_indexObj].specifications[3].specPrice = number;


                    Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                    Console.ReadKey();
                    menu = new(_mainMenuOption, _widgets);
                    menu.DisplayMenu();
                    break;
                case 4:
                    number = JsonLibrary.ClassProcessing.CorrectInputField.InputDouble();
                    _widgets[_indexObj].specifications[4].specPrice = number;


                    Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                    Console.ReadKey();
                    menu = new(_mainMenuOption, _widgets);
                    menu.DisplayMenu();
                    break;
                case 5:
                  


                    Console.WriteLine("Чтобы вернуться в главное меню, нажмите любую клавишу...");
                    Console.ReadKey();
                    menu = new(_mainMenuOption, _widgets);
                    menu.DisplayMenu();
                    break;
            }
        }
    }
}

