using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonLibrary
{
    /// <summary>
    /// Предоставляет аргументы события для обновлений виджетов, инкапсулируя сведения об измененном поле, значениях и времени.
    /// </summary>
    public class WidgetUpdateEventArgs : EventArgs
    {
        public string FieldName { get; set; } // Имя обновленного поля.
        public string OldValue { get; set; } // Значение поля до обновления.
        public string NewValue { get; set; } // Новое значение поля после обновления.
        public string Message { get; set; } // Сообщение об обновлении.
        public DateTime UpdateTime { get; set; } // Дата и время обновления.
        public WidgetUpdateEventArgs(string fieldName, string oldValue, string newValue, DateTime updateTime, string message)
        {
            FieldName = fieldName;
            OldValue = oldValue;
            NewValue = newValue;
            UpdateTime = updateTime;
            Message = message;
        }
    }
}
