using ЛР_2;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()//Тест на проверку количества строк столбцов при первом констуктуре
        {
            Matrix m = new Matrix(1, 2);
            Assert.AreEqual(1, m.Rows);
            Assert.AreEqual(2, m.Columns);
        }

        [TestMethod]
        public void TestMethod2()//Тест на проверку количества строк и столбцов при втором констуктуре
        {
            double[] arr = new double[] {1, 2, 1, 1};
            Matrix m = new Matrix(arr);

            Assert.AreEqual(1, m.Rows);
            Assert.AreEqual(2, m.Columns);
        }

        [TestMethod]
        public void TestMethod3()//Тест на проверку симметричности
        {
            string s = "2 2 1 1 1 1";
            Matrix m;
            Matrix.TryParse(s, out m);

            Assert.AreEqual(true, m.IsSymmetric);
        }

        [TestMethod]
        public void TestMethod4()//Тест на перемножение матриц
        {
            Matrix m1;
            Matrix m2;

            string s_1 = "3 2 1 2 3 5 6 11";
            Matrix.TryParse(s_1, out m1);

            string s_2 = "2 3 3 4 2 1 4 2";

            Matrix.TryParse(s_2, out m2);
            
            m2 = m1*m2;

            double d = m2[0];
            Assert.AreEqual(5, d);
        }

        [TestMethod]
        public void TestMethod5()//Тест на след матрицы
        {
            string s = "2 2 1 1 1 1";
            Matrix m ;

            Matrix.TryParse(s, out m);

            double d = m.Trace();
            Assert.AreEqual(2, d);

        }

        //Дополнительные тесты

        [TestMethod]
        public void TestMethod6()//Тест на неправильный ввод матрицы
        {
            string s = "5 5";//Будет заполняться нулевымии значениями
            Matrix m;

            bool b = Matrix.TryParse(s, out m);

            Assert.AreEqual(0, m[0]);
        }

        [TestMethod]
        public void TestMethod7()//Тест на неправильный ввод матрицы
        {
            string s = "2 2 1 1 1 1 1";
            Matrix m;

            bool b = Matrix.TryParse(s, out m);

            Assert.AreEqual(false, b);
        }
        [TestMethod]
        public void TestMethod8()//Тест на след не квадратной матрицы
        {
            string s = "3 2 1 0 1 3 2 1";
            Matrix m;

            Matrix.TryParse(s, out m);

            double d = m.Trace();
            Assert.AreEqual(0, d);
        }

        [TestMethod]
        public void TestMethod9()//Тест на след матрицы
        {
            string s = "3 3  6 9 1,4  0 2 4  100 0,5 -0,2";
            Matrix m;

            Matrix.TryParse(s, out m);

            double d = m.Trace();
            Assert.AreEqual(7.8, d);
        }


        [TestMethod]
        public void TestMethod10()//Тест на неправильное перемножение
        {
            Matrix m1;
            Matrix m2;

            string s_1 = "3 2 1 2 3 5 6 11";
            Matrix.TryParse(s_1, out m1);

            string s_2 = "1 2 3 4";

            Matrix.TryParse(s_2, out m2);

            m2 = m1 * m2;
            Assert.AreEqual(null, m2);
        }

        [TestMethod]
        public void TestMethod11()//Тест на ввод с несколькими пробелами
        {
            Matrix m1;

            string s_1 = "3 2 1 2 3 5   6 11";
            Matrix.TryParse(s_1, out m1);

            Assert.AreEqual(6, m1[4]);
        }

        [TestMethod]
        public void TestMethod12()//Тест на ввод с точкой
        {
            Matrix m1;

            string s_1 = "2 2 1.3 -7 0 15.5";
            Matrix.TryParse(s_1, out m1);

            double d = 1.3;

            Assert.AreEqual(d, m1[0]);
        }

    }
}