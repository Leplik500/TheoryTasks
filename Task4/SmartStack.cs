using System.Collections;

namespace Task4;

/// <summary>
/// Представляет стек с дополнительными возможностями.
/// </summary>
/// <typeparam name="T">Тип элементов в стеке</typeparam>
public class SmartStack<T> : IEnumerable<T>
{
    private T[] _items;
    private int _top; // Указывает на индекс для следующего добавления

    /// <summary>
    /// Получает емкость внутреннего массива.
    /// </summary>
    public int Capacity { get; private set; }

    /// <summary>
    /// Получает количество элементов в стеке.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Инициализирует новый экземпляр стека с емкостью 4 элемента.
    /// </summary>
    public SmartStack()
    {
        _items = new T[4];
        Capacity = 4;
        _top = 0;
        Count = 0;
    }

    /// <summary>
    /// Инициализирует новый экземпляр стека с указанной емкостью.
    /// </summary>
    /// <param name="capacity">Начальная емкость стека</param>
    public SmartStack(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be positive");
        }

        _items = new T[capacity];
        Capacity = capacity;
        _top = 0;
        Count = 0;
    }

    /// <summary>
    /// Инициализирует новый экземпляр стека элементами из коллекции.
    /// </summary>
    /// <param name="collection">Коллекция для инициализации стека</param>
    public SmartStack(IEnumerable<T> collection)
    {
        ArgumentNullException.ThrowIfNull(collection);

        var collectionList = collection.ToList();
        Capacity = collectionList.Count > 4 ? collectionList.Count : 4;
        _items = new T[Capacity];

        for (var i = 0; i < collectionList.Count; i++)
        {
            _items[i] = collectionList[i]; 
        }

        Count = collectionList.Count;
        _top = Count;
    }

    /// <summary>
    /// Добавляет элемент на вершину стека.
    /// </summary>
    /// <param name="item">Элемент для добавления</param>
    public void Push(T item)
    {
        if (Count == Capacity)
        {
            Capacity *= 2;
            Array.Resize(ref _items, Capacity);
        }

        _items[_top] = item;
        _top++;
        Count++;
    }

    /// <summary>
    /// Добавляет элементы коллекции на вершину стека.
    /// </summary>
    /// <param name="collection">Коллекция элементов для добавления</param>
    public void PushRange(IEnumerable<T> collection)
    {
        ArgumentNullException.ThrowIfNull(collection);

        var collectionList = collection.ToList();

        while (Count + collectionList.Count > Capacity)
        {
            Capacity *= 2;
        }

        if (_items.Length < Capacity)
        {
            Array.Resize(ref _items, Capacity);
        }

        foreach (var item in collectionList)
        {
            _items[_top] = item;
            _top++;
            Count++;
        }
    }

    /// <summary>
    /// Удаляет и возвращает элемент с вершины стека.
    /// </summary>
    /// <returns>Элемент с вершины стека</returns>
    /// <exception cref="InvalidOperationException">Стек пуст</exception>
    public T Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        _top--;
        Count--;
        var item = _items[_top];
        _items[_top] = default!;
        return item;
    }

    /// <summary>
    /// Возвращает элемент с вершины стека без его удаления.
    /// </summary>
    /// <returns>Элемент с вершины стека</returns>
    /// <exception cref="InvalidOperationException">Стек пуст</exception>
    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _items[_top - 1];
    }

    /// <summary>
    /// Проверяет наличие элемента в стеке.
    /// </summary>
    /// <param name="item">Элемент для поиска</param>
    /// <returns>true, если элемент найден; иначе false</returns>
    public bool Contains(T item)
    {
        var comparer = EqualityComparer<T>.Default;

        for (var i = 0; i < Count; i++)
        {
            if (comparer.Equals(_items[i], item))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Получает или устанавливает элемент по указанной глубине.
    /// </summary>
    /// <param name="index">Индекс глубины (0 - вершина стека)</param>
    /// <returns>Элемент на указанной глубине</returns>
    /// <exception cref="ArgumentOutOfRangeException">Индекс вне допустимого диапазона</exception>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return _items[_top - 1 - index];
        }
        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            _items[_top - 1 - index] = value;
        }
    }

    /// <summary>
    /// Возвращает перечислитель, выполняющий итерацию по стеку от вершины к основанию.
    /// </summary>
    /// <returns>Перечислитель для стека</returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (var i = _top - 1; i >= 0; i--)
        {
            yield return _items[i];
        }
    }

    /// <summary>
    /// Возвращает перечислитель, выполняющий итерацию по стеку.
    /// </summary>
    /// <returns>Перечислитель для стека</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
