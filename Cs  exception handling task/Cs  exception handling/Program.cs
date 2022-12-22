using System;

namespace Cs__exception_handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Notebook[] notebooks = new Notebook[4];

            notebooks[0] = new Notebook("Macbook Pro 15", 3500);
            notebooks[1] = new Notebook("Macbook Pro 13", 2500);
            notebooks[2] = new Notebook("Macbook Air", 1500);
            notebooks[3] = new Notebook("Asus ROG", 3200);

            string opt;
            do
            {
                Console.WriteLine("1. Notebooklar uzerinde axtaris");
                Console.WriteLine("2. Yeni notebook yarat");
                Console.WriteLine("0. Menudan cix");

                opt = Console.ReadLine();
                try
                {
                    if (opt == "1")
                    {
                        Console.WriteLine("Axtaris deyerini daxil edin: ");
                        string search = Console.ReadLine();

                        var filteredArr = SearchByName(notebooks, search);

                        ShowNotebookInfo(filteredArr);
                    }
                    if (opt == "2")
                    {
                        Console.WriteLine("Yaradilan deyeri daxil edin: ");
                        var notebook = CreateNotebook();
                        Add(ref notebooks, notebook);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Yeniden daxil edin");
                    
                }
                

            } while (opt != "0");
        }

        static Notebook[] SearchByName(Notebook[] arr, string search)
        {
            Notebook[] newArr = new Notebook[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Name.Contains(search, StringComparison.InvariantCultureIgnoreCase))
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[newArr.Length - 1] = arr[i];
                }
            }

            return newArr;
        }

        static void ShowNotebookInfo(Notebook[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i].GetInfo());
            }
        }

        static Notebook[] Add(ref Notebook[] arr, Notebook value)
        {
            Notebook[] newArr = new Notebook[arr.Length + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            newArr[newArr.Length - 1] = value;

            return arr =newArr;

        }

        static Notebook CreateNotebook()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                throw new NotebookFormatException("Deyeri duzgun daxil edin");
            }

            Console.WriteLine("Price: ");
            string priceStr = Console.ReadLine();
            double price = Convert.ToDouble(priceStr);

            if (price < 0)
            {
                throw new NotebookFormatException("Deyeri duzgun daxil edin");
            }

            Console.WriteLine("RAM: ");
            string ramStr = Console.ReadLine();
            byte ram = Convert.ToByte(ramStr);
            if (ram < 0 || ram > 128)
            {
                throw new NotebookFormatException("Deyeri duzgun daxil edin");
            }

            Notebook notebook = new Notebook(name, price, ram);

            return notebook;
        }
    }
}
