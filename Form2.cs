using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ini1File;
namespace database
{
    // :) hello github



    public partial class Form2 : Form
    {
        public static string filepath;
        public static string filepath123;
        public Form2(string te)
        {
            InitializeComponent();
            if (te != "0")
            {
                Paste1(te);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        void Paste(string filepath1)
        {
            var MyIni = new IniFile(filepath1);
            MyIni.Write("Name_", Name_.Text);
            MyIni.Write("lastname_", lastname_.Text);
            MyIni.Write("last_lst_", last_lst_.Text);
            MyIni.Write("phone_", phone_.Text);
            MyIni.Write("Operator_", Operator_.Text);
            MyIni.Write("homeadres_", homeadres_.Text);
            MyIni.Write("sity_", sity_.Text);
            MyIni.Write("oby_", oby_.Text);
            MyIni.Write("class_oby_", class_oby_.Text);
            MyIni.Write("NickName", NickName.Text);
            MyIni.Write("week_rod_", dateTimePicker1.Text);
            MyIni.Write("rod_sity_", rod_sity_.Text);
            //MyIni.Write("Rod_Dos", Rod_Dos.Text);
            //MyIni.Write("Rod_Names", Rod_Names.Text);
            MyIni.Write("Rod_1_Pro", Rod_1_Pro.Text);
            MyIni.Write("Rod_2_Pro", Rod_2_Pro.Text);
            MyIni.Write("Rod_1", Rod_1.Text);
            MyIni.Write("Rod_2", Rod_2.Text);


            MyIni.Write("img_pidorov", textBox2.Text);
            MessageBox.Show("Saved to "+filepath1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 Form1ftm = new Form1();
            Form1ftm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }
        void Paste1(string filename)
        {
            var MyIni = new IniFile(filename);
            Name_.Text = MyIni.Read("Name_");
            lastname_.Text = MyIni.Read("lastname_");
            last_lst_.Text = MyIni.Read("last_lst_");
            phone_.Text = MyIni.Read("phone_");
            Operator_.Text = MyIni.Read("Operator_");
            homeadres_.Text = MyIni.Read("homeadres_");
            sity_.Text = MyIni.Read("sity_");
            oby_.Text = MyIni.Read("oby_");
            NickName.Text = MyIni.Read("NickName");
            class_oby_.Text = MyIni.Read("class_oby_");
            dateTimePicker1.Text = MyIni.Read("week_rod_");
            rod_sity_.Text = MyIni.Read("rod_sity_");
            Rod_1_Pro.Text = MyIni.Read("Rod_1_Pro");
            Rod_2_Pro.Text = MyIni.Read("Rod_2_Pro");
            Rod_1.Text = MyIni.Read("Rod_1");
            Rod_2.Text = MyIni.Read("Rod_2");
            textBox2.Text = MyIni.Read("img_pidorov");
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void сохранитьДосьеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "dba files (*.dba)|*.dba";
            saveFileDialog1.Title = "Выбрать досье";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Paste(saveFileDialog1.FileName);

            }
        }

        private void редактироватьДосьеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "dba files (*.dba)|*.dba";
            openFileDialog1.Title = "Выбрать досье";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Paste1(openFileDialog1.FileName);

            }
        }
    }
}
