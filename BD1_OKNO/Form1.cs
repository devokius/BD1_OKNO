namespace BD1_OKNO
{
    public partial class Form1 : Form
    {
        private int arrayElementsCount = 0;
        private int leftBorder;
        private int rightBorder;
        
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            button2.Visible = false;
            this.Height = 185;
            dataGridView1.Columns.Add("col1", "index");
            dataGridView1.Columns.Add("col2", "value");
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;

            dataGridView2.Columns.Add("col1", "index");
            dataGridView2.Columns.Add("col2", "value");
            dataGridView2.Columns[0].Width = 50;
            dataGridView2.Columns[1].Width = 100;
            label6.Text = "";

        }

        private void HideTables()
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            button2.Visible = false;
            Height = 185;
        }

        private void ShowTables()
        {
            Height = 618;
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            button2.Visible = true;
        }

        private bool ValidateTableParameters()
        {
            try
            {
                arrayElementsCount = Convert.ToInt32(textBox1.Text);
                leftBorder = Convert.ToInt32(textBox2.Text);
                rightBorder = Convert.ToInt32(textBox3.Text);
            }
            catch (FormatException)
            {
                HideTables();
                MessageBox.Show("Проверьте правильность введенных данных.", "Ошибка");
                return false;
            }
            catch (OverflowException)
            {
                HideTables();
                MessageBox.Show("Значение слишком большое.", "Ошибка");
                return false;
            }
            return true;
        }

        private void OnEnterbuttonClick(object sender, EventArgs e)
        {
            if (!ValidateTableParameters()) return;

            dataGridView1.RowCount = arrayElementsCount;

            for (int i = 0; i < arrayElementsCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i; 
            }

            if (arrayElementsCount > 0)
            {
                ShowTables();
            }
            else
            {
                HideTables();
            }
        }

        private bool OutOfBorders(int n)
        {
            return n < leftBorder || n > rightBorder;
        }

        private void OnCalculateButtonClick(object sender, EventArgs e)
        {
            int[] Xn = new int[dataGridView1.Rows.Count];

            if (!ValidateTableParameters()) return;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value == null)
                {
                    MessageBox.Show($"Значение не поодерживается. (Строка {i})", "Ошибка");
                    return;
                }
                try
                {
                    Xn[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                }
                catch (Exception)
                {
                    MessageBox.Show($"Значение не поодерживается. (Строка {i})", "Ошибка");
                    return;
                }
            }

            int nOperations = 0;
            int proizved = 1;
            for (int i = 0; i < Xn.Length; i++)
            {
                if (OutOfBorders(Xn[i]))
                {
                    proizved *= Xn[i];
                    nOperations++;
                }
            }
            if (nOperations == 0)
                proizved = 0;

            label6.Text = "Произведение элементов, значения которых не принадлежат отрезку D,E: " + proizved;

            int[] Yn = Xn.Where(item => item % 3 == 0).ToArray();
            dataGridView2.RowCount = Yn.Length;

            for (int i = 0; i < Yn.Length; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = i;
                dataGridView2.Rows[i].Cells[1].Value = Yn[i];
            }
        }
    }
}