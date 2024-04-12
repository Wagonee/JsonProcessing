namespace JsonLibrary
{
    /// <summary>
    /// Статический класс с методами для сортировки списка объектов класса Widget.
    /// </summary>
    public static class Sorting
    {
        public static List<Widget> SortingByPrice(List<Widget> widgets, bool direction)
        {
            if (direction)
            {
                return widgets.OrderBy(x => x.price).ToList();
            }
            else
            {
                return widgets.OrderByDescending(x => x.price).ToList();
            }
        }
        public static List<Widget> SortingByQuantity(List<Widget> widgets, bool direction)
        {
            if (direction)
            {
                return widgets.OrderBy(x => x.quantity).ToList();
            }
            else
            {
                return widgets.OrderByDescending(x => x.quantity).ToList();
            }
        }
        public static List<Widget> SortingByManufactureDate(List<Widget> widgets, bool direction)
        {
            if (direction)
            {
                return widgets.OrderBy(x => x.manufactureDate).ToList();
            }
            else
            {
                return widgets.OrderByDescending(x => x.manufactureDate).ToList();
            }
        }
        public static List<Widget> SortingByWidgetId(List<Widget> widgets, bool direction)
        {
            if (direction)
            {
                return widgets.OrderBy(x => x.widgetId).ToList();
            }
            else
            {
                return widgets.OrderByDescending(x => x.widgetId).ToList();
            }
        }
        public static List<Widget> SortingByName(List<Widget> widgets, bool direction)
        {
            if (direction)
            {
                return widgets.OrderBy(x => x.name).ToList();
            }
            else
            {
                return widgets.OrderByDescending(x => x.name).ToList();
            }
        }
        public static List<Widget> SortingByAvailable(List<Widget> widgets, bool direction)
        {
            if (direction)
            {
                return widgets.OrderBy(x => x.isAvailable).ToList();
            }
            else
            {
                return widgets.OrderByDescending(x => x.isAvailable).ToList();
            }
        }
        /// <summary>
        /// Метод для поиска объекта Widget по widgetId.
        /// </summary>
        /// <param name="widgets">Лист объектов Widget.</param>
        /// <param name="searchingId">Значение widgetId.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int FetchById(List<Widget> widgets, string searchingId)
        {
            if (searchingId == null) { throw new ArgumentNullException(); }
            int count = 0;
            foreach (Widget widget in widgets)
            {
                if (widget.widgetId == searchingId)
                {
                    return count;
                }
                count++;
            }
            return -1;
        }
    }
}
