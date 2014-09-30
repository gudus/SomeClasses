    public class mItems
    {
        MeasurementsHeader Header = new MeasurementsHeader();
        List<MeasurementsItems> Items = new List<MeasurementsItems>();


    }

    public class MeasurementsTask : MeasurementsHeader
    {
        List<MeasurementsItems> Items = null;
        public MeasurementsTask(string MeasurementsNumber, string MeasurementsProfil, string MeasurementsObject)
        {
            this.MeasurementsNumber = MeasurementsNumber;
            this.MeasurementsProfil = MeasurementsProfil;
            this.MeasurementsObject = MeasurementsObject;
            Items = new List<MeasurementsItems>();
        }
        /// <summary>
        /// Добавить новый элемент в заказ
        /// </summary>
        /// <param name="measurementsItems"></param>
        public void AddItem(MeasurementsItems measurementsItems)
        {
            Items.Add(measurementsItems);
        }
        /// <summary>
        /// Удалить элемент из заказа
        /// </summary>
        /// <param name="measurementsItems"></param>
        public void DeleteItem(MeasurementsItems measurementsItems)
        {
            Items.Remove(measurementsItems);
        }
        /// <summary>
        /// Удалить все элементы из заказа
        /// </summary>
        public void DeleteAllItem()
        {
            Items.Clear();
        }
    }

    /// <summary>
    /// Информация о заказе(основная информация о замере)
    /// </summary>
    public class MeasurementsHeader
    {
        /// <summary>
        /// Номер заказа
        /// </summary>
        public string MeasurementsNumber { get; set; }
        /// <summary>
        /// Использовать профиль
        /// </summary>
        public string MeasurementsProfil { get; set; }
        /// <summary>
        /// Адрес объекта
        /// </summary>
        public string MeasurementsObject { get; set; }
        /// <summary>
        /// Сумма
        /// </summary>
        public float MeasurementsSumma { get; set; }
    }

    /// <summary>
    /// Элемент заказа(замера), конструкция или услуга
    /// </summary>
    public class MeasurementsItems
    {
        /// <summary>
        /// Положение элемента на рисунке
        /// </summary>
        mDrawing.Vector2 ItemPosition { get; set; }
        /// <summary>
        /// Высота
        /// </summary>
        public float ItemHeight { get; set; }
        /// <summary>
        /// Ширина
        /// </summary>
        public float ItemWidth { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public ItemsTypes ItemsType { get; set; }
        /// <summary>
        /// Место рсположения
        /// </summary>
        public string ItemsPlace { get; set; }
        /// <summary>
        /// Используемый профиль
        /// </summary>
        public string ItemsProfil { get; set; }
        /// <summary>
        /// Цвет
        /// </summary>
        public Color ItemsColor { get { return _ItemColor; } set { _ItemColor = value; } }
        private Color _ItemColor = Color.White;
        /// <summary>
        /// Цена
        /// </summary>
        public float ItemPrice { get; set; }
        /// <summary>
        /// Картинка
        /// </summary>
        public byte[] ItemImage { get; set; }
        /// <summary>
        /// Входящие элементы
        /// </summary>
        public List<MeasurementsItems> IncludeItems = new List<MeasurementsItems>();

        /// <summary>
        /// Получить сумму элементов всех
        /// </summary>
        /// <returns></returns>
        public float GetMeasurementsItemsSumma() { return GetMeasurementsItemsSumma(this, ItemsTypes.None); }
        /// <summary>
        /// Получить сумму элементов по типу
        /// </summary>
        /// <returns></returns>
        public float GetMeasurementsItemsSumma(ItemsTypes types) { return GetMeasurementsItemsSumma(this, types); }
        /// <summary>
        /// Получить сумму элементов по типу
        /// </summary>
        /// <returns></returns>
        public static float GetMeasurementsItemsSumma(MeasurementsItems measurementsItems, ItemsTypes types)
        {
            float summa = measurementsItems.ItemPrice;
            if (types != ItemsTypes.None && measurementsItems.ItemsType != types)
            {
                summa = 0;
            }
            for (int i = 0; i < measurementsItems.IncludeItems.Count; i++)
            {
                summa += GetMeasurementsItemsSumma(measurementsItems.IncludeItems[i], types);
            }
            return summa;
        }
        /// <summary>
        /// Получить количество элементов всех
        /// </summary>
        /// <returns></returns>
        public int GetMeasurementsItemsCount() { return GetMeasurementsItemsCount(this, ItemsTypes.None); }
        /// <summary>
        /// Получить количество элементов по типу
        /// </summary>
        /// <returns></returns>
        public int GetMeasurementsItemsCount(ItemsTypes types) { return GetMeasurementsItemsCount(this, types); }
        /// <summary>
        /// Получить количество элементов по типу
        /// </summary>
        /// <returns></returns>
        public static int GetMeasurementsItemsCount(MeasurementsItems measurementsItems, ItemsTypes types)
        {
            int count = 1;
            if (types != ItemsTypes.None && measurementsItems.ItemsType != types)
            {
                count = 0;
            }
            for (int i = 0; i < measurementsItems.IncludeItems.Count; i++)
            {
                count += GetMeasurementsItemsCount(measurementsItems.IncludeItems[i], types);
            }
            return count;
        }
        /// <summary>
        /// Типы элементов
        /// </summary>
        public enum ItemsTypes
        {
            None, Window, Door, Windowsill
        }
        /// <summary>
        /// Добавить новый элемент в элемент
        /// </summary>
        /// <param name="measurementsItems"></param>
        public void AddItem(MeasurementsItems measurementsItems)
        {
            IncludeItems.Add(measurementsItems);
        }
        /// <summary>
        /// Удалить элемент из элемент
        /// </summary>
        /// <param name="measurementsItems"></param>
        public void DeleteItem(MeasurementsItems measurementsItems)
        {
            IncludeItems.Remove(measurementsItems);
        }
        /// <summary>
        /// Удалить все элементы из элемент
        /// </summary>
        public void DeleteAllItem()
        {
            IncludeItems.Clear();
        }
    }
