using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace lab4
{
    internal class Program
    {
        static int[] Sort(int[] arr)
        {          
            int min;
            int n_min;
            int j;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = arr[i];
                n_min = i;
                for (j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        n_min = j;
                        arr[n_min] = arr[i];
                        arr[i] = min;
                    }
                }
            }
            return arr;
        }
        static int GetLength()
        {
            int length;
            bool isConvert;
            do
            {
                Console.WriteLine("Ведите количество элементов массива");//длина массива
                string buf = Console.ReadLine();
                isConvert = int.TryParse(buf, out length);
                if (!isConvert || length < 0)
                {
                    Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
                }
            } while (!isConvert || length < 0);
            return length;
        }
        static int GetNumber()
        {
            int number;
            bool isConvert;
            do
            {
                string buf = Console.ReadLine();
                isConvert = int.TryParse(buf, out number);
                if (!isConvert)
                {
                    Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
                }
            } while (!isConvert);
            return number;
        }
        static void Main(string[] args)
        {
            int answer;
            bool isConvertAnsw;
            int length;
            int number;
            int[] arr = new int[0];
            do
            {
                Console.WriteLine("1.Ввести элементы массива");
                Console.WriteLine("2.Сформировать массив с помощью ДСЧ");
                Console.WriteLine("3.Напечатать массив");
                Console.WriteLine("4.Удалить из массива все четные элементы");
                Console.WriteLine("5.Добавить N элементов, начиная с номера K");
                Console.WriteLine("6.Сдвинуть циклически на M элементов вправо");
                Console.WriteLine("7.Поиск элемента с заданным значением");
                Console.WriteLine("8.Сортировка массива простым выбором");
                Console.WriteLine("9.Бинарный поиск элемента");
                Console.WriteLine("10.Вывод");
                Console.WriteLine("\nВыберите пункт меню");
                do
                {
                    string buf = Console.ReadLine();
                    isConvertAnsw = int.TryParse(buf, out answer);
                    if (!isConvertAnsw)
                    {
                        Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
                    }
                }while (!isConvertAnsw);
                switch (answer)
                {
                    case 1://ввод элементов массива вручную
                        {
                            length = GetLength();
                            arr = new int[length];
                            for (int i = 0; i < length; i++)
                            {
                                Console.WriteLine($"Введите элемент {i+1}");   
                                arr[i] = GetNumber();
                            }
                            Console.WriteLine("Массив сформирован\n");
                            break;
                        }
                    case 2://ДСЧ
                        {
                            length = GetLength();
                            arr = new int[length];
                            for (int i = 0; i < length; i++)
                            {
                                Random a = new Random();
                                arr[i] = a.Next(-100, 100);
                            }
                            Console.WriteLine("Массив сформирован\n");
                            break;
                        }
                    case 3://Напечатать массив
                        {
                            if (arr.Length == 0)
                                Console.WriteLine("Массив пуст\n");
                            foreach (int item in arr)
                                Console.Write(item + " ");
                            Console.WriteLine();
                            break;
                        }
                    case 4://Удаление четных элементов
                        {
                            int count = 0;
                            foreach (int item in arr) //кол-во нечетных элементов
                                if (item % 2 != 0)
                                    count++;
                            int[] temp = new int[count];//удаляем четные
                            int j = 0;//счетчик в temp
                            for (int i = 0; i < arr.Length; i++)
                            {
                                if (arr[i] % 2 != 0)
                                {
                                    temp[j++] = arr[i];
                                }
                            }
                            if (arr.Length == 0)
                                Console.WriteLine("Массив пуст\n");
                            else
                            {
                                if (arr.Length == temp.Length)
                                    Console.WriteLine("Чётные элементы не найдены\n");
                                else
                                    Console.WriteLine("Чётные элементы удалены\n");
                            }
                            arr = temp;
                            break;
                        }
                    case 5://добавление N элементов с номера K
                        {
                            int k;
                            bool isConvert;
                            do
                            {
                                Console.WriteLine("Введите с какого номера вы хотите добавить элементы");
                                string buf = Console.ReadLine();
                                isConvert = int.TryParse(buf, out k);
                                if (!isConvert || arr.Length-1 < k || k <= 0)
                                {
                                    Console.WriteLine("Неправильно введено число или число выходит за длину массива. Попробуйте ещё раз.");
                                }
                            } while (!isConvert || arr.Length < k || k <= 0);
                            int n;
                            do
                            {
                                Console.WriteLine("Ведите количество элементов для добавления");
                                string buf = Console.ReadLine();
                                isConvert = int.TryParse(buf, out n);
                                if (!isConvert || n < 0)
                                {
                                    Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
                                }
                            } while (!isConvert || n < 0);
                            int[] arrNew = new int[arr.Length + n];
                            for (int i = k-1; i < k+n-1; i++)
                            {
                                Console.WriteLine($"Введите элемент {i + 1}");   
                                arrNew[i] = GetNumber();
                            }
                            int j = 0;
                            for (int z = 0; z < k-1; z++)
                            {
                                arrNew[z] = arr[j++];
                            }
                            for (int z = k+n-1; z < arrNew.Length; z++)
                            {
                                arrNew[z] = arr[j++];
                            }
                            arr = arrNew;
                            Console.WriteLine("Добавление выполнено\n");
                            break;
                        }
                    case 6:// сдвиг на M элементов вправо
                        {
                            if (arr.Length == 0)
                                Console.WriteLine("Массив пуст\n");
                            else
                            {
                                int m;
                                bool isConvert;
                                do
                                {
                                    Console.WriteLine("Введите неотрицательное число на сколько элементов вы хотите сдвинуть вправо");
                                    string buf = Console.ReadLine();
                                    isConvert = int.TryParse(buf, out m);
                                    if (!isConvert || m <= 0 || m > arr.Length)
                                    {
                                        Console.WriteLine("Неправильно введено число или оно превышает длину. Попробуйте ещё раз.");
                                    }
                                } while (!isConvert || m <= 0 || m > arr.Length);
                                int[] arrNew = new int[arr.Length];
                                int j = 0;
                                for (int i = 0; i < arr.Length - m; i++)
                                {
                                    arrNew[j + m] = arr[i];
                                    j++;
                                }
                                for (int i = arr.Length - m, g = 0; i < arr.Length; i++, g++)
                                {
                                    arrNew[g] = arr[i];
                                }
                                arr = arrNew;
                                Console.WriteLine($"Массив сдвинулся на {m} элемент(а/ов) вправо\n");
                            }
                            break;
                        } 
                    case 7://поиск элемента
                        {
                            if (arr.Length == 0)
                                Console.WriteLine("Массив пуст\n");
                            else
                            {
                                Console.WriteLine("Введите элемент массива для поиска");//ввод числа для поиска
                                number = GetNumber();
                                int index = -1;//поиск
                                for (int i = 0; i < arr.Length; i++)
                                {
                                    if (arr[i] == number)
                                    {
                                        index = i;
                                        break;
                                    }
                                }
                                if (index < 0)
                                    Console.WriteLine("Число не найдено\n");
                                else
                                    Console.WriteLine($"{number} находится в массиве под номером {index + 1}\n");
                            }
                            break;
                        }
                    case 8://сортировка простой выбор
                        {
                            if (arr.Length == 0)
                                Console.WriteLine("Массив пуст\n");
                            else
                            {
                                Sort(arr);
                                Console.WriteLine("Сортировка выполнена\n");
                            }
                            break;
                        }
                    case 9://Бинарный поиск элемента
                        {
                            Sort(arr);
                            Console.WriteLine("Введите элемент массива для поиска");//ввод числа для поиска
                            number = GetNumber();    
                            int left = 0;
                            int right = arr.Length - 1;
                            int sred;
                            do
                            {
                                sred = (left + right) / 2;
                                if (arr[sred] < number)
                                    left = sred + 1;
                                else
                                    right = sred;
                            } while (left != right);
                            if (arr[left] == number)
                                Console.WriteLine($"{number} находится под номером {left+1}\n");
                            else
                                Console.WriteLine("Элемент не найден\n");
                            break;
                        }
                    case 10:
                        {
                            Console.WriteLine("Работа завершена");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверно задан пункт меню");
                            break;
                        }
                }
            }while (answer!=10);
        }
    }
}