using System.Collections.Immutable;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace lab6
{
    internal class Program
    {
        static void PrintMenu(string str)
        {
            if (str == "Главное меню")
            {
                Console.WriteLine("1.Перевернуть все слова в предложении и отсортировать слова по убыванию в лексикографическом порядке.");
                Console.WriteLine("2.Выход");
            }
            else if (str == "Меню создания")
            {
                Console.WriteLine("\n1.Использовать предложенный текст");
                Console.WriteLine("2.Ввести предложения вручную");
                Console.WriteLine("3.Назад");
            }
            else if (str == "Выход")
            {
                Console.WriteLine("\nВы действительно хотите завершить работу?");
                Console.WriteLine("1.Да");
                Console.WriteLine("2.Нет");
            }
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
        static void SortWord(string text = "В лесу родилась елочка! В лесу она росла.")
        {
            string newStr = String.Empty;
            text = text.Replace("+", "");
            Console.WriteLine($"Исходный текст: {text}");
            string textNew = text.Replace(".", " . ").Replace("?", " ? ").Replace("!", " ! ").Replace(",", " , ").Replace(":", " : ").Replace(";", " ; ").Trim();
            textNew = Regex.Replace(textNew, "\\s+", "+");
            string[] a = textNew.Split('+');
            int k = 0;
            foreach (string word in a)
            {
                if (word == "")
                    k++;
            }
            string[] tmp = new string[a.Length - k];
            for (int i = 0, j = 0; i < a.Length; i++)
            {
                if (a[i] != "")
                {
                    tmp[j] = a[i];
                    j++;
                }
            }
            for (int i = 0; i < a.Length; i++)
            {
                char[] array = a[i].ToCharArray();
                Array.Reverse(array);
                newStr += new String(array);
                if (i < a.Length - 1)
                    newStr += ' ';

            }
            newStr = newStr.Replace(" ,", ",").Replace(" :", ":").Replace(" ;", ";");
            string[] revSentences = newStr.Replace(".", ".+").Replace("!", "!+").Replace("?", "?+").Split('+');
            int m = 0;
            foreach (string word in revSentences)
            {
                if (word == "")
                    m++;
            }
            string[] t = new string[revSentences.Length - m];
            for (int i = 0, j = 0; i < revSentences.Length; i++)
            {
                if (revSentences[i] != "")
                {
                    t[j] = revSentences[i];
                    j++;
                }
            }
            string result = String.Empty;
            foreach (string s in t)
            {
                int count1 = s.ToCharArray().Count(c => c == '.');
                int count2 = s.ToCharArray().Count(c => c == '!');
                int count3 = s.ToCharArray().Count(c => c == '?');
                string sentence = s.Trim();
                string[] words = sentence.Split(" ");
                for (int j = 1; j < words.Length; j++)
                {
                    for (int w = words.Length - 1; w >= j; w--)
                    {
                        if (words[w].CompareTo(words[w - 1]) < 0)
                        {
                            string temp = words[w];
                            words[w] = words[w - 1];
                            words[w - 1] = temp;
                        }
                    }
                }
                foreach (string word in words)
                {
                    if(word != "!" && word != "." && word != "?")
                    {
                        result += word;
                        result += " ";
                    }
                }
                result = result.Trim();
                if (count1 > 0)
                    result += ". ";
                else if(count2 > 0)
                    result += "! ";
                else if (count3 > 0)
                    result += "? ";
            }
            Console.WriteLine($"Полученный текст: {result}");
        }
        static bool CorrectInput(ref string inputStr)
        {
            inputStr = inputStr.Replace(".", ".+").Replace("!", "!+").Replace("?", "?+");
            bool gd = true;
            StringBuilder sb = new StringBuilder();
            Regex sample = new Regex(@"^[А-Я][^.!?]*[.!?]$");
            string[] sentences = inputStr.Split("+");
            if (sentences[^1] == " " || sentences[^1] == "")
                Array.Resize(ref sentences, sentences.Length - 1);
            for (int i = 0; i < sentences.Length; i++)
            {
                string sentence = sentences[i].Trim();
                if (sample.IsMatch(sentence) != true)
                {
                    gd = false;
                }
            }
            if (gd)
                return true;
            else
                return false;
        }
        static bool EmptyStr(ref string inputStr)
        {
            bool gd = true;
            int count = 0;
            string test = inputStr.Replace(" ", "+");
            foreach (char ch in test)
            {
                if (ch == '+')
                    count++;
            }
            if (inputStr.Length == 0 || inputStr == null || inputStr.Contains("\t") || (count == inputStr.Length))
                gd = false;
            if (gd)
                return true;
            else
                return false;
        }
        static string ManualInput()
        {
            string inputStr;
            bool isCorrect, isEmpty;
            do
            {
                Console.WriteLine("Введите предложение:");
                inputStr = Console.ReadLine();
                isCorrect = CorrectInput(ref inputStr);
                isEmpty = EmptyStr(ref inputStr);
                if (!isEmpty)
                {
                    Console.WriteLine("Нельзя ввести пустую строку. Попробуйте ещё раз.\n");
                }
                else if (!isCorrect)
                {
                    Console.WriteLine("Предложение должно начинаться с заглавной буквы и оканчиваться знаком окончания предложения. Попробуйте ещё раз.\n");
                }
            } while (isCorrect == false);
            return inputStr;
        }
        static void Main(string[] args)
        {
            int ans;
            do
            {
                PrintMenu("Главное меню");
                Console.WriteLine("\nВведите номер пункта меню");
                ans = GetNumber();
                switch (ans)
                {
                    case 1:
                        {
                            Console.Clear();
                            do
                            {
                                PrintMenu("Меню создания");
                                Console.WriteLine("\nВведите номер пункта меню");
                                ans = GetNumber();
                                switch (ans)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            SortWord();
                                            break;
                                        }
                                    case 2://вручную
                                        {
                                            Console.Clear();
                                            SortWord(ManualInput());
                                            break;
                                        }
                                    case 3:
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
                    case 2:
                        {
                            Console.Clear();
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
                            Console.WriteLine("\nНеверно задан пункт меню");
                            break;
                        }
                }
            } while (ans != 2);
        }
    }
}