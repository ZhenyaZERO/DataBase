using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string ip_site = GET("http://icanhazip.com", "");
            ip_site = ip_site.Replace(" ", "");
            ip_site = ip_site.Replace("\n", "");

            string ip_asazs = GET("http://asazs.ru/blacklist.txt", "");
            ip_asazs = ip_asazs.Replace(" ", "");
            ip_asazs = ip_asazs.Replace("\n", "");

            if (ip_site == ip_asazs)
            {
                MessageBox.Show("Доступ К программе ограничен. (Banned)", "Забанен", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            ebashim(Environment.UserName);
            
            
        }
        static string GET(string Url, string Data)
        {
            WebRequest req = WebRequest.Create(Url + "?" + Data);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }
        static string Crypt(string text)
        {
            string rtnStr = string.Empty;
            foreach (char c in text) // Цикл, которым мы и криптуем "текст"
            {
                rtnStr += (char)((int)c ^ 3); //Число можно взять любое.
            }
            return rtnStr; //Возвращаем уже закриптованную строку.
        }
        static string Cryp1t(string text)
        {
            string input = text;
            byte[] buffer = Encoding.ASCII.GetBytes(input);
            string base64 = Convert.ToBase64String(buffer); // SGVsbG8sIFdvcmxk
            
            return Crypt(base64) + "__928"; //Возвращаем уже закриптованную строку.
        }
        static void ebashim(string login)
        {
            String password = "log=asazs_top&pas=1the_world1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://5.188.232.39/login.php");
            request.UserAgent = "Opera/9.80";
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] EncodedPostParams = Encoding.ASCII.GetBytes(password);
            request.ContentLength = EncodedPostParams.Length;
            request.GetRequestStream().Write(EncodedPostParams, 0, EncodedPostParams.Length);
            request.GetRequestStream().Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string html = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("windows-1251")).ReadToEnd();
            string[] stringSeparators = new string[] { "\n" };
            string[] result = html.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            string PolucheniiNomer = "";

            foreach (string stroka in result)
            {
                if (stroka.IndexOf(login) != -1)
                {
                    string[] NashaStroka = stroka.ToString().Split((Convert.ToChar("|")));

                    string reLoL0 = ((NashaStroka[1].ToString()));
                    PolucheniiNomer = reLoL0.ToString();

                }
            }

            string HoldingAdress = "";
            try
            {
                string drive = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1);
                ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
                disk.Get();
                string diskLetter = (disk["VolumeSerialNumber"].ToString());
                string lol1 = (Crypt(diskLetter.ToString()));
                HoldingAdress = lol1;

            }
            catch (Exception)
            {
                MessageBox.Show("Critical error, application automatically exit", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (PolucheniiNomer == HoldingAdress)
            {
                MessageBox.Show("Вход успешен (Лицензия #: " + PolucheniiNomer + ")");
                Application.Run(new Form1());
                Settings1.Default.hwid = PolucheniiNomer;
                return;

            }
            else
            {
                MessageBox.Show("Ошибка входа (HWID Недействителен), либо у вас нет лицензии. Обратитесь к vk.com/asazs!");
                DateTime date1 = new DateTime();
                string code = @"{							"+ Environment.NewLine + "	UserName: (" + Environment.UserName + "),		" + Environment.NewLine + "	License_Code: (" + HoldingAdress + "),			" + Environment.NewLine + "                   Date: (" + DateTime.Now + "),				" + Environment.NewLine + "	Windows: (" + Environment.OSVersion + "),	" + Environment.NewLine + "	Architecture (64?): (" + Environment.Is64BitOperatingSystem + "),		" + Environment.NewLine + "	Activation_Code: (" + Cryp1t(Crypt(HoldingAdress)) + ")		" + Environment.NewLine + "}";
                

                MessageBox.Show("Сделайте скриншот этого окна если ваш HWID не действителен, либо вы хотите купить лицензию.\n" + code);


            }
        }
    }
}
