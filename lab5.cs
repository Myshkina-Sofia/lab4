using System.Text;

namespace lab5
{
    internal class Program
    {
        static void PrintMenu(string str)
        {
            if (str == "Главное меню")
            {
                Console.WriteLine("1.Работа с одномерными массивами");
                Console.WriteLine("2.Работа с двумерными массивами");
                Console.WriteLine("3.Работа с рваными массивами");
                Console.WriteLine("4.Выход");
            }    
            else if(str == "Меню одномерного массива")
            {
                Console.WriteLine("\n1.Создать массив");
                Console.WriteLine("2.Напечатать массив");
                Console.WriteLine("3.Удалить все элементы с четными индексами");
                Console.WriteLine("4.Очистить консоль");
                Console.WriteLine("5.Назад");
            }
            else if (str == "Меню двумерного массива")
            {
                Console.WriteLine("\n1.Создать массив");
                Console.WriteLine("2.Напечатать массив");
                Console.WriteLine("3.Добавить K столбцом, начиная со столбца с номером N");
                Console.WriteLine("4.Очистить консоль");
                Console.WriteLine("5.Назад");
            }
            else if (str == "Меню рваного массива")
            {
                Console.WriteLine("\n1.Создать массив");
                Console.WriteLine("2.Напечатать массив");
                Console.WriteLine("3.Добавить строку с заданным номером");
                Console.WriteLine("4.Очистить консоль");
                Console.WriteLine("5.Назад");
            }
            else if (str == "Меню создания массива")
            {
                Console.WriteLine("\n1.Вручную");
                Console.WriteLine("2.С помощью ДСЧ");
                Console.WriteLine("3.Назад");
            }
            else if (str == "Выход")
            {
                Console.WriteLine("\nВы действительно хотите завершить работу?");
                Console.WriteLine("1.Да");
                Console.WriteLine("2.Нет");
            }
        }
        static int[] AddRandomElement(ref int[] array)
        {
            int length;
            do
            {
                Console.WriteLine("Введите количество элементов массива");
                length = GetNumber();
                if (length<0)
                    Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
            } while (length < 0);
            array = new int[length];
            for (int i = 0; i < length; i++)
            {
                Random a = new Random();
                array[i] = a.Next(-100, 100);
            }
            Console.WriteLine("\nМассив сформирован");
            return array;
        }
        static int[,] AddRandomElement(ref int[,] array)
        {
            int str;
            do
            {
                Console.WriteLine("Введите количество строк");
                str = GetNumber();
                if (str < 0)
                    Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
            } while (str < 0);
            if (str == 0)
            {
                Console.WriteLine("\nМассив сформирован");
                return array;
            } 
            else
            {
                int col;
                do
                {
                    Console.WriteLine("Введите количество столбцов");
                    col = GetNumber();
                    if (col < 0)
                        Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
                } while (col < 0);
                array = new int[str, col];
                for (int i = 0; i < str; i++)
                    for (int j = 0; j < col; j++)
                    {
                        Random r = new Random();
                        array[i, j] = r.Next(-100, 100);
                    }
                Console.WriteLine("\nМассив сформирован");
                return array;
            }
        }   
        static int[][] AddRandomElement(ref int[][] array)
        {
            int str;
            do
            {
                Console.WriteLine("Введите количество строк");
                str = GetNumber();
                if (str < 0)
                    Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
            } while (str < 0);
            array = new int[str][];
            if (str == 0)
                return array;
            else
            {
                for (int i = 0; i < str; i++)
                {
                    int col;
                    do
                    {
                        Console.WriteLine($"Введите количество столбцов для {i+1} строки");
                        col = GetNumber();
                        if (col < 0)
                            Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
                    } while (col < 0);
                    array[i] = new int[col];
                    for (int j = 0; j < col; j++)
                    {
                        Random r = new Random();
                        array[i][j] = r.Next(-100, 100);
                    }
                }
                Console.WriteLine("\nМассив сформирован");
                return array;
            }
        }
        static int[] AddElement(ref int[] array)
        {
            int length;
            do
            {
                Console.WriteLine("Введите количество элементов массива");
                length = GetNumber();
                if (length < 0)
                    Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
            } while (length < 0);
            array = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Введите элемент номер {i + 1}");
                int number = GetNumber();
                array[i] = number;
            }
            Console.WriteLine("\nМассив сформирован");
            return array;
        }
        static int[,] AddElement(ref int[,] array)
        {
            int str;
            do
            {
                Console.WriteLine("Введите количество строк");
                str = GetNumber();
                if (str < 0)
                    Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
            } while (str < 0);
                int col;
            do
            {
                Console.WriteLine("Введите количество столбцов");
                col = GetNumber();
                if (col < 0)
                    Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
            } while (col < 0);
            array = new int[str, col];
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.WriteLine($"Введите элемент [{i + 1},{j + 1}]");
                    array[i, j] = GetNumber();
                }
            }   
            Console.WriteLine("\nМассив сформирован");
            return array;
        }
        static int[][] AddElement(ref int[][] array)
        {
            int str;
            do
            {
                Console.WriteLine("Введите количество строк");
                str = GetNumber();
                if (str < 0)
                    Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
            } while (str < 0);
            array = new int[str][];
            for (int i = 0; i < str; i++)
            {
                int col;
                do
                {
                    Console.WriteLine($"Введите количество столбцов для {i+1} строки");
                    col = GetNumber();
                    if (col < 0)
                        Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
                } while (col < 0);
                array[i] = new int[col];
                for (int j = 0; j < col; j++)
                {
                    Console.WriteLine($"Ведите элемент {j+1}");
                    int number = GetNumber();
                    array[i][j] = number;
                }
            }
            Console.WriteLine("\nМассив сформирован");
            return array;
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
        static void PrintArr(int[] array)
        {
            Console.WriteLine();
            if (array.Length == 0 || array == null)
                Console.WriteLine("Массив пуст");
            else
            {
                foreach (int item in array)
                    Console.Write(item + " ");
                Console.WriteLine();
            }
        }
        static void PrintArr(int[,] array)
        {
            if (array.Length == 0 || array == null)
                Console.WriteLine("Массив пуст");
            else
            {
                StringBuilder sb = new StringBuilder("Полученный массив\n");
                for (int x = 0; x < array.GetLength(0); x += 1)
                {
                    for (int y = 0; y < array.GetLength(1); y += 1)
                        sb.Append(array[x, y] + " ");
                    sb.Append("\n");
                }
                string str = sb.ToString();
                Console.WriteLine(str);
            }
        }
        static void PrintArr(int[][] array)
        {
            if (array.Length == 0 || array == null)
                Console.WriteLine("Массив пуст");
            else
            {
                StringBuilder sb = new StringBuilder("Полученный массив\n");
                for (int i = 0; i < array.Length; i++)
                {
                    int g = 0;
                    for (int j = 0; j < array[i].Length - 1; j++)
                    {
                        sb.Append(array[i][j] + " ");
                        g++;
                    }
                    sb.Append(array[i][g]);
                    sb.Append("\n");
                }
                string str = sb.ToString();
                Console.WriteLine(str);
            }

        }
        static int[] DeleteItems(ref int[] array)
        {
            int count = 0;
            if (array.Length == 0)
            {
                Console.WriteLine("Массив пуст\n");
            }
            else if (array.Length == 1)
            {
                Console.WriteLine("Элементов с чётными индексами не найдено");
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        count++;
                    }
                }
                int[] arrayNew = new int[count];
                int z = 0;
                for (int k = 0; k < array.Length; k++)
                {
                    if (k % 2 == 0)
                    {
                        arrayNew[z++] = array[k];
                    }
                }
                array = arrayNew;
                Console.WriteLine("Элементы с чётными индексами успешно удалены\n");
            }    
            return array;
        }
        static int[,] AddCol(ref int[,] array)
        {
            int k;
            int n;
            do
            {
                Console.WriteLine("Введите с какого номера вы хотите добавить столбцы");
                n = GetNumber();
            } while (array.Length + 1 < n || n <= 0);
            do
            {
                Console.WriteLine("Введите количество столбцов");
                k = GetNumber();
            } while (k<0);
            if (k==0)
            {
                Console.WriteLine("Ни один столбец не добавлен");
                return array;
            }
            else
            {
                int i = array.GetLength(0);
                int j = array.GetLength(1);
                int[,] arrayNew = new int[i, j + k];
                for (int z = n-1; z < n+k-1; z++)
                {
                    for (int g = 0; g < i; g++)
                    {
                        Console.WriteLine($"Введите элемент [{g + 1},{z+1}]");
                        arrayNew[g, z] = GetNumber();
                    }
                }  
                //Добавление перед
                for (int v=0; v < i; v++)
                {
                    for (int c = 0; c < n - 1; c++)
                    {
                        arrayNew[v, c] = array[v, c];
                    }
                }
                //Добавлиние после
                for (int x = 0; x < i; x++)  
                {
                    for (int f = n + k - 1, a = n - 1; f < j+k; f++, a++)
                    {
                        arrayNew[x, f] = array[x, a];
                    }
                }
                array = arrayNew;
                return array;
            }
        }
        static int[,] AddColRandom(ref int[,] array)
        {
            int k;
            int n;
            do
            {
                Console.WriteLine("Введите с какого номера вы хотите добавить столбцы");
                n = GetNumber();
            } while (array.Length + 1 < n || n <= 0);
            do
            {
                Console.WriteLine("Введите количество столбцов");
                k = GetNumber();
            } while (k < 0);
            if (k == 0)
            {
                Console.WriteLine("Ни один столбец не добавлен");
                return array;
            }
            else
            {
                int i = array.GetLength(0);
                int j = array.GetLength(1);
                int[,] arrayNew = new int[i, j + k];
                for (int z = n - 1; z < n + k - 1; z++)
                    for (int g = 0; g < i; g++)
                    {
                        Random a = new Random();
                        arrayNew[g, z] = a.Next(-100, 100);
                    }
                for (int v = 0; v < i; v++)
                {
                    for (int c = 0; c < n - 1; c++)
                    {
                        arrayNew[v, c] = array[v, c];
                    }
                }
                for (int x = 0; x < i; x++)
                {
                    for (int f = n + k - 1, a = n - 1; f < j + k; f++, a++)
                    {
                        arrayNew[x, f] = array[x, a];
                    }
                }
                array = arrayNew;
                return array;
            }
        }
        static int[][] AddStr(ref int[][] array)
        {
            int n;
            do
            {
                Console.WriteLine("Введите под каким номером вы хотите добавить строку");
                n = GetNumber();
            } while (array.GetLength(0) + 1 < n || n <= 0);
            int col;
            do
            {
                Console.WriteLine("Введите количество столбцов");
                col = GetNumber();
                if (col < 0)
                    Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
            } while (col < 0);
            if (col == 0)
            {
                Console.WriteLine("Ни одна строка не добавлена");
                return array;
            }
            else
            {
                int[][] arrayNew = new int[array.GetLength(0) + 1][];
                int i = array.GetLength(0);
                for (int z = 0; z < n - 1; z++)//перед
                {
                    arrayNew[z] = array[z];
                }
                for (int f = n; f <= i; f++)//после
                {
                    arrayNew[f] = array[f - 1];
                }
                arrayNew[n - 1] = new int[col];
                for (int w = 0; w < col; w++)
                {
                    Console.WriteLine($"Введите {w+1} элемент");
                    arrayNew[n - 1][w] = GetNumber();
                }
                array = arrayNew;
                return array;
            }

        }
        static int[][] AddStrRandom(ref int[][] array)
        {
            int n;
            do
            {
                Console.WriteLine("Введите под каким номером вы хотите добавить строку");
                n = GetNumber();
            } while (array.GetLength(0) + 1 < n || n <= 0);
            int col;
            do
            {
                Console.WriteLine("Введите количество столбцов");
                col = GetNumber();
                if (col < 0)
                    Console.WriteLine("Неправильно введено число. Попробуйте ещё раз.");
            } while (col < 0);
            if (col == 0)
            {
                Console.WriteLine("Ни одна строка не добавлена");
                return array;
            }
            else
            {
                int[][] arrayNew = new int[array.GetLength(0) + 1][];
                int i = array.GetLength(0);
                for (int z = 0; z < n - 1; z++)//перед
                {
                    arrayNew[z] = array[z];
                }
                for (int f = n; f <= i; f++)//после
                {
                    arrayNew[f] = array[f - 1];
                }
                arrayNew[n-1] = new int[col]; 
                for (int w = 0; w < col; w++)
                {
                    Random a = new Random();
                    arrayNew[n - 1][w] = a.Next(-100,100);
                }
                array = arrayNew;
                return array;
            }
        }
        static void Main(string[] args)
        {
            int[] oneArr = new int[0];
            int[,] twoArr = new int[0,0];
            int[][] jArr = new int[0][];
            int ans;
            do
            {
                PrintMenu("Главное меню");
                Console.WriteLine("\nВведите номер пункта меню");
                ans = GetNumber();
                switch (ans)
                {
                    case 1://Одномерный массив
                        {
                            Console.Clear();
                            do
                            {
                                PrintMenu("Меню одномерного массива");
                                Console.WriteLine("\nВведите номер пункта меню");
                                ans = GetNumber();
                                switch (ans)
                                {
                                    case 1://Создать массив
                                        do
                                        {
                                            PrintMenu("Меню создания массива");
                                            Console.WriteLine("\nВведите номер пункта меню");
                                            ans = GetNumber();
                                            switch (ans)
                                            {
                                                case 1://Вручную
                                                    {
                                                        AddElement(ref oneArr);
                                                        break;
                                                    }
                                                case 2://ДСЧ
                                                    {
                                                        AddRandomElement(ref oneArr);
                                                        break;
                                                    }
                                                case 3://Выход
                                                    {
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        Console.WriteLine("\nНеверно задан пункт меню");
                                                        break;
                                                    }
                                            }
                                        } while (ans != 3);
                                        break;
                                    case 2://Напечатать массив
                                        {
                                            PrintArr(oneArr);
                                            break;
                                        }
                                    case 3://Удалить все элементв с четными индексами
                                        {
                                            DeleteItems(ref oneArr);
                                            break;
                                        }
                                    case 4://Очистить консоль
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    case 5://Выход
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("\nНеверно задан пункт меню");
                                            break;
                                        }
                                }
                            } while (ans != 5);
                            break;
                        }
                    case 2://Двумерный массив
                        {
                            Console.Clear();
                            do
                            {
                                PrintMenu("Меню двумерного массива");
                                Console.WriteLine("\nВведите номер пункта меню");
                                ans = GetNumber();
                                switch (ans)
                                {
                                    case 1://Создать массив
                                        do
                                        {
                                            PrintMenu("Меню создания массива");
                                            Console.WriteLine("\nВведите номер пункта меню");
                                            ans = GetNumber();
                                            switch (ans)
                                            {
                                                case 1://Вручную
                                                    {
                                                        AddElement(ref twoArr);
                                                        break;
                                                    }
                                                case 2://ДСЧ
                                                    {
                                                        AddRandomElement(ref twoArr);
                                                        break;
                                                    }
                                                case 3://Выход
                                                    {
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        Console.WriteLine("\nНеверно задан пункт меню");
                                                        break;
                                                    }
                                            }
                                        } while (ans != 3);
                                        break;
                                    case 2://Напечатать массив
                                        {
                                            PrintArr(twoArr);
                                            break;
                                        }
                                    case 3://Добавить K столбцов, начиная со столбца N
                                        {
                                            do
                                            {
                                                PrintMenu("Меню создания массива");
                                                Console.WriteLine("\nВведите номер пункта меню");
                                                ans = GetNumber();
                                                switch (ans)
                                                {
                                                    case 1://Вручную
                                                        {
                                                            AddCol(ref twoArr);
                                                            break;
                                                        }
                                                    case 2://ДСЧ
                                                        {
                                                            AddColRandom(ref twoArr);
                                                            break;
                                                        }
                                                    case 3://Выход
                                                        {
                                                            break;
                                                        }
                                                    default:
                                                        {
                                                            Console.WriteLine("\nНеверно задан пункт меню");
                                                            break;
                                                        }
                                                }
                                            } while (ans != 3);
                                            break;
                                        }
                                    case 4://Очистить консоль
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    case 5://Выход
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("\nНеверно задан пункт меню");
                                            break;
                                        }
                                }
                            } while (ans != 5);
                            break;
                        }
                    case 3://Рваный массив
                        {
                            Console.Clear();
                            do
                            {
                                PrintMenu("Меню рваного массива");
                                Console.WriteLine("\nВведите номер пункта меню");
                                ans = GetNumber();
                                switch (ans)
                                {
                                    case 1://Создание массива
                                        {
                                            do
                                            {
                                                PrintMenu("Меню создания массива");
                                                Console.WriteLine("\nВведите номер пункта меню");
                                                ans = GetNumber();
                                                switch (ans)
                                                {
                                                    case 1://Вручную
                                                        {
                                                            AddElement(ref jArr);
                                                            break;
                                                        }
                                                    case 2://ДСЧ
                                                        {
                                                            AddRandomElement(ref jArr);
                                                            break;
                                                        }
                                                    case 3://Выход
                                                        {
                                                            break;
                                                        }
                                                    default:
                                                        {
                                                            Console.WriteLine("\nНеверно задан пункт меню");
                                                            break;
                                                        }
                                                }
                                            } while (ans != 3);
                                            break;
                                        }
                                    case 2://Напечатать
                                        {
                                            PrintArr(jArr);
                                            break;
                                        }
                                    case 3://Добавить строку 
                                        {
                                            do
                                            {
                                                PrintMenu("Меню создания массива");
                                                Console.WriteLine("\nВведите номер пункта меню");
                                                ans = GetNumber();
                                                switch (ans)
                                                {
                                                    case 1:
                                                        {
                                                            AddStr(ref jArr);
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            AddStrRandom(ref jArr);
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    default:
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("\nНеверно задан пункт меню");
                                                            break;
                                                        }
                                                }
                                            } while (ans != 3);
                                            break;
                                        }
                                    case 4://Очистить консоль
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    case 5://Выход
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("\nНеверно задан пункт меню");
                                            break;
                                        }
                                }
                            } while (ans != 5);
                            break;
                        }
                    case 4://Выход
                        {
                            PrintMenu("Выход");
                            Console.WriteLine("\nВведите номер пункта меню");
                            ans = GetNumber();
                            switch (ans)
                            {
                                case 1://Да
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\nПрограмма завершена");
                                        System.Environment.Exit(0);
                                        break;
                                    }
                                case 2://Нет
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                default:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\nНеверно задан пункт меню");
                                        break;
                                    }
                            }
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("\nНеверно задан пункт меню");
                            break;
                        }
                }
            } while (ans!=4);
        }
    }
}