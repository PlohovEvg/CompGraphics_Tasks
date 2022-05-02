using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Matrix
    {
        int columnscount;
        int rowscount;

        /// <summary>
        /// Значения в матрице
        /// </summary>
        List<List<float>> values;

        /// <summary>
        /// Число столбцов
        /// </summary>
        public int ColumnsCount
        {
            get
            {
                return columnscount;
            }
        }

        /// <summary>
        /// Число строк
        /// </summary>
        public int RowsCount
        {
            get
            {
                return rowscount;
            }
        }

        /// <summary>
        /// Создаёт матрицу и заполняет её нулями
        /// </summary>
        /// <param name="rows">Число строк</param>
        /// <param name="columns">Число столбцов</param>
        public Matrix(int rows, int columns) : this(rows, columns, 0.0f)
        {
        }

        /// <summary>
        /// Создаёт матрицу и заполняет её главную диагональ заданным значением
        /// </summary>
        /// <param name="rows">Число строк</param>
        /// <param name="columns">Число столбцов</param>
        /// <param name="diagonalValue">Значение на главной диагонали</param>
        public Matrix(int rows, int columns, float diagonalValue)
        {
            columnscount = columns;
            rowscount = rows;
            values = new List<List<float>>(rows);

            for(int i = 0; i < rowscount; i++)
            {
                values.Add(new List<float>(columns));

                for(int j = 0; j < columnscount; j++)
                {
                    if (i != j)
                    {
                        values[i].Add(0.0f);
                    }
                    else
                    {
                        values[i].Add(diagonalValue);
                    }
                }
            }
        }

        /// <summary>
        /// Создаёт матрицу и заполнет её заданными значениями
        /// </summary>
        /// <param name="rows">Число строк</param>
        /// <param name="columns">Число столбцов</param>
        /// <param name="values">Значения</param>
        /// <exception cref="Exception"></exception>
        public Matrix(int rows,int columns, float[] values) : this(rows, columns)
        {
            if (values.Length != rows * columns)
            {
                throw new Exception("Количество значений должно быть равно числу строк, умноженному число столбцов");
            }

            for(int i = 1; i <= rows; i++)
            {
                for(int j = 1; j <= columns; j++)
                {
                    SetValueOnPosition(i, j, values[(j - 1) + (i - 1) * columns]);
                }
            }
        }

        /// <summary>
        /// Задаёт значение по индексу
        /// </summary>
        /// <param name="i">Индекс строки</param>
        /// <param name="j">Индекс столбца</param>
        /// <param name="newValue">Новое значение</param>
        /// <exception cref="ArgumentException"></exception>
        public void SetValueOnPosition(int i,int j, float newValue)
        {
            if (i < 1 || i > RowsCount || j < 1 || j > ColumnsCount)
            {
                throw new ArgumentException("Неверно указана позиция");
            }

            values[i - 1][j - 1] = newValue;
        }

        /// <summary>
        /// Получает значение по индексу
        /// </summary>
        /// <param name="i">Индекс строки</param>
        /// <param name="j">Индекс столбца</param>
        /// <returns>Значение по этому индексу</returns>
        /// <exception cref="ArgumentException"></exception>
        public float GetValueOnPosition(int i, int j)
        {
            if (i < 1 || i > RowsCount || j < 1 || j > ColumnsCount)
            {
                throw new ArgumentException("Неверно указана позиция");
            }

            return values[i - 1][j - 1];
        }

        /// <summary>
        /// Транспонирование
        /// </summary>
        /// <returns></returns>
        public Matrix Transpond()
        {
            Matrix res = new Matrix(ColumnsCount, RowsCount);

            for (int i = 1; i <= res.RowsCount; i++)
            {
                for (int j = 1; j <= res.ColumnsCount; j++)
                {
                    res.SetValueOnPosition(i, j, GetValueOnPosition(j, i));
                }
            }

            return res;
        }

        /// <summary>
        /// Преобразует вектор в точку
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Point3D_ok ToPoint()
        {
            if(!((RowsCount == 4 && ColumnsCount == 1) || (RowsCount == 1 && ColumnsCount == 4)))
            {
                throw new Exception("Нельзя эту матрицу трансформировать в точку");
            }

            if(RowsCount == 4)
            {
                return new Point3D_ok(GetValueOnPosition(1, 1), GetValueOnPosition(2, 1), GetValueOnPosition(3, 1));
            }
            else
            {
                return new Point3D_ok(GetValueOnPosition(1, 1), GetValueOnPosition(1, 2), GetValueOnPosition(1, 3));
            }
            
        }

        /// <summary>
        /// Заполнить всю матрицу указанным значением
        /// </summary>
        /// <param name="value"></param>
        public void FillWithValue(float value)
        {
            for (int i = 1; i <= RowsCount; i++)
            {
                for (int j = 1; j <= ColumnsCount; j++)
                {
                    SetValueOnPosition(i, j, value);
                }
            }
        }

        /// <summary>
        /// Преобразование матрицы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(rowscount);

            foreach (var row in values)
            {
                string rowStr = string.Empty;

                foreach (float value in row)
                {
                    rowStr += String.Format("{0} ", value);
                }

                sb.AppendLine("(" + rowStr.TrimEnd() + ")");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Перемножение матриц
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Matrix operator *(Matrix first, Matrix second)
        {

            if(first.ColumnsCount != second.RowsCount)
            {
                throw new Exception("Количество столбцов в первой матрице должно совпадать с количеством строк во второй");
            }
            int rowsColumnsCounter = first.ColumnsCount;
            Matrix res = new Matrix(first.RowsCount, second.ColumnsCount);

            for(int i = 1; i <= res.RowsCount; i++)
            {
                for(int j = 1; j <= res.ColumnsCount; j++)
                {
                    float summaryValue = 0.0f;

                    for (int k = 1; k <= rowsColumnsCounter; k++)
                    {
                        summaryValue += first.GetValueOnPosition(i, k) * second.GetValueOnPosition(k, j);
                    }

                    res.SetValueOnPosition(i, j, summaryValue);
                }
            }

            return res;
        }
    }
}
