using System;
using System.Windows.Forms;
using Ini1File;
using System.IO;
using System.Net;

namespace database
{
    // :) hello github

    
    public partial class Form1 : Form
    {
        public string version_ = "2.0"; 
        public static string hwid_bleat = "";
        public Form1()
        {
            InitializeComponent();
            try
            {
                pictureBox1.Load("http://asazs.ru/doc/no-photo-big.gif");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка программы. обратитесь к asazs, asazs.ru -> Projects -> Database -> feedback. и отправьте скриншот и что вы делали после чего появилась данная ошибка." + Environment.NewLine + ": " + ex.Message);

                Environment.Exit(0);
            }
            
        }     
        void Paste(string filepath)
        {
            var MyIni = new IniFile(filepath);
            Name_.Text = MyIni.Read("Name_");
            lastname_.Text = MyIni.Read("lastname_");
            last_lst_.Text = MyIni.Read("last_lst_");
            phone_.Text = MyIni.Read("phone_");
            Propiska_.Text = MyIni.Read("Propiska_");
            Operator_.Text = MyIni.Read("Operator_");
            info_avt.Text = MyIni.Read("info_avt");
            homeadres_.Text = MyIni.Read("homeadres_");
            sity_.Text = MyIni.Read("sity_");
            Passdan_.Text = MyIni.Read("Passdan_");
            oby_.Text = MyIni.Read("oby_");
            class_oby_.Text = MyIni.Read("class_oby_");
            week_rod_.Text = MyIni.Read("week_rod_");
            rod_sity_.Text = MyIni.Read("rod_sity_");
            NickName.Text = MyIni.Read("NickName");
            Rod_1_Pro.Text = MyIni.Read("Rod_1_Pro");
            Rod_2_Pro.Text = MyIni.Read("Rod_2_Pro");
            Rod_1.Text = MyIni.Read("Rod_1");
            Rod_2.Text = MyIni.Read("Rod_2");
            try
            {
                pictureBox1.Load(MyIni.Read("img_pidorov"));
            }catch(Exception e) { }


            Form1 frm = new Form1();
            this.Text = "Досье: [" + Name_.Text + " " + lastname_.Text + " " + last_lst_.Text + " " + "]";
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            if (GET("http://asazs.ru/version.txt", "") != version_)
            {
                MessageBox.Show("Имеется обновленная версия");
                
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile("http://asazs.ru/new_version.exe", GET("http://asazs.ru/version.txt", "") + ".exe");
                }
                catch (Exception exc) {
                    MessageBox.Show("Ошибка программы. обратитесь к asazs, asazs.ru -> Projects -> Database -> feedback. и отправьте скриншот и что вы делали после чего появилась данная ошибка." + Environment.NewLine + ": " + exc.Message);
                    Environment.Exit(0);
                } 
                MessageBox.Show("Программа была обновлина, перезапустите ее из этой же папки");
                Application.Exit();

            }
            else
            {
                MessageBox.Show("Программа не имеет обновлений на данный момент;");
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        private void создатьДосьеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Form2ftm = new Form2("0");
            Form2ftm.Show();
        }
        private void открытьДосьеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "dba files (*.dba)|*.dba";
            openFileDialog1.Title = "Выбрать досье";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Paste(openFileDialog1.FileName);
            }
        }
        private string GET(string Url, string Data)
        {
            try
            {
                WebRequest req = WebRequest.Create(Url + "?" + Data);
                WebResponse resp = req.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string Out = sr.ReadToEnd();
                sr.Close();
                return Out;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка программы. обратитесь к asazs, asazs.ru -> Projects -> Database -> feedback. и отправьте скриншот и что вы делали после чего появилась данная ошибка." + Environment.NewLine + ": " + e.Message);
                Environment.Exit(0);
                return "";

            }
            
        }
        private void проверитьОбновленияПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        
        private void редактироватьДосьеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "dba files (*.dba)|*.dba";
            openFileDialog1.Title = "Выбрать досье";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Form2 Form2ftm = new Form2(openFileDialog1.FileName);
                Form2ftm.Show();
            }
        }
        
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Создатель программы: Asazs; Спасибо Команде SecErr за помощь в написании программы");
        }
    }
}
