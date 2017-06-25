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
using System.IO;
using System.Net;
using System.Management;

namespace database
{
    // :) Nice .Net Reflector))))
    // :) Nice .Net Reflector))))
    // :) Nice .Net Reflector))))

    
    public partial class Form1 : Form
    {
        CookieContainer cookies = new CookieContainer();
        public string version_ = "1.7";
        public static string hwid_bleat = "";
        public Form1()
        {
            InitializeComponent();
            
            panel1.AllowDrop = true;
            panel1.DragEnter += new DragEventHandler(oby__DragEnter);
            panel1.DragDrop += new DragEventHandler(oby__DragDrop);
            try
            {
                pictureBox1.Load("http://asazs.ru/doc/no-photo-big.gif");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect to Internet. (pictureBox image not loaded)");
            }
            
        }     
        public void hwid_set()
        {
            string drive = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1);
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
            disk.Get();
            string diskLetter = (disk["VolumeSerialNumber"].ToString());
            string lol1 = (Crypt(diskLetter.ToString()));
            
            toolStripStatusLabel1.Text = "Лицензия: " + lol1 + " UserName: " + Environment.UserName;
        }
        


        private string Crypt(string text)
        {
            string rtnStr = string.Empty;
            foreach (char c in text) // Цикл, которым мы и криптуем "текст"
            {
                rtnStr += (char)((int)c ^ 3); //Число можно взять любое.
            }
            return rtnStr; //Возвращаем уже закриптованную строку.
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        void Paste(string filepath)
        {
            var MyIni = new IniFile(filepath);
            Name_.Text = MyIni.Read("Name_");
            lastname_.Text = MyIni.Read("lastname_");
            last_lst_.Text = MyIni.Read("last_lst_");
            phone_.Text = MyIni.Read("phone_");
            Operator_.Text = MyIni.Read("Operator_");
            homeadres_.Text = MyIni.Read("homeadres_");
            sity_.Text = MyIni.Read("sity_");

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
        private void button2_Click(object sender, EventArgs e)
        {
            var MyIni = new IniFile("pidor_pidorov00.dba");

            MyIni.Write("week_rod_", "01.01.1970");
            MyIni.Write("rod_sity_", "Пидороленд");
            MyIni.Write("Name_", "Пидор");
            MyIni.Write("lastname_", "Пидоров");
            MyIni.Write("last_lst_", "Пидорович");
            MyIni.Write("phone_", "+7 999 999-99-99");
            MyIni.Write("Operator_", "Pidorovka Phone");
            MyIni.Write("homeadres_", "Ул. Пидоровичка, 3");
            MyIni.Write("sity_", "Пидоровка");
            MyIni.Write("oby_", "Пидоровский Лицей");
            MyIni.Write("class_oby_", "1 Б");
            MyIni.Write("img_pidorov", "http://asazs.ru/doc/pidor.jpg");
            MyIni.Write("class_oby_", "1 Б");
            MyIni.Write("Rod_Names", "Мать: Пидорка Пидорова Подоровина; Отец: Пидор Пидоров Пидорович; ");
            MyIni.Write("Rod_Dos", "Мать: pidorka_pidorova01.dbs; Отец: pidor_pidorov02.dbs;");
            

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            hwid_set();

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
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
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
        private void oby__DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))

                e.Effect = DragDropEffects.Move;
        }
        private void oby__DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                
                for (int i = 0; i < objects.Length; i++)
                {
                    if (string.Equals(Path.GetExtension(objects[i]), ".dba", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Paste(objects[i]);
                    }
                    else
                    {
                        MessageBox.Show("Формат данного файла не поддерживается");
                    }
                }
                    
                
            }
        }
        private string GET(string Url, string Data)
        {
            WebRequest req = WebRequest.Create(Url + "?" + Data);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label26_Click(object sender, EventArgs e)
        {

        }
        private void Form1_DragLeave(object sender, EventArgs e)
        {

        }
        private void Form1_MouseEnter(object sender, EventArgs e)
        {

        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void проверитьОбновленияПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GET("http://asazs.ru/version1.txt", "") != version_)
            {
                MessageBox.Show("Имеется обновленная версия");
                WebClient webClient = new WebClient();
                webClient.DownloadFile("http://asazs.ru/new_version.exe", GET("http://asazs.ru/version1.txt", "") + ".exe");
                MessageBox.Show("Программа была обновлина, перезапустите ее из этой же папки");
                Application.Exit();

            }
            else
            {
                MessageBox.Show("Программа не имеет обновлений на данный момент;");
            }
        }
        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void версия15ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Создатель программы: Asazs; Спасибо Команде SecErr за помощь в написании программы");
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
