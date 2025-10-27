using System;

public class CustomList<T>
{
    private T[] array;
    private int size;
    private int maxSize;

    public CustomList(int initialmaxSize = 4)
    {
        maxSize = initialmaxSize;
        array = new T[maxSize];
        size = 0;
    }
    public void Add(T item)
    {
        if (size == maxSize)
        {
            Resize(maxSize * 2); 
        }
        array[size++] = item;
    }
    public T Get(int index)
    {
        return array[index];
    }
    public void RemoveAt(int index)
    {
        for (int i = index; i < size - 1; i++)
        {
            array[i] = array[i + 1];
        }

        size -=1;
    }

    public void Insert(int index,T item)
    {
        if (size == maxSize)
        {
            Resize(maxSize * 2);
        }
        for (int i = size; i > index; i--)
        {
            array[i] = array[i-1];
        }
        array[index] = item;
        size += 1;
    }

    public int Count => size;
    private void Resize(int newmaxSize)
    {
        T[] newArray = new T[newmaxSize];
        Array.Copy(array, newArray, size);
        array = newArray;
        maxSize = newmaxSize;
    }
    public void PrintAll()
    {
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        CustomList<int> list = new CustomList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Add(40);

        list.PrintAll();

        Console.WriteLine("Элемент по индексу 2: " + list.Get(2));

        list.RemoveAt(2);
        list.Insert(2,30);


        list.PrintAll();
    }
}
