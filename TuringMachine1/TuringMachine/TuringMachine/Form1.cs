using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringMachine
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
           
            InitializeComponent();
            radioButton1.Checked=true;
            cs = new CellStrip();
            foreach (Cell c1 in cs.getCellstrip())
            {
                this.Controls.Add(c1.getgroup());
            }
            //dataGridView1.Rows.Add(1);
            //dataGridView1.Rows[0].HeaderCell.Value = "-";
            dataGridView1.RowHeadersDefaultCellStyle.Padding = new Padding(3);
            dataGridView1.RowHeadersWidth = 30;
            addRowsfromAlphabet();
            AddState();
        }
        CellStrip cs;
        private void set_Visibility_DelayBar(bool f)
        {
            delaybar.Visible = f;
            minzdelay.Visible = f;
            maxzdelay.Visible = f;
            curdelay.Visible = f;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            curdelay.Text = delaybar.Value.ToString();
            set_Visibility_DelayBar(true);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            set_Visibility_DelayBar(false);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            set_Visibility_DelayBar(false);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            bool f = true;
            delaybar.Visible = f;
            minzdelay.Visible = f;
            maxzdelay.Visible = f;
            curdelay.Visible = f;
        }

        private void button2_Click(object sender, EventArgs e)
        {
             cs= new CellStrip();
            foreach (Cell c1 in cs.getCellstrip())
            {
                //this.Controls.Add(c1.getLabel());
                //this.Controls.Add(c1.gettextbox());
                this.Controls.Add(c1.getgroup());
            }
            /*for (int i = 1; i < cs.getCellstrip().Length; i++)
            {
                this.Controls.Add(cs.getCellstrip()[i].getgroup());
            }*/
            /*Label l = new Label();
            l.Text = "1";
            l.Visible = true;
            l.Location = new Point(20, 150);
            this.Controls.Add(l);*/
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cs.getCellstrip()[cs.getCellstrip().Length - 1].getPosition().X+30 > this.Width)
            cs.MoveRight();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(cs.getCellstrip()[0].getPosition().X<0)
            cs.MoveLeft();
        }

        private void SetNumberOnStrip_Click(object sender, EventArgs e)
        {

            int o1 = Convert.ToInt32(operand1.Text);
            int o2 = Convert.ToInt32(operand2.Text);// cs = new CellStrip(o1 + o2 + 1);
            if ((o1 == 0) | (o2 == 0))
            {
                MessageBox.Show("Введите данные для обработки!");
            }
            else
            {
                cs.GenerateCellStrip(o1, o2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cs.MoveEndorHome(false);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cs.MoveEndorHome(true);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sum_Click(object sender, EventArgs e)
        {
            cs.SumStrip();
        }

        private void сложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cs.SumStrip();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddState();
        }
        private void AddState()
        {
            int b = dataGridView1.Columns.GetColumnCount(new DataGridViewElementStates());
            b++;
            dataGridView1.Columns.Add("Q" + b, "Q" + b);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            StringBuilder ss = new StringBuilder();
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (!ss.ToString().Contains(textBox1.Text[i]))
                {
                    ss.Append(textBox1.Text[i]);
                }
            }
            textBox1.Text = ss.ToString();
            textBox1.Select(textBox1.Text.Length, 0);
            addRowsfromAlphabet();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            int b = dataGridView1.Columns.GetColumnCount(new DataGridViewElementStates());
            if(b!=2)
            dataGridView1.Columns.RemoveAt(b-1);
        }
        private void addRowsfromAlphabet()
        {
            string t = textBox1.Text;
            while (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }

            StringBuilder s = new StringBuilder();
            s.Append("-");
            s.Append(",");
            s.Append(t);
            t = s.ToString();
            dataGridView1.Rows.Add(t.Length);
            for (int i = 0; i < t.Length; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = t[i] + "  ";

                // MessageBox.Show(dataGridView1.Rows[i+1].HeaderCell.Value.ToString()+dataGridView1.Rows[i + 1].HeaderCell.Visible);
            }
            dataGridView1.Refresh();
            dataGridView1.RefreshEdit();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            addRowsfromAlphabet();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cs.GenerateCellStrip();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            groupBox3.Visible = true;
            else { groupBox3.Visible = false; }
            richTextBox1.Text = "23";
            richTextBox1.Text += "\n"+"12";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            checkBox1.Checked=false;
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void алфавитToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Файл алфавита|*.alp";
            openFileDialog1.Title = "Выберите файл алфавита";
            
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader str = new StreamReader(openFileDialog1.FileName);
                textBox1.Text=str.ReadLine();
                str.Close();
               // this.Cursor = new Cursor(openFileDialog1.OpenFile());
            }
        }

        private void алгоритмToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Файл алгоритма|*.alg";
            openFileDialog1.Title = "Выберите файл алгоритма";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Cursor = new Cursor(openFileDialog1.OpenFile());
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void алфавитToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файл алфавита (*.alp)|*.alp|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(textBox1.Text);
                streamWriter.Close();
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
