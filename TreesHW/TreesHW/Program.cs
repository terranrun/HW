using System;

namespace TreesHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee root = null;

            TreesEmployee(out root);

            Traverse(root);

            FindTreesEmployee(root);

            MenuController(root);

        }
        static void MenuController(Employee root)
        {
            do
            {
                Console.WriteLine("Main menu \n" +
                                  "0 - переход в начало программы \n" +
                                  "1 - поиск зарплаты");
                var value = Console.ReadLine();

                switch (value)
                {
                    case "0":
                        TreesEmployee(out root);
                        Traverse(root);
                        break;
                    case "1":
                        FindTreesEmployee(root);
                        break;
                    default:
                        Console.WriteLine("Операция не распознана. Введите 1 или 0: ");
                        break;

                }

            } while (AskContinue("хотите вернуться в меню?Y/N"));
        }

        static void TreesEmployee(out Employee root)
        {
            root = null;
            do
            {
                Console.WriteLine("Введите имя сотрудника");
                var name = Console.ReadLine();
                Console.WriteLine("Введите зарплату сотрудника");
                Int32.TryParse(Console.ReadLine(), out int salary);

                if (root == null)
                {
                    root = new Employee
                    {
                        Name = name,
                        Salary = salary,
                    };
                }
                else
                {
                    AddEmployee(root, new Employee
                    {
                        Name = name,
                        Salary = salary,
                    });
                }
            } while (AskContinue("Хотите продолжить ввод сотрудников? Y/N"));
        }

        static void FindTreesEmployee(Employee root)
        {
            do
            {
                Console.WriteLine("Введите размер зарплаты сотрудника, который вас интересует ");
                var needle = Console.ReadLine();
                double n = double.Parse(needle);

                if (n == 0)
                {
                    break;
                }
                var node = Find(root, n);
                if (node != null)
                {
                    Console.WriteLine($"Нашли сотрудник:{node.Name} " + node.Salary);
                }
                else
                {
                    Console.WriteLine("такой сотрудник не найден");
                }
            } while (AskContinue("Хотите продолжить поиск? Y/N"));
        }

        static bool AskContinue(string str)
        {
            while (true)
            {
                Console.WriteLine(str);
                var status = Console.ReadLine();
                if (status == "Y" || status == "y")
                    return true;
                else if (status == "N" || status == "n")
                    return false;
                else
                    Console.WriteLine("Операция не распознана. Введите Y или N: ");
            }
        }

        public static void AddEmployee(Employee node, Employee toAdd)
        {
            if (toAdd.Salary < node.Salary)
            {
                // добавляем в левое поддерево
                if (node.Left == null)
                {
                    node.Left = toAdd;
                }
                else
                {
                    AddEmployee(node.Left, toAdd);
                }
            }
            else
            {
                // добавляем в правое поддерево
                if (node.Right == null)
                {
                    node.Right = toAdd;
                }
                else
                {
                    AddEmployee(node.Right, toAdd);
                }
            }
        }
        static Employee Find(Employee node, double needle)
        {
            if (needle < node.Salary)
            {
                //ищем в левом поддереве
                return node.Left == null ? null : Find(node.Left, needle);
            }
            else if (needle > node.Salary)
            {
                //ищем в провом поддереве
                return node.Right == null ? null : Find(node.Right, needle);
            }
            else
            {
                return node;
            }
        }
        static public void Traverse(Employee node)
        {


            if (node.Left != null)
            {
                Traverse(node.Left);
            }
            Console.WriteLine($"Имя: {node.Name} Зарпалата: {node.Salary}");
            if (node.Right != null)
                Traverse(node.Right);
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public Employee Left { get; set; }
        public Employee Right { get; set; }
    }
}
