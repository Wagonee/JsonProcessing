using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Text.Json;

namespace JsonLibrary
{
    /// <summary>
    /// Базовый класс варианта.
    /// </summary>
    public class Widget
    {
        string _widgetId;
        string _name;
        int _quantity;
        double _price;
        bool _isAvailable;
        DateTime _manufactureDate;
        List<Specification> _specifications;

        public delegate void EventHandler(Widget sender, EventArgs e);
        public event EventHandler<EventArgs>? Updated;

        public string widgetId 
        {
            get { return _widgetId; }
            set 
            {
                if (value != null)
                {
                    UpdateField(ref _widgetId, value, "WidgetId");
                }
            }
        }
        public string name
        {
            get { return _name; }
            set
            {
                if (value != null)
                {
                    UpdateField(ref _name, value, "Name");
                }
            }
        }
        public int quantity
        {
            get { return _quantity; }
            set 
            {
                try
                {
                    int newQuantity = value;
                    UpdateField(ref _quantity, value, "Quantity");
                }
                catch (Exception ex) { Console.WriteLine("Неверный формат данных!"); }
            }
        }
        public double price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                }
            }
        }
        public bool isAvailable
        {
            get { return _isAvailable; }
            set { UpdateField(ref _isAvailable, value, "IsAvailable"); }
        }
        public DateTime manufactureDate
        {
            get { return _manufactureDate; }
            set { UpdateField(ref _manufactureDate, value, "ManufactureDate"); }
        }
        public List<Specification> specifications 
        { 
            get 
            {
                return _specifications;
            }
            set
            {
                _specifications = value;
            } 
        }
        public Widget(string widgetId, string name, int quantity, double price, bool isAvailable, DateTime manufactureDate, List<Specification> specifications)
        {
            this.widgetId = widgetId;
            this.name = name;
            this.quantity = quantity;
            this.price = price;
            this.isAvailable = isAvailable;
            this.manufactureDate = manufactureDate;
            this.specifications = specifications;
        }
        public Widget() { } // Пустой конструктор по умолчанию.
        public string ToJSON()
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                return JsonSerializer.Serialize(this, options);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Ошибка при сериализации в JSON: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
                return null;
            }
        }
        /// <summary>
        /// Метод обработчик события смены какого-либо поля класса Widget.
        /// </summary>
        /// <param name="e"></param>
        void OnUpdated(WidgetUpdateEventArgs e)
        {
            Updated?.Invoke(this, e);
            Console.WriteLine(e.Message);
        }
        void UpdateField<T>(ref T field, T newValue, string fieldName) // Засунем изменение поля в обобщённый метод.
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue)) // Проверяем на совпадение нового значения поля со старым.
            {
                T oldValue = field;
                field = newValue;
                if (Updated != null) // Проверяем подписку на уведомления.
                {
                    OnUpdated(new WidgetUpdateEventArgs(fieldName, oldValue.ToString(), newValue.ToString(), DateTime.Now, $"Поле \"{fieldName}\" изменено: \"{oldValue}\" => \"{newValue}\", дата изменения {DateTime.Now:g}"));
                }
            }
            else
            {
                if (Updated != null)
                {
                    Console.WriteLine("Новое значение поля совпадает с текущим!");
                }
            }
        }
        /// <summary>
        /// Метод, позволяющий подписаться на уведомления от 
        /// </summary>
        public void SubscribeToSpecPriceEvents()
        {
            if (specifications != null)
            {
                foreach (var spec in specifications)
                {
                    spec.SpecPriceChanged += SpecPriceChange;
                }
            }
        }
        /// <summary>
        /// Метод обработчик изменения цены поля агрегированного класса.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SpecPriceChange(object sender, WidgetUpdateEventArgs e) 
        {
            Console.WriteLine($"Поле \"{e.FieldName}\" изменено: \"{e.OldValue}\" => \"{e.NewValue}\", дата изменения {e.UpdateTime:g}");
            UpdateField(ref _price, specifications.Sum(spec => spec.specPrice), "Price");
        }
    }
}