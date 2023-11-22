using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР_2
{
    public class Matrix
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Нажмите 1 чтобы ввести матрицу");
            Console.WriteLine("Нажмите 2 чтобы ввести две матрицы и перемножить их");
            Console.WriteLine("Нажмите 0 для выхода");
            Console.WriteLine(" ");

            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1': User() ; break;
                    case '2': Mult(); break;
                    default: Environment.Exit(0); break;
                }
            }

            Console.ReadKey();
        }

        public static void User()//Ввод матрицы для пользователя и вывод свойств
        {
            Console.WriteLine("Введите строку с матрицой(данные через пробел): ");
            string s = Console.ReadLine();

            Matrix m;
            bool b = Matrix.TryParse(s, out m);
            

            if (m != null)
            {
                double tr = m.Trace();
                Console.Clear();
                
                Console.WriteLine("Вы успешно ввели матрицу!");
                Console.WriteLine(" ");
                Console.WriteLine("Нажмите 1 чтобы просмотреть свойства матрицы");
                Console.WriteLine("Нажмите 0 для выхода");
                Console.WriteLine(" ");
                Console.WriteLine("Матрица: ");
                for (int i = 0; i < m.Rows*m.Columns; i++)
                    Console.Write(m[i] + " ");
                Console.WriteLine(" ");
                

                while (true)
                {
                    switch (char.ToLower(Console.ReadKey(true).KeyChar))
                    {
                        case '1':
                            Console.Clear();
                            Console.WriteLine("Количество строк: " + m.Rows);
                            Console.WriteLine("Количество столбцов: " + m.Columns);
                            Console.WriteLine("След матрицы: " + tr);
                            Console.Write("Симметричная ли матрица: ");
                            if(m.IsSymmetric == true)
                                Console.Write("Симметричная");
                            else Console.Write("Не симметричная");
                            Console.WriteLine();
                            Console.WriteLine("Нажмите любую клавишу для выхода");
                            break;
                        default: Main(); break;
                    }
                }

            }
            else 
            {
                Console.Clear();
                Console.WriteLine("Вы неправильно ввели матрицу!");
                Console.WriteLine("Нажмите любую клавишу для выхода");

                while (true)
                {
                    switch (char.ToLower(Console.ReadKey(true).KeyChar))
                    {
                        default: Main(); break;
                    }
                }
            }
            
        }
        public static void Mult()//Перемножение матриц для пользователя
        {
            Console.WriteLine("Введите строки с матрицами(данные через пробел): ");
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            Matrix m1;
            TryParse(s1, out m1);
            Matrix m2;
            TryParse(s2, out m2);

            Matrix m = m1 * m2;
            Console.Clear();

            if (m1 == null || m2 == null)
            {
                Console.WriteLine("Вы неправильно ввели матрицу!");
            } 
            if (m == null)
            {
                Console.WriteLine("Невозжно перемножить матрицы!");
            }
            else 
            {
                Console.WriteLine("Результат: ");
                for (int i = 0; i < m.Columns*m.Rows; i++)
                {
                    Console.Write(m[i]);
                    Console.Write(" ");
                }
                Console.WriteLine();

            }
            Console.WriteLine("Нажмите любую клавишу для выхода");
            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    default: Main(); break;
                }
            }

        }

        double[] data;
        public Matrix(int nRows, int nCols)//Конструктор 1
        {
           data = new double[nRows * nCols];
           Rows = nRows;
           Columns = nCols;

        }
        public Matrix(double[] Initdata) //Конструктор 2
        {
            Rows = Convert.ToInt32(Initdata[0]);
            Columns = Convert.ToInt32(Initdata[1]);
            data = new double[Rows * Columns];
            int k = 0;
            for (int i = 2; i < Initdata.Length; i++)
            {
                data[k]= Initdata[i];
                k++;
            }

        } 
        public double this[int i] //Свойство индекатор
        {
            get => data[i];
            set => data[i] = value; 
        }

        public int Rows { get; } //доступ к числу строк
        public int Columns { get; } //доступ к числу столбцов

        int k = 0;
        public bool IsSymmetric //Проверка на семмитричность
        {
            get
            {
                double[,] new_data = new double[Rows, Columns];
                int k = 0;
                for (int j = 0; j < Rows; j++)
                {
                    for (int i = 0; i < Columns; i++)
                    {
                        new_data[j, i] = data[k];
                        k++;
                    }

                }
                k = 0;
                if (Rows == Columns)
                {
                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {
                            if (new_data[i, j] == new_data[j, i])
                                k++;
                        }
                    }
                }
                if (k == Rows * Columns)
                    return true;
                else return false;
            }
        }

        public static Matrix operator *(Matrix m1, Matrix m2)//Оператор перемножения
        {
            double[,] New_m1 = new double[m1.Rows, m1.Columns];
            int k = 0;
            for (int j = 0; j < m1.Rows; j++)
            {
                for (int i = 0; i < m1.Columns; i++)
                {
                    New_m1[j, i] = m1[k];
                    k++;
                }

            }

            double[,] New_m2 = new double[m2.Rows, m2.Columns];
            k = 0;
            for (int j = 0; j < m2.Rows; j++)
            {
                for (int i = 0; i < m2.Columns; i++)
                {
                    New_m2[j, i] = m2[k];
                    k++;

                }

            }
            double[,] temp_res = new double[m1.Rows, m2.Columns];

            if (m1.Columns == m2.Rows)
            {
                for (int j = 0; j < m1.Rows; j++)
                {
                    for (int i = 0; i < m2.Columns; i++)
                    {
                        temp_res[j, i] = 0;

                        for (int l = 0; l < m1.Columns; l++)
                        {
                            temp_res[j, i] += New_m1[j, l] * New_m2[l, i];
                        }
                    }
                }

            }
            else return null;
            k = 0;
            Matrix res = new Matrix (m1.Rows, m2.Columns);
            for (int j = 0; j < m1.Rows; j++)
            {
                for (int i = 0; i < m2.Columns; i++)
                {
                    res[k] = temp_res[j, i];
                    k++;
                }

            }
            return res;
        }

        public double Trace() //След матрицы
        {
            double res = 0;
            double[,] new_data = new double[Rows, Columns];
            int k = 0;
            for (int j = 0; j < Rows; j++)
            {
                for (int i = 0; i < Columns; i++)
                {
                    new_data[j, i] = data[k];
                    k++;
                }

            }
            k = 0;
            if (Rows == Columns)
            {
                for (int j = 0; j < Rows; j++)
                {
                    for (int i = 0; i < Columns; i++)
                    {
                        if (i == j)
                            res += new_data[i, j];
                    }

                }
                return res;
            }
            else return 0;

        }

        public static bool TryParse(string s, out Matrix m)//Преобразование строки в матрицу
        {
            try
            {
                //Доп. задание (если пользователь вводит несколько пробелов между значениями)
                while (s.Contains("  "))
                {
                    s = s.Replace("  ", " ");
                }
                string[] str = s.Split(' ');
                int i = Convert.ToInt32(str[0]);
                int j = Convert.ToInt32(str[1]);
                
                m = new Matrix(i, j);
                int l = 0;

                //Доп. задание (если пользователь ставит точку вместо запятой для дробных значений)
                for (int k = 2; k < str.Length; k++)
                {
                    str[k] = str[k].Replace(".", ",");
                }

                for (int k = 2; k < str.Length; k++)
                {
                     m[l] = Convert.ToDouble(str[k]);
                     l++;
                }
                return true;          
            }
            catch
            {
                m = null;
                return false; 
            }            
        }
    }
}
