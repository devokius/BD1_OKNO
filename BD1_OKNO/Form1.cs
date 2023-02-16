namespace BD1_OKNO
{
    public partial class Form1 : Form
    {
        int N = 0;
        int D;
        int E;
        bool isOpen;
        
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
                isOpen = false;
                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка");
            }
            
            
            if (N == 0)
            {
                dataGridView1.RowCount = 1;
            }
            if (N > 0)
            {
                isOpen = true;
            }
            dataGridView1.RowCount = N;
            
            for (int i = 0; i < N; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i; 
            }
            if (isOpen == true)
            {
                this.Height = 618;
                dataGridView1.Visible = true;
                dataGridView2.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                button2.Visible = true;
            }
            else
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                button2.Visible = false;
                this.Height = 185;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] Xn = new int[dataGridView1.Rows.Count];
            try
            {
                N = Convert.ToInt32(textBox1.Text);
                D = Convert.ToInt32(textBox2.Text);
                E = Convert.ToInt32(textBox3.Text);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[i].Value != null)
                        Xn[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка");
            }
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

            label6.Text = "Произведение элементов, значения которых не принадлежат отрезку D,E: " + proizved;

            var selectedBy3 = Xn.Where(item => item % 3 == 0);
            int[] Yn = selectedBy3.ToArray();
            dataGridView2.RowCount = Yn.Length;

            for (int i = 0; i < Yn.Length; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = i;
                dataGridView2.Rows[i].Cells[1].Value = Yn[i];
            }
            
        }
    }
}