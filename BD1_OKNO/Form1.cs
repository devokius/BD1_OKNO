namespace BD1_OKNO
{
    public partial class Form1 : Form
    {
        int N = 0;
        int D;
        int E;
        bool isOpen;
        bool isCorrect;
        
        public Form1()
        {
            InitializeComponent();
            Text = "20 Вариант. Сидоров Кирилл Дмитриевич.";
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            button2.Visible = false;
            this.Height = 185;

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
            Height = 515;
            dataGridView1.Visible = true;
            label4.Visible = true;
            button2.Visible = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                N = Convert.ToInt32(textBox1.Text);
                D = Convert.ToInt32(textBox2.Text);
                E = Convert.ToInt32(textBox3.Text);
            }
            catch (Exception ex)
            {
                HideTables();
                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка");
                return;
            }
            dataGridView1.ColumnCount = N;
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            for (int i = 0; i < N; i++)
            {
                dataGridView1.Rows[0].ReadOnly = true;
                dataGridView1.Rows[0].Cells[i].Value = "x[" + i + "]";
            }
            if (N > 0)
            {
                ShowTables();
            }
            else
            {
                HideTables();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] Xn = new int[N];
            try
            {
                N = Convert.ToInt32(textBox1.Text);
                D = Convert.ToInt32(textBox2.Text);
                E = Convert.ToInt32(textBox3.Text);
                for (int i = 0; i < N; i++)
                {
                    isCorrect = true;
                    if (dataGridView1.Rows[1].Cells[i].Value != null)
                        Xn[i] = Convert.ToInt32(dataGridView1.Rows[1].Cells[i].Value);
                    else throw new Exception("Проверьте данные в таблице");
                }
            }
            catch (Exception ex)
            {
                isCorrect = false;
                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка");
            }
            
            if (isCorrect)
            {
                int nOperations = 0;
                int proizved = 1;
                for (int i = 0; i < Xn.Length; i++)
                {
                    if (Xn[i] < D || Xn[i] > E)
                    {
                        proizved *= Xn[i];
                        nOperations++;
                    }
                }
                if (nOperations == 0)
                    proizved = 0;
                label5.Visible = true;
                label6.Visible = true;
                dataGridView2.Visible = true;
                label6.Text = "Произведение элементов, значения которых не принадлежат отрезку D,E: " + proizved;
                var delimetedBy3 = Xn.Where(item => item % 3 == 0);
                int[] Yn = delimetedBy3.ToArray();
                dataGridView2.ColumnCount = Yn.Length;
                dataGridView2.RowCount = 2;
                for (int i = 0; i < Yn.Length; i++)
                {
                    dataGridView2[i, 0].ReadOnly = true;
                    dataGridView2[i, 0].Value = "y[" + i + "]";
                    dataGridView2[i, 1].Value = Yn[i];
                }
            }
        }
    }
}