using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myProactive
{
	class Resources
	{
        public void LogToFTP() //Metoda zapisujaca logi do pliku log.txt na serwerze FTP
        {
            LoginDSV login = new LoginDSV();

            string date = DateTime.Today.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("HH:mm:ss");
            string who = login.Login();
            string name = SystemInformation.UserName;
            string ver = "v" + Application.ProductVersion;

            string input = "[" + date + "][" + time + "][" + name + "][" + who + "][" + ver + "]\n";

            byte[] data = Encoding.ASCII.GetBytes(input);

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://files.000webhost.com/myproactive/log.txt");
                request.Credentials = new NetworkCredential("ediapp", "w8EtQdvNMJ8vXbt");
                request.Method = WebRequestMethods.Ftp.AppendFile;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
            }
            catch
            {
            }
        }

        public string CheckVersion()
        {
            WebClient client = new WebClient();
            string versionMessage;

            try
            {
                if (client.DownloadString("https://pastebin.com/raw/Nan3DFHJ").Contains("1.2.0.1"))
                {
                    versionMessage = "[ you're using the latest version. ]";
                }
                else
                {
                    versionMessage = "[ a new version is available! ]";
                }
            }
            catch
            {
                versionMessage = "[ failed to get the version info... ]";
            }

            return versionMessage;

        }
    }
}
