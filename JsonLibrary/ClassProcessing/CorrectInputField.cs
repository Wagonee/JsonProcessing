using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonLibrary.ClassProcessing
{
    /// <summary>
    /// Статический класс с методами для обработки корректного ввода
    /// </summary>
    public static class CorrectInputField
    {
        public static string InputString()
        {
            string str;
            Console.Clear();
            Console.Write("Введите строку: ");
            while (true)
            {
                try
                {
                    str = Console.ReadLine();
                    if (str == null || str == "") { throw new ArgumentNullException(); }
                    break;
                }
                catch (ArgumentNullException) { Console.Write("Введена пустая строка, повторите попытку: "); }
                catch (Exception) { Console.Write("Произошла неизвестная ошибка при вводе данных, повторите попытку: "); }
            }
            return str;
        }
        public static int InputInt()
        {
            int input;
            Console.Clear();
            Console.Write("Введите целое число >= 0: ");
            while (true)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if (input < 0) { throw new ArgumentOutOfRangeException(); }
                    break;
                }
                catch (ArgumentOutOfRangeException) { Console.Write("Введённое число не удовлетворяет промежутку: "); }
                catch (FormatException) { Console.Write("Введено не число, повторите попытку: "); }
                catch (Exception) { Console.Write("Произошла неизвестная ошибка при вводе данных, повторите попытку: "); }
            }
            return input;
        }
        public static bool InputBool()
        {
            Console.Clear();
            Console.Write("Введите 'yes' - в случае, если хотите сделать поле isAvailable - true, и 'no' в противном случае: ");
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (input ==  "yes") { return true; }
                    else if (input == "no") { return false; }
                    else { throw new ArgumentOutOfRangeException(); }
                }
                catch (ArgumentOutOfRangeException) { Console.Write("Некорректный ввод ('yes'/'no'), повторите попытку: "); }
            }
        }
        public static DateTime InputDateTime()
        {
            DateTime input;
            Console.Clear();
            DateTime e = DateTime.Now;
            Console.Write("Введите дату в любом формате DateTime: ");
            while (true)
            {
                try
                {
                    input = DateTime.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
                    return input;
                }
                catch (ArgumentNullException) { Console.Write("Передана пустая строка, повторите попытку: "); }
                catch (FormatException) { Console.Write("Строка не удовлетворяет ни одному из форматов DateTime, повторите попытку: "); }
            }
        }
        public static double InputDouble()
        {
            double input;
            Console.Clear();
            Console.Write("Введите число >= 0: ");
            while (true)
            {
                try
                {
                    input = double.Parse(Console.ReadLine());
                    if (input < 0) { throw new ArgumentOutOfRangeException(); }
                    break;
                }
                catch (ArgumentOutOfRangeException) { Console.Write("Введённое число не удовлетворяет промежутку: "); }
                catch (FormatException) { Console.Write("Введено не число, повторите попытку: "); }
                catch (Exception) { Console.Write("Произошла неизвестная ошибка при вводе данных, повторите попытку: "); }
            }
            return input;
        }
    }
}
