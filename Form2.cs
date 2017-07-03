using System;
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
            try
            {
                var MyIni = new IniFile(filepath1);
                MyIni.Write("Name_", Name_.Text);
                MyIni.Write("lastname_", lastname_.Text);
                MyIni.Write("last_lst_", last_lst_.Text);
                MyIni.Write("phone_", phone_.Text);
                MyIni.Write("Operator_", Operator_.Text);
                MyIni.Write("homeadres_", homeadres_.Text);
                MyIni.Write("sity_", sity_.Text);
                MyIni.Write("Propiska_", Propiska_.Text);
                MyIni.Write("oby_", oby_.Text);
                MyIni.Write("info_avt", info_avt.Text);
                MyIni.Write("class_oby_", class_oby_.Text);
                MyIni.Write("NickName", NickName.Text);
                MyIni.Write("week_rod_", dateTimePicker1.Text);
                MyIni.Write("rod_sity_", rod_sity_.Text);
                MyIni.Write("Rod_1_Pro", Rod_1_Pro.Text);
                MyIni.Write("Rod_2_Pro", Rod_2_Pro.Text);
                MyIni.Write("Rod_1", Rod_1.Text);
                MyIni.Write("Rod_2", Rod_2.Text);
                MyIni.Write("Passdan_", Passdan_.Text);


                MyIni.Write("img_pidorov", textBox2.Text);
                MessageBox.Show("Saved to " + filepath1);
            }
            catch(Exception e)
            {
                MessageBox.Show("Ошибка программы. обратитесь к asazs, asazs.ru -> Projects -> Database -> feedback. и отправьте скриншот и что вы делали после чего появилась данная ошибка." + Environment.NewLine + ": " + e.Message);
                Environment.Exit(0);
            }
            
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
        void Paste1(string filename)
        {
            try
            {

                var MyIni = new IniFile(filename);
                Name_.Text = MyIni.Read("Name_");
                lastname_.Text = MyIni.Read("lastname_");
                last_lst_.Text = MyIni.Read("last_lst_");
                phone_.Text = MyIni.Read("phone_");
                Operator_.Text = MyIni.Read("Operator_");
                homeadres_.Text = MyIni.Read("homeadres_");
                sity_.Text = MyIni.Read("sity_");
                Propiska_.Text = MyIni.Read("Propiska_");
                oby_.Text = MyIni.Read("oby_");
                NickName.Text = MyIni.Read("NickName");
                class_oby_.Text = MyIni.Read("class_oby_");
                dateTimePicker1.Text = MyIni.Read("week_rod_");
                rod_sity_.Text = MyIni.Read("rod_sity_");
                Rod_1_Pro.Text = MyIni.Read("Rod_1_Pro");
                info_avt.Text = MyIni.Read("info_avt");
                Passdan_.Text = MyIni.Read("Passdan_");
                Rod_2_Pro.Text = MyIni.Read("Rod_2_Pro");
                Rod_1.Text = MyIni.Read("Rod_1");
                Rod_2.Text = MyIni.Read("Rod_2");
                textBox2.Text = MyIni.Read("img_pidorov");

            } catch (Exception e)
            {
                MessageBox.Show("Ошибка программы. обратитесь к asazs, asazs.ru -> Projects -> Database -> feedback. и отправьте скриншот и что вы делали после чего появилась данная ошибка." + Environment.NewLine + ": " + e.Message);
                Environment.Exit(0);
            }
        }
        

        private void сохранитьДосьеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (lastname_.Text == "Дьяков")
            {
                Environment.Exit(1);
            }
            else
            {
                if (lastname_.Text == "Харитонов")
                {
                    Environment.Exit(1);
                }
                else
                {
                    if (lastname_.Text == "Бобко")
                    {
                        Environment.Exit(1);
                    }
                    else
                    {
                        if (lastname_.Text == "Еврантов")
                        {
                            Environment.Exit(1);
                        }
                    }
                }
            }


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

        private void Name__TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
