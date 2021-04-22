using System;
using System.IO;
using System.Net.FtpClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class FtpHelper : HelperBase
    {
        private FtpClient client;

        public FtpHelper(ApplicationManager manager) : base(manager) {
            client = new FtpClient();
            client.Host = "localhost";
            client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            client.Connect();

        }

        public void BUFile(String path)
        {
            String buPath = path + ".bak";
            if (client.FileExists(buPath))
            {
                return;
            }
            client.Rename(path, buPath);
        }

        public void RestoreBUFile(String path)
        {
            String buPath = path + ".bak";
            if (!client.FileExists(buPath))
            {
                return;
            }
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }
            client.Rename(buPath, path);
        }

        public void Upload(String path, Stream localFile)
        {
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }
            using (Stream ftpStream = client.OpenWrite(path))
            {
                byte[] buffer = new byte[8 * 1024];
                int count = localFile.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    ftpStream.Write(buffer, 0, count);
                    count = localFile.Read(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
