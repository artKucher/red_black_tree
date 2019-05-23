using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    class Program
    {
        //Постройте красно-черное дерево по заданным ключам
        //Реализуйте красно-черное дерево со следующими операциями:

        //создание дерева
        //добавление элемента
        //поиск элемента в дереве
        //14. Vector(53, 38, 65, 98, 38, 76, 4, 28, 14, 33, 25, 21, 54, 58, 32, 25, 63, 63, 94, 1, 86)
        static void Main(string[] args)
        {
            int[] vector = new int[] { 53, 38, 65, 98, 38, 76, 4, 28, 14, 33, 25, 21, 54, 58, 32, 25, 63, 63, 94, 1, 86 };

            RBTree<int> tree = new RBTree<int>(new Node<int>(vector[0]));
            Random random = new Random();
            for (int i =1; i < vector.Length; i++)
            {
                
                tree.Add(vector[i]).data = random.Next(10,100);
            }

            Console.WriteLine("Item 54 has "+ tree.Find(54, tree.root).data.ToString()+" value in data");
            Console.ReadLine();
        }
    }
}
