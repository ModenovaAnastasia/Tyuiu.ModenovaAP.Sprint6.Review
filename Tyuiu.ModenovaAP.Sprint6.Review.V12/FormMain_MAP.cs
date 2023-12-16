using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.ModenovaAP.Sprint6.Review.V12.Lib;

namespace Tyuiu.ModenovaAP.Sprint6.Review.V12
{
    public partial class FormMain_MAP : Form
    {
        public FormMain_MAP()
        {
            InitializeComponent();
        }
        int[,] arrayValues;
        public int[,] GetMatrix()
        {

            int N = Convert.ToInt32(textBoxWidth_MAP.Text);
            int M = Convert.ToInt32(textBoxLenght_MAP.Text);
            int n1 = Convert.ToInt32(textBoxStartRandom_MAP.Text);
            int n2 = Convert.ToInt32(textBoxEndRandom_MAP.Text);

            if (N <= 0)
            {
                MessageBox.Show("Введено некорректное число столбцов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                int[,] array = new int[0, 0];
                return array;
            }
            else if (M <= 0)
            {
                MessageBox.Show("Введено некорректное число строк", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                int[,] array = new int[0, 0];
                return array;
            }
            else if (n1 > n2)
            {
                MessageBox.Show("Старт рандома больше конца рандома", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                int[,] array = new int[0, 0];
                return array;
            }
            else
            {
                int[,] array = new int[N, M];

                Random rnd = new Random();
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (j % 4 == 3)  //Если остаток числа, при делении индекса строки на 4, равен 3, то это четвёртый элемент в массиве
                        {
                            array[i, j] = array[i, j - 1] + array[i, j - 2] + array[i, j - 3]; //Суммируем предыдущие 3 элемента строки
                        }
                        else //Иначе
                        {
                            array[i, j] = rnd.Next(n1, n2); //Задаём этому элементу случайное число
                        }

                    }
                }
                return array;
            }
        }

        private void buttonUse_MAP_Click(object sender, EventArgs e)
        {
            DataService ds = new DataService();
            int k = Convert.ToInt32(textBoxStartScore_MAP.Text);
            int l = Convert.ToInt32(textBoxEndScore_MAP.Text); 
            int c = Convert.ToInt32(textBoxChoice_MAP.Text);
            if (k > l)
            {
                MessageBox.Show("Старт шага больше конца", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (c > arrayValues.GetLength(1))
            {
                MessageBox.Show("Такого столбца не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                textBoxRes_MAP.Text = Convert.ToString(ds.GetMatrix(arrayValues, c, k, l));
            }
            catch
            {

            }
        }

        private void buttonInfo_MAP_Click(object sender, EventArgs e)
        {
            FormAbout_MAP formAbout = new FormAbout_MAP();
            formAbout.ShowDialog();
        }

        private void buttonGen_MAP_Click(object sender, EventArgs e)
        {
            try
            {
                DataService ds = new DataService();

                arrayValues = GetMatrix();

                dataGridViewOutput_MAP.ColumnCount = arrayValues.GetLength(1);
                dataGridViewOutput_MAP.RowCount = arrayValues.GetLength(0);

                for (int i = 0; i < arrayValues.GetLength(0); i++)
                {

                    for (int j = 0; j < arrayValues.GetLength(1); j++)
                    {
                        dataGridViewOutput_MAP.Rows[i].Cells[j].Value = arrayValues[i, j];
                    }

                }

                buttonUse_MAP.Enabled = true;
            }
            catch
            {

            }
            
        }
    }
}
