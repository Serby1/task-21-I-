using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp32
{
    public class BinaryTree
    {
        private class Node
        {
            public object inf; //информационное поле   
            public Node left; //ссылка на левое поддерево   
            public Node rigth;// правое поддерево 

            public Node(object nodeInf)
            {
                inf = nodeInf;
                left = null;
                rigth = null;
            }

            public static void Add(ref Node r, object nodeInf)//добавление узла
            {
                if (r == null)
                {
                    r = new Node(nodeInf);
                }
                else
                {
                    
                    if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0)
                    {
                        Add(ref r.left, nodeInf);
                    }
                    else
                    {
                        Add(ref r.rigth, nodeInf);
                    }
                }
            }
            public static int rightDescendant(Node r)// считыет сумму узлов у которых есть только правый потомок
            {
                int sum = 0;
                if (r.left != null)
                {
                    sum += rightDescendant(r.left);
                }
                if (r.rigth != null)
                {
                    sum += rightDescendant(r.rigth);
                }
                if (r.left == null && r.rigth!=null)
                {
                    sum += (int)r.inf;
                }
                return sum;
            }
        }
        Node tree;//ссылка на корень дерева
        public object Inf
        {
            set { tree.inf = value; }
            get { return tree.inf; }
        }
        public BinaryTree() //открытый конструктор   
        {
            tree =null;
        } 
        private BinaryTree(Node r) //закрытый конструктор   
        {
            tree =r;
        }
        public void Add(object nodeInf) //добавление узла в дерево   
        {
            Node.Add(ref tree, nodeInf);
        }
        public void rightDescendant()//выводит сумму узлов, у которых есть только правый потомок 
        {
            Console.WriteLine(Node.rightDescendant(tree));
        }


    }
    

    

    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/Vlad/source/repos/ConsoleApp32/fileIn.txt";
            using (StreamReader fileIn = new StreamReader(path))
            {
                string str = fileIn.ReadToEnd();
                string[] stringArray = str.Split(' ');
                int[] array = new int[stringArray.Length];
                for (int i = 0; i < array.Length; ++i)
                {
                    array[i] = int.Parse(stringArray[i]);
                }
                BinaryTree tree = new BinaryTree();
                foreach (int item in array)
                {
                    tree.Add(item);
                }
                Console.WriteLine("Cумму значений узлов, имеющих только одного правого потомка:");
                tree.rightDescendant();
                Console.ReadLine();
            }

        }
    }
}
