using System;
using System.Windows;
using System.Numerics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Media;

namespace ЛР_1
{
    internal class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("1 – Общая информация по типам");
            Console.WriteLine("2 – Выбрать тип из списка");
            Console.WriteLine("3 – Параметры консоли");
            Console.WriteLine("0 - Выход из программы");
            Console.WriteLine(" ");

            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1': CommonInformation(); break;
                    case '2': ShowAllTypeInfo(); break;
                    case '3': ChangeConsoleView(); break;
                    default: Environment.Exit(0); break;
                }
            }

            Console.ReadKey();
        }

        public static void CommonInformation()
        {
            Assembly myAsm = Assembly.GetExecutingAssembly();
            Type[] thisAssemblyTypes = myAsm.GetTypes();
            Assembly[] refAssemblies = AppDomain.CurrentDomain.GetAssemblies();


            List<Type> types = new List<Type>();
            foreach (Assembly asm in refAssemblies)
                types.AddRange(asm.GetTypes());
            int c = 0;
            int v = 0;
            foreach (var t in types)
            {
                if (t.IsClass)
                    c++;
                else if (t.IsValueType)
                    v++;

            }

            int CountNumber = 0;
            foreach (var t in types)
            {
                foreach (var prop in t.GetProperties())
                {
                    if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(uint) || prop.PropertyType == typeof(long) || prop.PropertyType == typeof(ulong) ||
                        prop.PropertyType == typeof(short) || prop.PropertyType == typeof(ushort) || prop.PropertyType == typeof(sbyte) || prop.PropertyType == typeof(byte)) 
                        
                        CountNumber++;
                }
            }

            int CountNumber_1 = 0; /*Дополнительно вывести количество с длинной от 7 до 13*/
            foreach (var t in types)
            {
                foreach (var prop in t.GetProperties())
                {
                    if ((prop.PropertyType == typeof(int) || prop.PropertyType == typeof(uint) || prop.PropertyType == typeof(long) || prop.PropertyType == typeof(ulong) ||
                        prop.PropertyType == typeof(short) || prop.PropertyType == typeof(ushort) || prop.PropertyType == typeof(sbyte) || prop.PropertyType == typeof(byte)) &&
                        prop.Name.Length >= 7 && prop.Name.Length <= 13)
                        CountNumber_1++;
                }
            }

            Type MaxInt = typeof(int);
            int count = 0;
            foreach (var t in types)
            {
                if (t.IsInterface)
                {
                    if (t.GetMethods().Length > count)
                    {
                        MaxInt = t;
                        count = t.GetMethods().Length;
                    }
                }
            }


               /*Дополнительно вывести количество с длинной от 7 до 13*/
            int count_1 = 0;
            foreach (var t in MaxInt.GetMethods())
            {
                if (t.Name.Length >= 7 && t.Name.Length <= 13)
                    count_1++;                                    
            }

            Console.Clear();
            Console.WriteLine("Общая информация по типам");
            Console.WriteLine("Подключенные сборки:  " + refAssemblies.Length);
            Console.WriteLine("Всего типов по всем подключенным сборкам:  " + types.Count);
            Console.WriteLine("Ссылочные типы (только классы): " + c);
            Console.WriteLine("Значимые типы: " + v);
            Console.WriteLine(" ");
            Console.WriteLine("Количество свойств целочисленного типа: " + CountNumber);
            Console.WriteLine("Количество свойств целочисленного типа и длина названия от 7 до 13: " + CountNumber_1);
            Console.WriteLine("Интерфейс с наибольшим числом методов и число методов: " + MaxInt + "  " + count);
            Console.WriteLine("Число методов, у котрых длина названия от 7 до 13: " + MaxInt + "  " + count_1);
            Console.WriteLine(" ");

            Console.WriteLine(" ");
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в главное меню");

            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    default: Main(); break;
                }
            }
        }

        public static void ShowAllTypeInfo()
        {
            Console.Clear();
            Console.WriteLine("Информация по типам ");
            Console.WriteLine("Выберите тип: ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1 – uint");
            Console.WriteLine("2 – int");
            Console.WriteLine("3 – long");
            Console.WriteLine("4 – float");
            Console.WriteLine("5 – double");
            Console.WriteLine("6 – char");
            Console.WriteLine("7 - string");
            Console.WriteLine("8 – Vector");
            Console.WriteLine("9 – Matrix");
            Console.WriteLine("0 – Выход в главное меню");
            Console.WriteLine(" ");

            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1':
                        Type t_1 = typeof(uint);
                        SelectType(t_1);
                        break;
                    case '2':
                        Type t_2 = typeof(int);
                        SelectType(t_2);
                        break;
                    case '3':
                        Type t_3 = typeof(long);
                        SelectType(t_3);
                        break;
                    case '4':
                        Type t_4 = typeof(float);
                        SelectType(t_4);
                        break;
                    case '5':
                        Type t_5 = typeof(double);
                        SelectType(t_5);
                        break;
                    case '6':
                        Type t_6 = typeof(char);
                        SelectType(t_6);
                        break;
                    case '7':
                        Type t_7 = typeof(string);
                        SelectType(t_7);
                        break;
                    case '8':
                        Type t_8 = typeof(Vector);
                        SelectType(t_8);
                        break;
                    case '9':
                        Type t_9 = typeof(Matrix);
                        SelectType(t_9);
                        break;
                    default: Main(); break;

                }
            }
        }

        public static void SelectType(Type t)
        {
            Console.Clear();
            Console.WriteLine("Информация по типу: " + t);
            string s;
            if (t.IsValueType == true) s = "+";
            else s = "-";
            Console.WriteLine("Значимый тип: " + s);
            Console.WriteLine("Пространство имен: " + t.Namespace);
            Console.WriteLine("Сборка: " + t.Assembly.GetName().Name);
            Console.WriteLine("Общее число элементов: " + t.GetMembers().Length);
            Console.WriteLine("Число методов: " + t.GetMethods().Length);
            Console.WriteLine("Число свойств: " + t.GetProperties().Length);
            Console.WriteLine("Число полей: " + t.GetFields().Length);

            string[] fieldNames = new string[t.GetFields().Length];
            for (int i = 0; i < t.GetFields().Length; i++)
            {
                fieldNames[i] = t.GetFields()[i].Name;
            }
            string FName = string.Join(", ", fieldNames);

            string[] propNames = new string[t.GetProperties().Length];
            for (int i = 0; i < t.GetProperties().Length; i++)
            {
                propNames[i] = t.GetProperties()[i].Name;
            }
            string PName = string.Join(", ", propNames); ;


            Console.WriteLine("Список полей: " + FName);
            Console.WriteLine("Список свойств: " + PName);

            Console.WriteLine("Нажмите 'M' для вывода дополнительной информации по методам: ");
            Console.WriteLine("Нажмите '0' для выхода в главное меню");
            Console.WriteLine(" ");

            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case 'm': InfMetods(t); break;
                    default: Main(); break;

                }
            }
        }
        public static void InfMetods(Type t)
        {

            Dictionary<string, int> AllMetods = new Dictionary<string, int>();
            foreach (MethodInfo method in t.GetMethods())
            {
                if (AllMetods.ContainsKey(method.Name))
                    // в словаре уже есть такое имя, обновляем статистику
                    AllMetods[method.Name]++;
                else
                    // в словаре нет такого имени, добавляем элемент
                    AllMetods.Add(method.Name, 1);
            }

            object[,] Res = new object[AllMetods.Count, 3];
            int i = 0;
            foreach (var m in AllMetods)
            {
                Res[i, 0] = m.Key;
                Res[i, 1] = m.Value;

                i++;

            }

            Dictionary<string, string> AllParametrs = new Dictionary<string, string>();
            foreach (MethodInfo method in t.GetMethods())
            {
                int OP = 0;
                int NOP = 0;
                int A = 0;
                foreach (var parametr in method.GetParameters())
                {
                    if (parametr.IsOptional)
                        OP++;
                    else NOP++;
                }

                A = OP + NOP;
                if (AllParametrs.ContainsKey(method.Name))
                // в словаре уже есть такое имя, обновляем статистику
                {
                    if (NOP == 0)
                        AllParametrs[method.Name] = OP.ToString();
                    else AllParametrs[method.Name] = OP.ToString() + ".." + A.ToString();
                }

                else
                    // в словаре нет такого имени, добавляем элемент
                    AllParametrs.Add(method.Name, " ");
            }

            int j = 0;
            foreach (var m in AllParametrs)
            {
                Res[j, 2] = m.Value;
                j++;

            }

            Console.Clear();
            Console.WriteLine("Методы типа " + t);
            Console.WriteLine("Методы");
            Console.WriteLine("Название   Число перегрузок    Число параметров ");
            for (int k = 0; k < AllMetods.Count; k++)
            {
                Console.SetCursorPosition(1, k + 4);
                Console.Write(Res[k, 0]);
                Console.SetCursorPosition(20, k + 4);
                Console.Write(Res[k, 1]);
                Console.SetCursorPosition(40, k + 4);
                Console.Write(Res[k, 2]);
                Console.WriteLine();
            }

            Console.WriteLine("Нажмите 1, если хотите ввести число перегрузок: ");
            Console.WriteLine("Нажмите 0, если хотите вернуьтся в главное меню ");

            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1': MethodsOverload(t);break;
                    default: Main(); break;

                }
            }


        }

        public static void MethodsOverload(Type t) /*Доп: вывод отдельного числа перегрузок*/
        {

            Dictionary<string, int> AllMetods = new Dictionary<string, int>();
            foreach (MethodInfo method in t.GetMethods())
            {
                if (AllMetods.ContainsKey(method.Name))
                    // в словаре уже есть такое имя, обновляем статистику
                    AllMetods[method.Name]++;
                else
                    // в словаре нет такого имени, добавляем элемент
                    AllMetods.Add(method.Name, 1);
            }

            object[,] Res = new object[AllMetods.Count, 3];
            int i = 0;
            foreach (var m in AllMetods)
            {
                Res[i, 0] = m.Key;
                Res[i, 1] = m.Value;

                i++;

            }

            Dictionary<string, string> AllParametrs = new Dictionary<string, string>();
            foreach (MethodInfo method in t.GetMethods())
            {
                int OP = 0;
                int NOP = 0;
                int A = 0;
                foreach (var parametr in method.GetParameters())
                {
                    if (parametr.IsOptional)
                        OP++;
                    else NOP++;
                }

                A = OP + NOP;
                if (AllParametrs.ContainsKey(method.Name))
                // в словаре уже есть такое имя, обновляем статистику
                {
                    if (NOP == 0)
                        AllParametrs[method.Name] = OP.ToString();
                    else AllParametrs[method.Name] = OP.ToString() + ".." + A.ToString();
                }

                else
                    // в словаре нет такого имени, добавляем элемент
                    AllParametrs.Add(method.Name, " ");
            }

            int j = 0;
            foreach (var m in AllParametrs)
            {
                Res[j, 2] = m.Value;
                j++;

            }

            Console.WriteLine(" ");
            Console.WriteLine("Введити число перегрузок: ");
            int s = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(" ");
            Console.Clear();
            Console.WriteLine("Методы типа " + t);
            Console.WriteLine("Методы");
            Console.WriteLine("Название   Число перегрузок    Число параметров ");
            int u = 4;
            for (int k = 0; k < AllMetods.Count; k++)
            {
                if (Convert.ToInt32(Res[k, 1]) == s)
                {
                    Console.SetCursorPosition(0, u);
                    Console.Write(Res[k, 0]);
                    Console.SetCursorPosition(20, u);
                    Console.Write(Res[k, 1]);
                    Console.SetCursorPosition(40, u);
                    Console.Write(Res[k, 2]);
                    u++;
                    Console.WriteLine();
                }

            }
            Console.WriteLine("Нажмите 0, если хотите вернуться  ");
            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    default: InfMetods(t); break;

                }
            }

        }
        public static void ChangeConsoleView()
        {
            Console.Clear();
            Console.WriteLine("1 - изменить цвет фона");
            Console.WriteLine("2 - изменить цвет текста");
            Console.WriteLine("0 - выход в главное меню");
            Console.WriteLine(" ");

            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1': BackgroundColor(); break;
                    case '2': TextColor(); break;
                    default: Main(); break;
                }
            }

        }
        public static void BackgroundColor()
        {
            Console.Clear();
            Console.WriteLine("1 - красный");
            Console.WriteLine("2 - синий");
            Console.WriteLine("3 - зеленый");
            Console.WriteLine("4 - белый");
            Console.WriteLine("5 - черный");
            Console.WriteLine(" ");

            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1':
                        if (Console.ForegroundColor == ConsoleColor.Red)
                        { Console.WriteLine("Невозможно!"); Console.Clear(); ChangeConsoleView(); break; }
                        else
                        { Console.BackgroundColor = ConsoleColor.Red; Console.Clear(); ChangeConsoleView(); break; }

                    case '2':
                        if (Console.ForegroundColor == ConsoleColor.Blue)
                        { Console.WriteLine("Невозможно!"); Console.Clear(); ChangeConsoleView(); break; }
                        else
                        { Console.BackgroundColor = ConsoleColor.Blue; Console.Clear(); ChangeConsoleView(); break; }
                    case '3':
                        if (Console.ForegroundColor == ConsoleColor.Green)
                        { Console.WriteLine("Невозможно!"); Console.Clear(); ChangeConsoleView(); break; }
                        else
                        { Console.BackgroundColor = ConsoleColor.Green; Console.Clear(); ChangeConsoleView(); break; }
                    case '4':
                        if (Console.ForegroundColor == ConsoleColor.White)
                        { Console.WriteLine("Невозможно!"); Console.Clear(); ChangeConsoleView(); break; }
                        else
                        { Console.BackgroundColor = ConsoleColor.White; Console.Clear(); ChangeConsoleView(); break; }
                    case '5':
                        if (Console.ForegroundColor == ConsoleColor.Black)
                        { Console.WriteLine("Невозможно!"); Console.Clear(); ChangeConsoleView(); break; }
                        else
                        { Console.BackgroundColor = ConsoleColor.Black; Console.Clear(); ChangeConsoleView(); break; }
                    default: ChangeConsoleView(); break;
                }
            }
        }

        public static void TextColor()
        {
            Console.Clear();
            Console.WriteLine("1 - красный");
            Console.WriteLine("2 - синий");
            Console.WriteLine("3 - зеленый");
            Console.WriteLine("4 - белый");
            Console.WriteLine("5 - черный");
            Console.WriteLine(" ");

            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1':
                        if (Console.BackgroundColor == ConsoleColor.Red)
                        { Console.WriteLine("Невозможно!"); Console.Clear(); ChangeConsoleView(); break; }
                        else
                        { Console.ForegroundColor = ConsoleColor.Red; Console.Clear(); ChangeConsoleView(); break; }

                    case '2':
                        if (Console.BackgroundColor == ConsoleColor.Blue)
                        { Console.WriteLine("Невозможно!"); Console.Clear(); ChangeConsoleView(); break; }
                        else
                        { Console.ForegroundColor = ConsoleColor.Blue; Console.Clear(); ChangeConsoleView(); break; }
                    case '3':
                        if (Console.BackgroundColor == ConsoleColor.Green)
                        { Console.WriteLine("Невозможно!"); Console.Clear(); ChangeConsoleView(); break; }
                        else
                        { Console.ForegroundColor = ConsoleColor.Green; Console.Clear(); ChangeConsoleView(); break; }
                    case '4':
                        if (Console.BackgroundColor == ConsoleColor.White)
                        { Console.WriteLine("Невозможно!"); Console.Clear(); ChangeConsoleView(); break; }
                        else
                        { Console.ForegroundColor = ConsoleColor.White; Console.Clear(); ChangeConsoleView(); break; }
                    case '5':
                        if (Console.BackgroundColor == ConsoleColor.Black)
                        { Console.WriteLine("Невозможно!"); Console.Clear(); ChangeConsoleView(); break; }
                        else
                        { Console.ForegroundColor = ConsoleColor.Black; Console.Clear(); ChangeConsoleView(); break; }
                    default: ChangeConsoleView(); break;
                }
            }
        }
    }
}
