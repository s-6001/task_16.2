using System;
using System.Text.Json;
using System.IO;

namespace task_16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "d:/Products.json";
            try
            {
                StreamReader sr = new StreamReader(path); //создаем экземпляр класса sr
                string jsonString = sr.ReadToEnd(); //содержимое файла
                Console.WriteLine(jsonString);  //выводим на консоль содержимое файла
                Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString); //десериализуем текст файла и записываем в массив товары
                double maxPrice = 0;    //максимальная цена
                string nameMaxPrice = "";   //название самого дорогого товара
                for (int i = 0; i < products.Length; i++)   //проходим по всем товарам
                {
                    if (maxPrice <= products[i].ProductPrice)   //находим максимальную цену и название самого дорогого товара
                    {
                        maxPrice = products[i].ProductPrice;
                        nameMaxPrice = products[i].ProductName;
                    }
                }
                Console.WriteLine("Название самого дорогого товара: {0}", nameMaxPrice);
            }
            catch
            {
                Console.WriteLine("Ошибка чтения файла.");
            }
            Console.ReadKey();
        }
    }
    public class Product
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }
}
