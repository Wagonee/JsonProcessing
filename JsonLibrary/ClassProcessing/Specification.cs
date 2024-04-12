using System.Text.Json;

namespace JsonLibrary
{
    /// <summary>
    /// Агрегированный класс хранящий данные о составляющей класса Widget.
    /// </summary>
    public class Specification
    {
        public event EventHandler<WidgetUpdateEventArgs> SpecPriceChanged;
        double _specPrice;
        public string specName { get; set; }
        public double specPrice
        {
            get { return _specPrice; }
            set
            {
                if (_specPrice != value)
                {
                    double oldValue = _specPrice;
                    _specPrice = value;
                    SpecPriceChanged?.Invoke(this, new WidgetUpdateEventArgs("SpecPrice", oldValue.ToString(), value.ToString(), DateTime.Now, $"Поле \"{"SpecPrice"}\" изменено: \"{oldValue}\" => \"{value}\", дата изменения {DateTime.Now:g}"));
                }
            }
        }
        public bool isCustom { get; set; }
        public delegate void EventHandler(Specification sender, EventArgs e);
        public Specification(string specName, double specPrice, bool isCustom)
        {
            this.specName = specName;
            this._specPrice = specPrice;
            this.isCustom = isCustom;
        }
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
    }
}

